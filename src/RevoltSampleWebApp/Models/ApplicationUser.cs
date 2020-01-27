using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace RevoltSampleWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
            Activities = new List<Activity>();
        }

        public string ID1 { get; set; }
        public string ID2 { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
