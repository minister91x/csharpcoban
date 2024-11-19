using CSharpCoBan.DataAccess.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess.Interface
{
    public interface IAccountRepository
    {
        int Login(string username, string password);
        int Account_Insert(AccountDTO accountDTO);
    }
}
