using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCoban.DataAccess.Netcore.EfCore;
using CSharpCoban.DataAccess.Netcore.IGenericRepositoy;
using CSharpCoban.DataAccess.Netcore.IRepository;

namespace CSharpCoban.DataAccess.Netcore.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IAccountRepository _accountRepository { get; set; }

        public IAccountGenericRepository _accountGenericRepository { get; set; }
        public CSharpCoBanDbContext _dbContext { get; set; }
        void SaveChanges();
        void Dispose();

    }
}
