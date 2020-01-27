using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace RevoltSampleWebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateController : ControllerBase
    {
        private readonly UserManager<Models.ApplicationUser> userManager;
        private readonly Models.RandomWordFactory randomWordFactory;

        public GenerateController(UserManager<Models.ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.randomWordFactory = new Models.RandomWordFactory();
        }
        // GET: api/Generate
        [HttpGet]
        public async Task<bool> Get()
        {
            IList<Models.ApplicationUser> users = userManager.Users.ToList();
            randomWordFactory.GenerateWords((uint)users.Count * (uint)2);

            foreach (var user in users)
            {
                user.ID1 = randomWordFactory.Words.Pop();
                user.ID2 = randomWordFactory.Words.Pop();
                await userManager.UpdateAsync(user);
            }

            return true;
        }
    }
}
