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

            modelBuilder.Entity<IdentityUser>().ToTable("tb_user");
            modelBuilder.Entity<IdentityRole>().ToTable("tb_role");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("tb_userrole");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("tb_roleclaim");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("tb_userclaim");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("tb_userlogin");
        }
    }
}
