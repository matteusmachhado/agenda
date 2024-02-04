using Agenda.Entities.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Agenda.Data.Context
{
    public class AgendaAuthDbContext : IdentityDbContext
    {
        private readonly UserDefault _userDefault;

        public AgendaAuthDbContext(DbContextOptions<AgendaAuthDbContext> options,
            IOptions<UserDefault> userDefault
            ) : base(options) 
        {
            _userDefault = userDefault.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

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

            SeedUserDefault(modelBuilder);
        }

        private void SeedUserDefault(ModelBuilder builder)
        {
            var userAdmin = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = _userDefault.Email,
                NormalizedUserName = _userDefault.Email.ToUpper(),
                Email = _userDefault.Email,
                NormalizedEmail = _userDefault.Email.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = true,
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            userAdmin.PasswordHash = passwordHasher.HashPassword(userAdmin, _userDefault.Password);

            builder.Entity<IdentityUser>().HasData(userAdmin);

            var roleAdmin = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" };

            builder.Entity<IdentityRole>().HasData(roleAdmin);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>() { RoleId = roleAdmin.Id, UserId = userAdmin.Id });
        }
    }
}
