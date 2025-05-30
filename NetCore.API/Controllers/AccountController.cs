using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CSharpCoban.DataAccess.Netcore.DataObject;
using CSharpCoban.DataAccess.Netcore.IRepository;
using CSharpCoban.DataAccess.Netcore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using NetCore.API.Filter;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace NetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly IAccountRepository _accountRepository;
        //public AccountController(IAccountRepository accountRepository)
        //{
        //    _accountRepository = accountRepository;
        //}

        private IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IDistributedCache _cache;


        public AccountController(IUnitOfWork unitOfWork, IConfiguration configuration, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _cache = cache;
        }
        [HttpPost("Account_Login")]
        public async Task<IActionResult> Account_Login(AccountLogin_RequestData requestData)
        {
            var result = new LoginReturnData();
            var listKey = new List<string>();
            try
            {
                // Bước 0 :

                // Kết nối đến Redis server (sửa lại nếu bạn dùng host/port khác)
                ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");

                // Lấy database (mặc định là DB 0)
                IDatabase db = redis.GetDatabase();

                // Lấy server object để có thể truy vấn key
                // Lưu ý: cần biết rõ endpoint để tạo đối tượng server
                var endpoints = redis.GetEndPoints();
                IServer server = redis.GetServer(endpoints[0]);

                // Lấy tất cả key (có thể thêm pattern nếu cần)
                foreach (var key in server.Keys())
                {
                    listKey.Add(key.ToString().Substring(0,15));
                }



                // bước 1: CheckLogin 
                var resultLogin = await _unitOfWork._accountRepository.Account_Login(requestData);
                if (resultLogin == null)
                {
                    result.ResponseCode = -1;
                    result.ResponseMessage = "Tài khoản không tồn tại";
                    return Ok(result);
                }

                // Kiểm tra số lượng Sessison 

                var keySessions = "User_sessions_" + resultLogin.AccountID;

                //  var CountKey = listKey.FindAll(s => s.Equals(keySessions)).Count;
                var CountKey = 0;
                if (listKey.Count > 0)
                {
                    foreach (var item in listKey)
                    {
                        if(item== keySessions) { CountKey++; }
                    }
                }
                if (CountKey >= 2)
                {
                    result.ResponseCode = -21;
                    result.ResponseMessage = "Tài khoản của bạn chỉ được phép đăng nhập trên 02 thiết bị ";
                    return Ok(result);
                }

                // Bước 2 : Tạo claims 

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, resultLogin.UserName),
                    new Claim(ClaimTypes.PrimarySid, resultLogin.AccountID.ToString()),
                    new Claim(ClaimTypes.GivenName, resultLogin.FullName.ToString())
                };

                // Bước 3 : Tạo token

                var newToken = CreateToken(claims);

                var token = new JwtSecurityTokenHandler().WriteToken(newToken);


                // bước 4: Lưu token vào database/Redis (nếu cần thiết)

                var user_sessions = new User_Sessions
                {
                    AccountID = resultLogin.AccountID,
                    Token = token,
                    DeviceID = requestData.DeviceID,
                    ExpriredTime = new JwtSecurityToken(token).ValidTo
                };

                var keyCaching = $"User_sessions_{resultLogin.AccountID}_{requestData.DeviceID}";
                var options_cache = new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(30) // Thời gian hết hạn của token
                };

                var data_cache = JsonConvert.SerializeObject(user_sessions);

                await _cache.SetStringAsync(keyCaching, data_cache, options_cache);

                // Bước 4: Trao kết quả cho client
                result.ResponseCode = 1;
                result.ResponseMessage = "Login Successful";
                result.token = token;
                result.AccountID = resultLogin.AccountID;
                result.UserName = resultLogin.UserName;
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost("Account_GetAll")]
        // [CSharpCoBanAuthorizeAttribute("Account_GetAll", "ISVIEWS")]
        public async Task<IActionResult> Account_GetAll()
        {
            var result = new List<Acccount>();
            try
            {
                //var result = await _accountRepository.Acccounts_GetAll();
                //Lần đầu thì thì vào database để lấy dữ liệu

                // kiểm tra trong caching 
                var cacheKey = "GetAll_KeyCaching";
                var cacheData = await _cache.GetStringAsync(cacheKey);

                if (cacheData != null)
                {
                    // nếu trong caching có dữ liệu thì lấy luôn
                    result = JsonConvert.DeserializeObject<List<Acccount>>(cacheData);
                    return Ok(result);
                }

                // nếu trong caceh không có thì vào db để lấy dữ liệu
                result = await _unitOfWork._accountGenericRepository.GetAll();

                // set dữ liệu vào cache
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(1));

                await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(result), options);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("Account_LogOut")]
        [CSharpCoBanAuthorizeAttribute("Account_LogOut", "")]
        public async Task<ActionResult> Account_LogOut(Account_LogOutRequestData requestData)
        {
            try
            {
                // Lấy được AccountID từ Filter 
               var AccountID = UserManagerSession.AccountID;

                // Lấy DeviceID 
                // kết hợp User_Session_AccountID_DeviceID // User_Session_3_DEVICE_01
                var keyCache = "User_sessions_" + AccountID + "_" + requestData.DeviceID;

                // Xóa cái key User_Session_3_DEVICE_01 trong redis

                _cache.Remove(keyCache);

                return Ok(new { mes = "LogOut Thành công !" });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("Account_Delete")]
        [CSharpCoBanAuthorizeAttribute("Account_Delete", "ISDELETE")]
        public async Task<IActionResult> Account_Delete([FromBody] AccountDelete_RequestData requestData)
        {
            try
            {
                var result = await _unitOfWork._accountRepository.Account_Delete(requestData);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Account_Update")]
        [CSharpCoBanAuthorizeAttribute("Account_Update", "ISUPDATE")]
        public async Task<IActionResult> Account_Update([FromBody] AccountUpdate_RequestData requestData)
        {
            try
            {
                var result = await _unitOfWork._accountRepository.Account_Update(requestData);


                var rs_delete = await _unitOfWork._accountRepository.Account_Delete(
                    new AccountDelete_RequestData { AcccountID = requestData.AccountID - 1 });


                _unitOfWork.SaveChanges();

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        // var identity = context.HttpContext.User.Identity as ClaimsIdentity;


    }
}
