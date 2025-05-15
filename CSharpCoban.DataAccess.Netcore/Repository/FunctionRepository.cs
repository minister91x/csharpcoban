using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCoban.DataAccess.Netcore.DataObject;
using CSharpCoban.DataAccess.Netcore.EfCore;
using CSharpCoban.DataAccess.Netcore.IRepository;

namespace CSharpCoban.DataAccess.Netcore.Repository
{
    public class FunctionRepository : IFunctionRepository
    {
        public readonly CSharpCoBanDbContext _dbContext;
        public FunctionRepository(CSharpCoBanDbContext dbContext)

        {
            _dbContext = dbContext;
        }

        public async Task<Function> GetFunctionByCode(string functionCode)
        {
          return  _dbContext.function.Where(x => x.FuctionCode == functionCode).FirstOrDefault();
        }
    }

}
