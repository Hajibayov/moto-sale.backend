using motosale.user.backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using billkill.payment.service.Models;
using moto.sale.user.backend.Models;
using System.Reflection.Emit;

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
            builder.HasDefaultSchema("students");

            builder.Entity<USER>(b =>
            {
                b.ToTable("sh_user");
            });

            builder.Entity<USER_ROLE>(b =>
            {
                b.ToTable("sh_user_role");
            });
        }

        public DbSet<USER> sh_user { get; set; }
        public DbSet<USER_ROLE> sh_user_role { get; set; }
        public DbSet<CLIENT> sh_client { get; set; }
        public DbSet<PRODUCT> sh_product { get; set; }
        public DbSet<BRAND> sh_brand { get; set; }
        public DbSet<BLOG> sh_blog { get; set; }
        public DbSet<CATEGORY> sh_category { get; set; }
        public DbSet<EMPLOYEE> sh_employee { get; set; }


    }
}
