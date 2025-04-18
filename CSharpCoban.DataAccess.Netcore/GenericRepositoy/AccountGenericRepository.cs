using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCoban.DataAccess.Netcore.DataObject;
using CSharpCoban.DataAccess.Netcore.EfCore;
using CSharpCoban.DataAccess.Netcore.IGenericRepositoy;
using CSharpCoban.DataAccess.Netcore.IRepository;

namespace CSharpCoban.DataAccess.Netcore.GenericRepositoy
{
    public class AccountGenericRepository : GenericRepositoy<Acccount>, IAccountGenericRepository
    {
        public AccountGenericRepository(CSharpCoBanDbContext dbContext) : base(dbContext)
        {
        }
    }
}
