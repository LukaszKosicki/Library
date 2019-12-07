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
        public async Task<JsonResult> CreateUser(UserViewModel model)
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
                    return Json(true);
                }
            }
            return Json(false);
        }

        [HttpGet("UserList")]
        public JsonResult UserList()
        {
            IQueryable<AppUser> appUsers = userManager.Users;

            JsonResult json = new JsonResult(appUsers);

            return json;
        }

        [HttpPatch("EditUser")]
        public async Task<JsonResult> EditUser(UserViewModel model)
        {
            if (model != null)
            {
                AppUser user = await userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.Addres = model.Address;
                    user.PasswordHash = passwordHasher.HashPassword(user, model.Password);

                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return Json(true);
                    }
                }
                return Json(false);
            }
            return Json(false);
        }
    }
}
