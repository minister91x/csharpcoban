using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCoban.DataAccess.Netcore.DataObject;

namespace CSharpCoban.DataAccess.Netcore.IRepository
{
    public interface IAccountRepository
    {
        Task<List<Acccount>> Acccounts_GetAll();
        Task<ReturnData> Account_Delete(AccountDelete_RequestData requestData);
        Task<ReturnData> Account_Update(AccountUpdate_RequestData requestData);

    }
}
