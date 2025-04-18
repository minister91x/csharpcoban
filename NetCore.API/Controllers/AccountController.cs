using CSharpCoban.DataAccess.Netcore.DataObject;
using CSharpCoban.DataAccess.Netcore.IRepository;
using CSharpCoban.DataAccess.Netcore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Account_GetAll")]
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
            catch (Exception )
            {
                throw;
            }
        }
    }
}
