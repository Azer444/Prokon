using System.Threading.Tasks;
using Core;
using Core.Models;
using Manage.Areas.Admin.Models.ViewModels;
using Manage.Helpers;
using Manage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class ManagementController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public ManagementController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new ManagementIndexViewModel()
            {
                Managements = await unitOfWork.Management.GetAllAsync(),
                ManagementLayoutContent = await unitOfWork.SectionLayoutContent.GetByNameAsync("management")
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Management management)
        {
            if (ModelState.IsValid)
            {
                management.PhotoName = await fileService.UploadAsync(management.Photo);
                management.CreatedAt = AzDateTime.Now;

                await unitOfWork.Management.CreateAsync(management);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "management");
            }

            return View(management);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var management = await unitOfWork.Management.GetAsync(id);

                if (management != null)
                {
                    ManagementEditViewModel model = new ManagementEditViewModel()
                    {
                        Id = management.Id,
                        Name_AZ = management.Name_AZ,
                        Name_RU = management.Name_RU,
                        Name_EN = management.Name_EN,
                        Name_TR = management.Name_TR,
                        Duty_AZ = management.Duty_AZ,
                        Duty_RU = management.Duty_RU,
                        Duty_EN = management.Duty_EN,
                        Duty_TR = management.Duty_TR,
                        About_AZ = management.About_AZ,
                        About_RU = management.About_RU,
                        About_EN = management.About_EN,
                        About_TR = management.About_TR,
                        PhotoName = management.PhotoName
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ManagementEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var management = await unitOfWork.Management.GetAsync(model.Id);

                if (management != null)
                {
                    if (model.Photo != null)
                    {
                        fileService.Delete(management.PhotoName);

                        management.PhotoName = await fileService.UploadAsync(model.Photo);
                    }

                    management.Name_AZ = model.Name_AZ;
                    management.Name_RU = model.Name_RU;
                    management.Name_EN = model.Name_EN;
                    management.Name_TR = model.Name_TR;
                    management.Duty_AZ = model.Duty_AZ;
                    management.Duty_RU = model.Duty_RU;
                    management.Duty_EN = model.Duty_EN;
                    management.Duty_TR = model.Duty_TR;
                    management.About_AZ = model.About_AZ;
                    management.About_RU = model.About_RU;
                    management.About_EN = model.About_EN;
                    management.About_TR = model.About_TR;

                    await unitOfWork.Management.EditAsync(management);
                    await unitOfWork.CommitAsync();

                    return RedirectToAction("index", "management");
                }

                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var management = await unitOfWork.Management.GetAsync(id);

                if (management != null)
                {
                    return View(management);
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var management = await unitOfWork.PageMainPhoto.GetAsync(id);

                if (management != null)
                {
                    fileService.Delete(management.PhotoName);

                    await unitOfWork.Management.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_Section_Layout_Content()
        {
            var sectionLayoutContent = await unitOfWork.SectionLayoutContent.GetByNameAsync("management");

            if (sectionLayoutContent == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_Section_Layout_Content(SectionLayoutContent sectionLayoutContent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.SectionLayoutContent.CreateAsync(sectionLayoutContent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(sectionLayoutContent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Section_Layout_Content()
        {
            var sectionLayoutContent = await unitOfWork.SectionLayoutContent.GetByNameAsync("management");

            if (sectionLayoutContent != null)
                return View(sectionLayoutContent);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Section_Layout_Content(SectionLayoutContent sectionLayoutContent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.SectionLayoutContent.EditAsync(sectionLayoutContent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(sectionLayoutContent);
        }

        [HttpGet]
        public async Task<IActionResult> Detail_Section_Layout_Content()
        {
            var sectionLayoutContent = await unitOfWork.SectionLayoutContent.GetByNameAsync("management");

            if (sectionLayoutContent != null)
                return View(sectionLayoutContent);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_Section_Layout_Content(int? id)
        {
            if (id != null)
            {
                var sectionLayoutContent = await unitOfWork.SectionLayoutContent.GetAsync(id);

                if (sectionLayoutContent != null)
                {
                    await unitOfWork.SectionLayoutContent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }
    }
}
