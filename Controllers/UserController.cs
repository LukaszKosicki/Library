using Library.Models;
using Library.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signIn;
        private IPasswordHasher<AppUser> passwordHasher;

        public UserController(
            UserManager<AppUser> userMgr,
            SignInManager<AppUser> signInMgr,
            IPasswordHasher<AppUser> hasher)
        {
            userManager = userMgr;
            signIn = signInMgr;
            passwordHasher = hasher;
        }

        [HttpPost("Create")]
        public async Task<bool> CreateUser(UserViewModel model)
        {
            if (model != null)
            {
                AppUser user = new AppUser
                {
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                    Addres = model.Address
                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
