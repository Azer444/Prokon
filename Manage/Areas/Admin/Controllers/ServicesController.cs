using Core;
using Core.Models;
using Manage.Areas.Admin.Models.ViewModels;
using Manage.Helpers;
using Manage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class ServicesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public ServicesController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ServicesIndexViewModel model = new ServicesIndexViewModel()
            {
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("services"),
                ServicesComponents = await unitOfWork.ServicesComponent.GetAllAsync(),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("services")
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("services");
            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto servicesMainPhoto)
        {
            if (ModelState.IsValid)
            {
                servicesMainPhoto.PhotoName = await fileService.UploadAsync(servicesMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(servicesMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "services");
            }

            return View(servicesMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("services");
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

                    return RedirectToAction("index", "services");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Add_component()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_component(ServicesComponent servicesComponent)
        {
            if (ModelState.IsValid)
            {
                servicesComponent.CreatedAt = AzDateTime.Now;

                await unitOfWork.ServicesComponent.CreateAsync(servicesComponent);
                await unitOfWork.CommitAsync();

                foreach (var photo in servicesComponent.Photos)
                {
                    var servicesComponentPhoto = new ServicesComponentPhoto
                    {
                        PhotoName = await fileService.UploadAsync(photo),
                        ServicesComponentId = servicesComponent.Id
                    };

                    await unitOfWork.ServicesComponentPhoto.CreateAsync(servicesComponentPhoto);
                    await unitOfWork.CommitAsync();
                }

                return RedirectToAction("index", "services");
            }

            ViewBag.ServicesCount = await unitOfWork.ServicesComponent.GetCountAsync();
            return View(servicesComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_component(int? id)
        {
            if (id != null)
            {
                var servicesComponent = await unitOfWork.ServicesComponent.GetAsync(id);
                if (servicesComponent != null)
                {
                    ViewBag.ServicesCount = await unitOfWork.ServicesComponent.GetCountAsync();

                    ServicesComponentEditViewModel model = new ServicesComponentEditViewModel()
                    {
                        Id = servicesComponent.Id,
                        Title_AZ = servicesComponent.Title_AZ,
                        Title_RU = servicesComponent.Title_RU,
                        Title_EN = servicesComponent.Title_EN,
                        Title_TR = servicesComponent.Title_TR,
                        Content_AZ = servicesComponent.Content_AZ,
                        Content_RU = servicesComponent.Content_RU,
                        Content_EN = servicesComponent.Content_EN,
                        Content_TR = servicesComponent.Content_TR,
                        ServicesComponentPhotos = servicesComponent.ServicesComponentPhotos
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_component(ServicesComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var servicesComponent = await unitOfWork.ServicesComponent.GetAsync(model.Id);
                if (servicesComponent != null)
                {
                    servicesComponent.Title_AZ = model.Title_AZ;
                    servicesComponent.Title_RU = model.Title_RU;
                    servicesComponent.Title_EN = model.Title_EN;
                    servicesComponent.Title_TR = model.Title_TR;
                    servicesComponent.Content_AZ = model.Content_AZ;
                    servicesComponent.Content_RU = model.Content_RU;
                    servicesComponent.Content_EN = model.Content_EN;
                    servicesComponent.Content_TR = model.Content_TR;

                    await unitOfWork.ServicesComponent.EditAsync(servicesComponent);
                    await unitOfWork.CommitAsync();

                    foreach (var photo in model.Photos)
                    {
                        var servicesComponentPhoto = new ServicesComponentPhoto
                        {
                            PhotoName = await fileService.UploadAsync(photo),
                            ServicesComponentId = servicesComponent.Id
                        };

                        await unitOfWork.ServicesComponentPhoto.CreateAsync(servicesComponentPhoto);
                        await unitOfWork.CommitAsync();
                    }

                    return RedirectToAction("details_component", "services", new { id = servicesComponent.Id });
                }

            }

            ViewBag.ServicesCount = await unitOfWork.ServicesComponent.GetCountAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details_component(int? id)
        {
            if (id != null)
            {
                var servicesComponent = await unitOfWork.ServicesComponent.GetAsync(id);
                if (servicesComponent != null)
                    return View(servicesComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_component(int? id)
        {
            if (id != null)
            {
                var servicesComponent = await unitOfWork.ServicesComponent.GetAsync(id);
                if (servicesComponent != null)
                {
                    foreach (var servicesComponentPhoto in servicesComponent.ServicesComponentPhotos)
                    {
                        fileService.Delete(servicesComponentPhoto.PhotoName);
                    }

                    await unitOfWork.ServicesComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> Delete_component_photo(int? id)
        {
            if (id != null)
            {
                var servicesComponentPhoto = await unitOfWork.ServicesComponentPhoto.GetAsync(id);
                if (servicesComponentPhoto != null)
                {
                    fileService.Delete(servicesComponentPhoto.PhotoName);

                    await unitOfWork.ServicesComponentPhoto.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("services");
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

                return RedirectToAction("details_page_access_component", "services", new { id = pageAccessComponent.Id });
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
