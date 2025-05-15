using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCoban.DataAccess.Netcore.DataObject;

namespace CSharpCoban.DataAccess.Netcore.IRepository
{
    public interface IFunctionRepository
    {
        Task<Function> GetFunctionByCode(string functionCode);
    }
}
