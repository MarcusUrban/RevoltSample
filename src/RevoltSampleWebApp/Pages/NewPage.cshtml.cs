using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RevoltSampleWebApp.Data;

namespace RevoltSampleWebApp
{
    public class NewPageModel : PageModel
    {
        private readonly UserManager<Models.ApplicationUser> userManager;
        private readonly ApplicationDbContext applicationDbContext;

        public NewPageModel(UserManager<Models.ApplicationUser> userManager, ApplicationDbContext applicationDbContext)
        {
            this.userManager = userManager;
            this.applicationDbContext = applicationDbContext;
        }

        public void OnGet()
        {
            string id1 = RouteData.Values["ID1"].ToString();
            string id2 = RouteData.Values["ID2"].ToString();
            if (String.IsNullOrWhiteSpace(id1) || String.IsNullOrWhiteSpace(id2))
                return;

            Models.ApplicationUser user = userManager.Users.FirstOrDefault<Models.ApplicationUser>(x => x.ID1 == id1 && x.ID2 == id2);
            if (user == null)
                return;

            applicationDbContext.Activities.Add(new Models.Activity() { ActivityId = Guid.NewGuid().ToString(), ApplicationUserID = user.Id, Timestamp = DateTime.Now });
            applicationDbContext.SaveChangesAsync();

        }

    }
}