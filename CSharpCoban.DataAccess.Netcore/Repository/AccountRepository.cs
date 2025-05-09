using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCoban.DataAccess.Netcore.DataObject;
using CSharpCoban.DataAccess.Netcore.EfCore;
using CSharpCoban.DataAccess.Netcore.IRepository;
using CSharpCoBan.CommonNetCore;

namespace CSharpCoban.DataAccess.Netcore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private CSharpCoBanDbContext _dbContext;
        public AccountRepository(CSharpCoBanDbContext dbContext)
        {
            // khởi tạo
            _dbContext = dbContext;
        }
        public async Task<List<Acccount>> Acccounts_GetAll()
        {
            var list = new List<Acccount>();
            try
            {
                list = _dbContext.account.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }

        public async Task<ReturnData> Account_Delete(AccountDelete_RequestData requestData)
        {
            var result = new ReturnData();
            try
            {
                var account = _dbContext.account.Where(x => x.AccountID == requestData.AcccountID).FirstOrDefault();
                if (account == null)
                {
                    result.ResponseCode = -1;
                    result.ResponseMessage = "Account not found";
                    return result;
                }

                _dbContext.account.Remove(account);
                /// _dbContext.SaveChanges();
                throw new Exception("Lỗi không thể xóa tài khoản này");

                result.ResponseCode = 1;
                result.ResponseMessage = "Delete Successful";
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        public async Task<Acccount> Account_Login(AccountLogin_RequestData requestData)
        {
            var hashPassword = Security.ComputeSha256Hash(requestData.Password);
            return  _dbContext.account
                .Where(x => x.UserName == requestData.UserName 
                && x.Password == hashPassword)
                .FirstOrDefault();
        }

        public async Task<ReturnData> Account_Update(AccountUpdate_RequestData requestData)
        {
            var result = new ReturnData();
            try
            {
                var account = _dbContext.account.Where(x => x.AccountID == requestData.AccountID).FirstOrDefault();
                if (account == null)
                {
                    result.ResponseCode = -1;
                    result.ResponseMessage = "Account not found";
                    return result;
                }

                account.Address = requestData.Address;
                _dbContext.account.Update(account);
                //_dbContext.SaveChanges();


                result.ResponseCode = 1;
                result.ResponseMessage = "Update Successful";
                return result;

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }

}
