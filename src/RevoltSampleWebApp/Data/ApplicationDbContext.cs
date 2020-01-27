using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RevoltSampleWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Models.ApplicationUser>
    {
        public DbSet<Models.Activity> Activities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminUser = new Models.ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Admin",
                NormalizedUserName = "Admin".ToUpper(),
                Email = "admin@testing.cz",
                NormalizedEmail = "admin@testing.cz".ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()

            };

            var managerUser = new Models.ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Manager",
                NormalizedUserName = "Manager".ToUpper(),
                Email = "manager@testing.cz",
                NormalizedEmail = "manager@testing.cz".ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var hashGenerator = new PasswordHasher<Models.ApplicationUser>();
            adminUser.PasswordHash = hashGenerator.HashPassword(adminUser, "Admin12.");
            managerUser.PasswordHash = hashGenerator.HashPassword(managerUser, "Manager12.");

            builder.Entity<Models.ApplicationUser>().HasData(
                    adminUser,
                    managerUser
                );

        }
    }
}
