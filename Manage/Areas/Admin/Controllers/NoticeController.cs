﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    public class NoticeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public NoticeController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new NoticeIndexViewModel
            {
                NoticeMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("notice"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("notice"),
                NoticeComponent = await unitOfWork.NoticeComponent.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("notice");
            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto noticeMainPhoto)
        {
            if (ModelState.IsValid)
            {
                noticeMainPhoto.PhotoName = await fileService.UploadAsync(noticeMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(noticeMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(noticeMainPhoto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_main_photo(int? id)
        {
            if (id != null)
            {
                var mainPhoto = await unitOfWork.PageMainPhoto.GetAsync(id);
                if (mainPhoto != null)
                {
                    MainPhotoEditViewModel model = new MainPhotoEditViewModel
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("notice");
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

                    return RedirectToAction("index");
                }

                return NotFound();

            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Define_Component()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Define_Component(NoticeComponent noticeComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.NoticeComponent.CreateAsync(noticeComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(noticeComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Component()
        {
            var noticeComponent = await unitOfWork.NoticeComponent.GetAsync();
            if (noticeComponent != null)
                return View(noticeComponent);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Component(NoticeComponent noticeComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.NoticeComponent.EditAsync(noticeComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details_component", "notice");
            }

            return View(noticeComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Details_Component()
        {
            var noticeComponent = await unitOfWork.NoticeComponent.GetAsync();
            if (noticeComponent != null)
                return View(noticeComponent);

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("notice");
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

                return RedirectToAction("details_page_access_component", "notice", new { id = pageAccessComponent.Id });
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
