using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCoban.DataAccess.Netcore.DataObject;
using CSharpCoban.DataAccess.Netcore.IRepository;

namespace CSharpCoban.DataAccess.Netcore.Repository
{
    public class AccountRepository: IAccountRepository
    {
        public async Task<List<Acccount>> Acccounts_GetAll()
        {
            var list = new List<Acccount>();
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    list.Add(new Acccount { ID = i, UserName = "User" + i });
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }
    }
    
}
