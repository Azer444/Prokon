using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Models;
using Manage.Areas.Admin.Models.ViewModels;
using Manage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class PressController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public PressController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new PressIndexViewModel()
            {
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("press"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("press"),
                ContentAccessComponent = await unitOfWork.ContentAccessComponent.GetByPageNameAsync("press")
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("press");

            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto pressMainPhoto)
        {
            if (ModelState.IsValid)
            {
                pressMainPhoto.PhotoName = await fileService.UploadAsync(pressMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(pressMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "press");
            }

            return View(pressMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("press");

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

                    return RedirectToAction("index", "press");
                }

                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("press");

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

                return RedirectToAction("details_page_access_component", "press", new { id = pageAccessComponent.Id });
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
        public async Task<IActionResult> Define_Content_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.ContentAccessComponent.GetByPageNameAsync("news");

            if (pageAccessComponent == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_Content_Access_Component(ContentAccessComponent contentAccessComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.ContentAccessComponent.CreateAsync(contentAccessComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(contentAccessComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Content_Access_Component(int? id)
        {
            if (id != null)
            {
                var contentAccessComponent = await unitOfWork.ContentAccessComponent.GetAsync(id);

                if (contentAccessComponent != null)
                    return View(contentAccessComponent);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Content_Access_Component(ContentAccessComponent contentAccessComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.ContentAccessComponent.EditAsync(contentAccessComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details_content_access_component", "press", new { id = contentAccessComponent.Id });
            }

            return View(contentAccessComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Details_Content_Access_Component(int? id)
        {
            if (id != null)
            {
                var contentAccessComponent = await unitOfWork.ContentAccessComponent.GetAsync(id);

                if (contentAccessComponent != null)
                    return View(contentAccessComponent);
            }

            return NotFound();
        }
    }
}
