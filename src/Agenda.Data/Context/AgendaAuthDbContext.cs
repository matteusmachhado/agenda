using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Data.Context
{
    public class AgendaAuthDbContext : IdentityDbContext
    {
        public AgendaAuthDbContext(DbContextOptions<AgendaAuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("tb_users");
            modelBuilder.Entity<IdentityRole>().ToTable("tb_roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("tb_userroles");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("tb_roleclaims");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("tb_userclaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("tb_userlogins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("tb_usertokens");

        }
    }
}
