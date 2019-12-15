using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private IPasswordHasher<AppUser> passwordHasher;
        private IConfiguration configuration;

        public TestController(
            UserManager<AppUser> userMgr,
            SignInManager<AppUser> signInMgr,
            IPasswordHasher<AppUser> hasher,
            IConfiguration config)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            passwordHasher = hasher;
            configuration = config;
        }

        [HttpPost]
        public async Task<JsonResult> CreateUser(AppUser user)
        {
            if (user != null)
            {
                IdentityResult result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    return Json(true);
                }
            }
            return Json("Należy przesłać użytkownika.");
        }

        [HttpGet]
        public IQueryable<AppUser> UserList() => userManager.Users;


    }
}
