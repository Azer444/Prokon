using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manage.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Change_Password()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Change_Password(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);

                if (user != null)
                {
                    var hasher = new PasswordHasher<IdentityUser>();

                    var isCorrect = hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

                    if (isCorrect == PasswordVerificationResult.Success)
                    {
                        user.PasswordHash = hasher.HashPassword(null, model.NewPassword);

                        var result = await userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("index", "pages");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Password is not correct.");
                    }

                }
            }

            return View(model);
        }
    }
}
