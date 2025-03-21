using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCoBan.DataAccess.DO;
using CSharpCoBan.DataAccess.EntitesFrameWork;
using CSharpCoBan.DataAccess.Interface;

namespace CSharpCoBan.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        MyAppDbContext db = new MyAppDbContext();
        public List<User> GetList()
        {
            try
            {
                var u = db.user.ToList();

                return u;
            }
            catch (Exception)
            {

                throw;
            }
           

        }
    }
}
