using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RevoltSampleWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevoltSampleWebApp.Models
{
    public static class DefaultUsers
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@testing.cz").Result == null)
            {
                var adminUser = new Models.ApplicationUser
                {
                    UserName = "admin@testing.cz",
                    Email = "admin@testing.cz",
                    EmailConfirmed = true,
                };

                IdentityResult result = userManager.CreateAsync(adminUser, "Admin12.").Result;
            }
            if (userManager.FindByEmailAsync("manager@testing.cz").Result == null)
            {
                var managerUser = new Models.ApplicationUser
                {
                    UserName = "manager@testing.cz",
                    Email = "manager@testing.cz",
                    EmailConfirmed = true,
                };

                IdentityResult result = userManager.CreateAsync(managerUser, "Manager12.").Result;
            }
        }
    }
}
