using System.Threading.Tasks;
using Core;
using Core.Models;
using Manage.Areas.Admin.Models.ViewModels;
using Manage.Models;
using Manage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class EthicsHotlineController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public EthicsHotlineController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new EthicsHotlineIndexViewModel()
            {
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("ethics_hotline"),
                EthicsHotlineFormComponent = await unitOfWork.EthicsHotlineFormComponent.GetAsync(),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("ethics_hotline")
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("ethics_hotline");

            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto ethicsHotlineMainPhoto)
        {
            if (ModelState.IsValid)
            {
                ethicsHotlineMainPhoto.PhotoName = await fileService.UploadAsync(ethicsHotlineMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(ethicsHotlineMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "ethicshotline");
            }

            return View(ethicsHotlineMainPhoto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_main_photo(int? id)
        {
            if (id != null)
            {
                var mainPhoto = await unitOfWork.PageMainPhoto.GetAsync(id);

                if (mainPhoto != null)
                {
                    MainPhotoEditViewModel model = new MainPhotoEditViewModel()
                    {
                        Title_AZ = mainPhoto.Title_AZ,
                        Title_RU = mainPhoto.Title_RU,
                        Title_EN = mainPhoto.Title_EN,
                        Title_TR = mainPhoto.Title_TR,
                        PhotoName = mainPhoto.PhotoName
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_main_photo(MainPhotoEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("ethics_hotline");

                if (mainPhoto != null)
                {
                    if (model.Photo != null)
                    {
                        fileService.Delete(mainPhoto.PhotoName);
                        mainPhoto.PhotoName = await fileService.UploadAsync(model.Photo);
                    }

                    mainPhoto.Title_AZ = model.Title_AZ;
                    mainPhoto.Title_RU = model.Title_RU;
                    mainPhoto.Title_EN = model.Title_EN;
                    mainPhoto.Title_TR = model.Title_TR;

                    await unitOfWork.PageMainPhoto.EditAsync(mainPhoto);
                    await unitOfWork.CommitAsync();

                    return RedirectToAction("index", "ethicshotline");
                }

                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_form_component()
        {
            var formComponent = await unitOfWork.EthicsHotlineFormComponent.GetAsync();

            if (formComponent == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_form_component(EthicsHotlineFormComponent ethicsHotlineFormComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.EthicsHotlineFormComponent.CreateAsync(ethicsHotlineFormComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(ethicsHotlineFormComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_form_component()
        {
            var formComponent = await unitOfWork.EthicsHotlineFormComponent.GetAsync();

            if (formComponent != null)
                return View(formComponent);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_form_component(EthicsHotlineFormComponent ethicsHotlineFormComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.EthicsHotlineFormComponent.EditAsync(ethicsHotlineFormComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details_form_component", "ethicshotline");
            }

            return View(ethicsHotlineFormComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Details_form_component()
        {
            var formComponent = await unitOfWork.EthicsHotlineFormComponent.GetAsync();

            if (formComponent != null)
                return View(formComponent);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("ethics_hotline");

            if (pageAccessComponent == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_Page_Access_Component(PageAccessComponent pageAccessComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.PageAccessComponent.CreateAsync(pageAccessComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(pageAccessComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Page_Access_Component(int? id)
        {
            if (id != null)
            {
                var pageAccessComponent = await unitOfWork.PageAccessComponent.GetAsync(id);

                if (pageAccessComponent != null)
                    return View(pageAccessComponent);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Page_Access_Component(PageAccessComponent pageAccessComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.PageAccessComponent.EditAsync(pageAccessComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details_page_access_component", "ethicshotline", new { id = pageAccessComponent.Id });
            }

            return View(pageAccessComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Details_Page_Access_Component(int? id)
        {
            if (id != null)
            {
                var pageAccessComponent = await unitOfWork.PageAccessComponent.GetAsync(id);

                if (pageAccessComponent != null)
                    return View(pageAccessComponent);
            }

            return NotFound();
        }      
    }
}
