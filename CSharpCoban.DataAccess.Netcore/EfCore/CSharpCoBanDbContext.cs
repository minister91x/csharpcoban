using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCoban.DataAccess.Netcore.DataObject;
using Microsoft.EntityFrameworkCore;

namespace CSharpCoban.DataAccess.Netcore.EfCore
{
    public class CSharpCoBanDbContext : DbContext
    {
        public CSharpCoBanDbContext(DbContextOptions<CSharpCoBanDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Acccount> account { get; set; } = null!;
    }
}
