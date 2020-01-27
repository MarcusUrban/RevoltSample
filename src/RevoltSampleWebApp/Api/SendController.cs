using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RevoltSampleWebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        private readonly UserManager<Models.ApplicationUser> userManager;
        private readonly Models.EmailFactory emailFactory;

        public SendController(UserManager<Models.ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.emailFactory = new Models.EmailFactory();
        }
        // GET: api/Send
        [HttpGet]
        public bool Get()
        {
            var users = userManager.Users;
            foreach (var user in users)
            {
                SendEmail(user);
            }
            return true;
        }

        void SendEmail(Models.ApplicationUser user)
        {
            string emailAddress = user.Email;
            emailFactory.SendEmail(user.Email, user.ID1, user.ID2);
        }
    }
}
