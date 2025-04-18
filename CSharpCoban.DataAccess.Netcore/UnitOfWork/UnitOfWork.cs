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
    public class UnitOfWork : IUnitOfWork
    {
        public IAccountRepository _accountRepository { get; set; }
        public CSharpCoBanDbContext _dbContext { get; set; }
        public IAccountGenericRepository _accountGenericRepository { get; set; }

        public UnitOfWork(IAccountRepository accountRepository, CSharpCoBanDbContext dbContext, IAccountGenericRepository accountGenericRepository)
        {
            _accountRepository = accountRepository;
            _accountGenericRepository = accountGenericRepository;
            _dbContext = dbContext;
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

