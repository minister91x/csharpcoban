using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCoban.DataAccess.Netcore.Dapper;
using CSharpCoban.DataAccess.Netcore.DataObject;
using CSharpCoban.DataAccess.Netcore.IRepository;
using Dapper;

namespace CSharpCoban.DataAccess.Netcore.Repository
{
    public class AccountRepositoryDapper : BaseApplicationService, IAccountRepositoryDapper
    {
        public AccountRepositoryDapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<List<Acccount>> Acccounts_GetAll(Acccounts_GetAllRequestDataa requestDataa)
        {
            var list = new List<Acccount>();
            try
            {
                var param = new DynamicParameters();
                param.Add("@AccountID", requestDataa.AccountId);
                list = await DbConnection.QueryAsync<Acccount>("SP_Account_GetList", param);
                return list;
            }
            catch (Exception exx)
            {

                throw;
            }
        }
    }
}
