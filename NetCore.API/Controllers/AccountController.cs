using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CSharpCoban.DataAccess.Netcore.DataObject;
using CSharpCoban.DataAccess.Netcore.IRepository;
using CSharpCoban.DataAccess.Netcore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetCore.API.Filter;

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

        public AccountController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        [HttpPost("Account_Login")]
        public async Task<IActionResult> Account_Login(AccountLogin_RequestData requestData)
        {
            var result = new LoginReturnData();
            try
            {
                // bước 1: CheckLogin 
                var resultLogin = await _unitOfWork._accountRepository.Account_Login(requestData);
                if (resultLogin == null)
                {
                    result.ResponseCode = -1;
                    result.ResponseMessage = "Tài khoản không tồn tại";
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
        [CSharpCoBanAuthorizeAttribute()]
        public async Task<IActionResult> Account_GetAll()
        {
            try
            {
                //var result = await _accountRepository.Acccounts_GetAll();
                var result = await _unitOfWork._accountGenericRepository.GetAll();
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

        [HttpPost("Account_Delete")]
        [CSharpCoBanAuthorizeAttribute()]
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
        [CSharpCoBanAuthorizeAttribute()]
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
