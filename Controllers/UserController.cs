using Library.Models;
using Library.Models.ViewModel;
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
    public class UserController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private IPasswordHasher<AppUser> passwordHasher;
        private IConfiguration configuration;

        public UserController(
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

        [HttpPost("Create")]
        public async Task<JsonResult> CreateUser([FromBody] UserViewModel model)
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

        [HttpDelete("DeleteUser")]
        public async Task<JsonResult> DeleteUser(UserViewModel model)
        {
            AppUser user = await userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                IdentityResult removeFromRoleResult = await userManager.RemoveFromRoleAsync(
                    user, configuration["Data:UserRole:User"]);
                if (removeFromRoleResult.Succeeded)
                {
                    IdentityResult deleteResult = await userManager.DeleteAsync(user);
                    if (deleteResult.Succeeded)
                    {
                        return Json(true);
                    }
                    return Json(false);
                }
                return Json(false);
            }
            return Json(false);
        }
    }
}
