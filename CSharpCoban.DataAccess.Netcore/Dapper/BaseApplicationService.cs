using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpCoban.DataAccess.Netcore.Dapper
{
    public class BaseApplicationService
    {
        public BaseApplicationService(IServiceProvider serviceProvider)
        {
            DbConnection = serviceProvider.GetRequiredService<IApplicationDbConnection>(); ;
        }

        protected IApplicationDbConnection DbConnection { get; }

    }
}
