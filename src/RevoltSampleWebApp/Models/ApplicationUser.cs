using Microsoft.AspNetCore.Identity;


namespace RevoltSampleWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ID1 { get; set; }
        public string ID2 { get; set; }
    }
}
