using System.Collections.Generic;
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
    public class GalleryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public GalleryController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Page()
        {
            var model = new GalleryPageViewModel()
            {
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("gallery"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("gallery")
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("gallery");

            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto galleryMainPhoto)
        {
            if (ModelState.IsValid)
            {
                galleryMainPhoto.PhotoName = await fileService.UploadAsync(galleryMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(galleryMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("page");
            }

            return View(galleryMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("gallery");

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

                    return RedirectToAction("page");
                }

                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("gallery");

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

                return RedirectToAction("page");
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

                return RedirectToAction("details_page_access_component", "gallery", new { id = pageAccessComponent.Id });
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var galleryComponents = await unitOfWork.GalleryComponent.GetAllAsync();
            return View(galleryComponents);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Orders = await unitOfWork.GalleryComponent.GetEmptyOrdersAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(GalleryComponent galleryComponent)
        {
            if (ModelState.IsValid)
            {
                if (galleryComponent.TitlePhoto != null)
                    galleryComponent.TitlePhotoName = await fileService.UploadAsync(galleryComponent.TitlePhoto);

                await unitOfWork.GalleryComponent.CreateAsync(galleryComponent);
                await unitOfWork.CommitAsync();

                foreach (var photo in galleryComponent.Photos)
                {
                    var photo_ = new GalleryComponentPhoto()
                    {
                        PhotoName = await fileService.UploadAsync(photo),
                        GalleryComponentId = galleryComponent.Id
                    };

                    await unitOfWork.GalleryComponentPhoto.CreateAsync(photo_);
                    await unitOfWork.CommitAsync();
                }


                return RedirectToAction("index");
            }

            return View(galleryComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var galleryComponent = await unitOfWork.GalleryComponent.GetAsync(id);

                if (galleryComponent != null)
                    return View(galleryComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var galleryComponent = await unitOfWork.GalleryComponent.GetAsync(id);
                if (galleryComponent != null)
                {
                    ViewBag.Orders = await unitOfWork.GalleryComponent.GetEmptyOrdersAsync(galleryComponent);

                    GalleryComponentEditViewModel model = new GalleryComponentEditViewModel()
                    {
                        Title_AZ = galleryComponent.Title_AZ,
                        Title_RU = galleryComponent.Title_RU,
                        Title_EN = galleryComponent.Title_EN,
                        Title_TR = galleryComponent.Title_TR,
                        Date = galleryComponent.Date,
                        TitlePhotoName = galleryComponent.TitlePhotoName,
                        GalleryComponentPhotos = galleryComponent.GalleryComponentPhotos,
                        ShowOnHomePage = galleryComponent.ShowOnHomePage,
                        Order = galleryComponent.Order
                    };

                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GalleryComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var galleryComponent = await unitOfWork.GalleryComponent.GetAsync(model.Id);
                if (galleryComponent != null)
                {
                    if (model.TitlePhoto != null)
                    {
                        fileService.Delete(galleryComponent.TitlePhotoName);
                        galleryComponent.TitlePhotoName = await fileService.UploadAsync(model.TitlePhoto);
                    }

                    foreach (var photo in model.Photos)
                    {
                        var photo_ = new GalleryComponentPhoto()
                        {
                            PhotoName = await fileService.UploadAsync(photo),
                            GalleryComponentId = galleryComponent.Id
                        };

                        await unitOfWork.GalleryComponentPhoto.CreateAsync(photo_);
                        await unitOfWork.CommitAsync();
                    }

                    galleryComponent.Title_AZ = model.Title_AZ;
                    galleryComponent.Title_RU = model.Title_RU;
                    galleryComponent.Title_EN = model.Title_EN;
                    galleryComponent.Title_TR = model.Title_TR;
                    galleryComponent.Date = model.Date;
                    galleryComponent.ShowOnHomePage = model.ShowOnHomePage;
                    galleryComponent.Order = model.Order;

                    await unitOfWork.GalleryComponent.EditAsync(galleryComponent);
                    await unitOfWork.CommitAsync();

                    return RedirectToAction("index");
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var galleryComponent = await unitOfWork.GalleryComponent.GetAsync(id);
                if (galleryComponent != null)
                {
                    if (galleryComponent.ProjectId == null)
                    {
                        fileService.Delete(galleryComponent.TitlePhotoName);
                        foreach (var galleryComponentPhoto in galleryComponent.GalleryComponentPhotos)
                        {
                            fileService.Delete(galleryComponentPhoto.PhotoName);
                        }
                    }

                    await unitOfWork.GalleryComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_gallery_component_photo(int? id)
        {
            if (id != null)
            {
                var galleryComponentPhoto = await unitOfWork.GalleryComponentPhoto.GetAsync(id);
                if (galleryComponentPhoto != null)
                {
                    if (galleryComponentPhoto.GalleryComponent.ProjectId == null)
                        fileService.Delete(galleryComponentPhoto.PhotoName);

                    await unitOfWork.GalleryComponentPhoto.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }
    }
}
