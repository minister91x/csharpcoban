using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCoBan.DataAccess.DO;

namespace CSharpCoBan.DataAccess.EntitesFrameWork
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext() : base("MyAppDbConnectionString")
        {
            // Chỗ này đi là đi tìm connectionstring có tên là MyAppDbConnectionString
            // trong file App.config
        }
        public virtual DbSet<User> user { get; set; }
    }
}
