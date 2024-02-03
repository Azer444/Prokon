using System.Threading.Tasks;
using Core;
using Manage.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<IdentityUser> userManager;

        public ManagerController(IUnitOfWork unitOfWork,
            UserManager<IdentityUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var admins = await unitOfWork.Admin.GetAdmins();
            return View(admins);
        }

        [HttpGet]
        public IActionResult Add_admin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_admin(ManagerAddAdminViewModel model)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            var user = new IdentityUser()
            {
                UserName = model.Username,
                NormalizedUserName = model.Username.ToUpper(),
                PasswordHash = hasher.HashPassword(null, model.Password),
            };

            var result = await userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
                return RedirectToAction("index", "manager");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_admin(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                ManagerEditAdminViewModel model = new ManagerEditAdminViewModel()
                {
                    Id = user.Id,
                    Username = user.UserName,
                };

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_admin(ManagerEditAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.Id);

                if (user != null)
                {
                    user.UserName = model.Username;
                    user.NormalizedUserName = model.Username.ToUpper();

                    if (model.Password != null)
                    {
                        var hasher = new PasswordHasher<IdentityUser>();
                        string passwordHash = hasher.HashPassword(null, model.Password);
                        user.PasswordHash = passwordHash;
                    }

                    var result = await userManager.UpdateAsync(user);

                    if (result.Succeeded)
                        return RedirectToAction("index", "manager");
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete_admin(string id)
        {
            if (id != null)
            {
                var user = await userManager.FindByIdAsync(id);

                if (user != null)
                {
                    var result = await userManager.DeleteAsync(user);

                    if (result.Succeeded)
                        return Ok();
                }
            }

            return NotFound();
        }
    }
}
