using Library.Models;
using Library.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<AppUser> userMgr,
            SignInManager<AppUser> signInMgr, RoleManager<IdentityRole> roleMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            roleManager = roleMgr;
        }

        [HttpPost]
        public async Task<JsonResult> LoginUser([FromBody]LoginViewModel model)
        {
            AppUser user = await userManager.FindByEmailAsync(model.Email);
            
            if (user != null)
            {
                Microsoft.AspNetCore.Identity.SignInResult signInResult =
                    await signInManager.PasswordSignInAsync(user, model.Password, true, false);
                if (signInResult.Succeeded)
                {
                    return Json(new { Msg = "Zalogowano pomyślnie.", SignInResult = true, user = new { UserName = user.UserName,
                        role = user.UserName == "Admin" ? "admin" : "user" } });
                }
                return Json(new { Msg = "Błędna nazwa użytkownika lub hasło.", SignInResult = false });
            }
            return Json(new { Msg = "Nie znaleziono użytkownika.", SignInResult = false });
        }

        // komentarz

    }
}
