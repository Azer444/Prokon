using System.Threading.Tasks;
using Core;
using Core.Models;
using Manage.Areas.Admin.Models.ViewModels;
using Manage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class AboutController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public AboutController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AboutIndexViewModel model = new AboutIndexViewModel()
            {
                AboutMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("about"),
                AboutComponent = await unitOfWork.AboutComponent.GetAsync(),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("about")
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("about");
            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto aboutMainPhoto)
        {
            if (ModelState.IsValid)
            {
                aboutMainPhoto.PhotoName = await fileService.UploadAsync(aboutMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(aboutMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "about");
            }

            return View(aboutMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("about");

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

                    return RedirectToAction("index", "about");
                }

                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_Component()
        {
            var aboutComponent = await unitOfWork.AboutComponent.GetAsync();

            if (aboutComponent == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_Component(AboutComponent aboutComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.AboutComponent.CreateAsync(aboutComponent);
                await unitOfWork.CommitAsync();

                foreach (var photo in aboutComponent.Photos)
                {
                    var aboutPhoto = new AboutPhoto()
                    {
                        AboutComponentId = aboutComponent.Id,
                        PhotoName = await fileService.UploadAsync(photo)
                    };

                    await unitOfWork.AboutPhoto.CreateAsync(aboutPhoto);
                    await unitOfWork.CommitAsync();
                }

                return RedirectToAction("index", "about");
            }

            return View(aboutComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Component()
        {
            var aboutComponent = await unitOfWork.AboutComponent.GetAsync();

            if (aboutComponent != null)
                return View(aboutComponent);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Component(AboutComponent aboutComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.AboutComponent.EditAsync(aboutComponent);
                await unitOfWork.CommitAsync();

                foreach (var photo in aboutComponent.Photos)
                {
                    var aboutPhoto = new AboutPhoto()
                    {
                        AboutComponentId = aboutComponent.Id,
                        PhotoName = await fileService.UploadAsync(photo)
                    };

                    await unitOfWork.AboutPhoto.CreateAsync(aboutPhoto);
                    await unitOfWork.CommitAsync();
                }

                return RedirectToAction("index", "about");
            }

            return View(aboutComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Details_Component()
        {
            var aboutComponent = await unitOfWork.AboutComponent.GetAsync();
            if (aboutComponent != null)
                return View(aboutComponent);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_photo(int? id)
        {
            if (id != null)
            {
                var aboutPhoto = await unitOfWork.AboutPhoto.GetAsync(id);
                if (aboutPhoto != null)
                {
                    fileService.Delete(aboutPhoto.PhotoName);

                    await unitOfWork.AboutPhoto.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("about");
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

                return RedirectToAction("details_page_access_component", "about", new { id = pageAccessComponent.Id });
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
