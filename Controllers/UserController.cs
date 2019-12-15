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

        [HttpPost]
        public async Task<JsonResult> CreateUser([FromBody]UserViewModel model)
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
                    return Json(new { Msg = "Utworzono użytkownika", CreateResult = true });
                }
            }
            return Json(new { Msg = "Nie udało się utworzyć użytkownika", CreateResult = false});
        }

        [HttpGet]
        public IQueryable<AppUser> UserList() => userManager.Users;

        [HttpGet("{id}")]
        public async Task<JsonResult> UserBack(string id)
        {
            if (id != null)
            {
                AppUser user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    return Json(new { user, Result = true });
                }
                return Json(new { Msg = "Użytkownik o danym id nie istnieje.", Result = false });
            }
            return Json(new { Msg = "Nie podano id użytkownika.", Result = false });
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteUser(string id)
        {
            if (id != null)
            {
                AppUser user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    IdentityResult deleteResult = await userManager.DeleteAsync(user);
                    if (deleteResult.Succeeded)
                    {
                        return Json(new { Msg = "Usunięto użytkownika z bazy.", DeleteResult = true });
                    }
                    return Json(new { Msg = "Nie udało się usunąć użytkownika.", DeleteResult = false });
                }
                return Json(new { Msg = "Nie znaleziono użytkownika w bazie.", DeleteResult = false });
            }
            return Json(new { Msg = "Nie podano id użytkownika.", DeleteResult = false });
        }

        [HttpPatch]
        public async Task<JsonResult> EditUser([FromBody]UserViewModel model)
        {
            if (model.Id != null)
            {
                AppUser user = await userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    if (passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.OldPassword)
                        == PasswordVerificationResult.Success)
                    {
                        user.Email = model.Email;
                        user.Name = model.Name;
                        user.Surname = model.Surname;
                        user.Addres = model.Address;
                        user.PasswordHash = passwordHasher.HashPassword(user, model.Password);
                    }

                    IdentityResult updateResult = await userManager.UpdateAsync(user);
                    if (updateResult.Succeeded)
                    {
                        return Json(new { Msg = "Dane użytkownika zostały zaktualizowane.", UpdateResult = true });
                    }
                    return Json(new { Msg = "Podane hasło jest nie prawidłowe.", UpdateResult = false });
                }
                return Json(new { Msg = "Nie znaleziono użytkownika w bazie.", UpdateResult = false });
            }
            return Json(new { Msg = "Nie przekazano użytkownika.", UpdateResult = false });
        }
    }
}
