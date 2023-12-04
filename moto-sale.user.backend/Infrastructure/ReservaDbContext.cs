using motosale.user.backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using billkill.payment.service.Models;

namespace motosale.user.backend.Infrastructure
{
    public class ReservaDbContext: IdentityDbContext<USER, USER_ROLE, int>
    {
        public ReservaDbContext()
        {
        }

        public ReservaDbContext(DbContextOptions<ReservaDbContext> options)
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
        public DbSet<COMPANY_EMPLOYEE> company_employee { get; set; }
    }
}
