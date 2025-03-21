using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCoBan.DataAccess.DO;

namespace CSharpCoBan.DataAccess.Interface
{
    public interface IUserRepository
    {
         List<User> GetList();
    }
}
