using motosale.user.backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using billkill.payment.service.Models;
using moto.sale.user.backend.Models;

namespace motosale.user.backend.Infrastructure
{
    public class MotoSaleDbContext: IdentityDbContext<USER, USER_ROLE, int>
    {
        public MotoSaleDbContext()
        {
        }

        public MotoSaleDbContext(DbContextOptions<MotoSaleDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<USER>(b =>
            {
                b.ToTable("user");
            });

            builder.Entity<USER_ROLE>(b =>
            {
                b.ToTable("user_role");
            });
        }

        public DbSet<USER> user { get; set; }
        public DbSet<USER_ROLE> user_role { get; set; }
        public DbSet<CLIENT> client { get; set; }
        public DbSet<PRODUCT> product { get; set; }
        public DbSet<BRAND> brand { get; set; }
        public DbSet<BLOG> blog { get; set; }
        public DbSet<CATEGORY> category { get; set; }
        public DbSet<EMPLOYEE> employee { get; set; }
        public DbSet<STATIC_DATA> static_data { get; set; }


    }
}
