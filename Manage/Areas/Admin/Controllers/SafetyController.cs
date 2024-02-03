using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SafetyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public SafetyController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SafetyIndexViewModel model = new SafetyIndexViewModel()
            {
                SafetyMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("safety"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("safety"),
                SafetyComponents = await unitOfWork.SafetyComponent.GetAllAsync(),
                SafetyTextComponent = await unitOfWork.SafetyTextComponent.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("safety");
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

                return RedirectToAction("index");
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("safety");
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
        public IActionResult Add_component()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add_component(SafetyComponent safetyComponent)
        {
            if (ModelState.IsValid)
            {
                safetyComponent.PhotoName = await fileService.UploadAsync(safetyComponent.Photo);
                safetyComponent.CreatedAt = AzDateTime.Now;

                await unitOfWork.SafetyComponent.CreateAsync(safetyComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(safetyComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_component(int? id)
        {
            if (id != null)
            {
                var safetyComponent = await unitOfWork.SafetyComponent.GetAsync(id);
                if (safetyComponent != null)
                {
                    SafetyComponentEditViewModel model = new SafetyComponentEditViewModel()
                    {
                        Id = safetyComponent.Id,
                        Content_AZ = safetyComponent.Content_AZ,
                        Content_RU = safetyComponent.Content_RU,
                        Content_EN = safetyComponent.Content_EN,
                        Content_TR = safetyComponent.Content_TR,
                        PhotoName = safetyComponent.PhotoName
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_component(SafetyComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var safetyComponent = await unitOfWork.SafetyComponent.GetAsync(model.Id);
                if (safetyComponent != null)
                {
                    if (model.Photo != null)
                    {
                        fileService.Delete(safetyComponent.PhotoName);
                        safetyComponent.PhotoName = await fileService.UploadAsync(model.Photo);
                    }

                    safetyComponent.Content_AZ = model.Content_AZ;
                    safetyComponent.Content_RU = model.Content_RU;
                    safetyComponent.Content_EN = model.Content_EN;
                    safetyComponent.Content_TR = model.Content_TR;

                    await unitOfWork.SafetyComponent.EditAsync(safetyComponent);
                    await unitOfWork.CommitAsync();

                    return RedirectToAction("index");
                }

                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details_component(int? id)
        {
            if (id != null)
            {
                var safetyComponent = await unitOfWork.SafetyComponent.GetAsync(id);
                if (safetyComponent != null)
                    return View(safetyComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_component(int? id)
        {
            if (id != null)
            {
                var safetyComponent = await unitOfWork.SafetyComponent.GetAsync(id);
                if (safetyComponent != null)
                {
                    fileService.Delete(safetyComponent.PhotoName);

                    await unitOfWork.SafetyComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_Text_Component()
        {
            var textComponent = await unitOfWork.SafetyTextComponent.GetAsync();

            if (textComponent == null)
                return View(textComponent);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_Text_Component(SafetyTextComponent safetyTextComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.SafetyTextComponent.CreateAsync(safetyTextComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(safetyTextComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Text_Component()
        {
            var safetyTextComponent = await unitOfWork.SafetyTextComponent.GetAsync();

            if (safetyTextComponent != null)
                return View(safetyTextComponent);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Text_Component(SafetyTextComponent safetyTextComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.SafetyTextComponent.EditAsync(safetyTextComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details_text_component");
            }

            return View(safetyTextComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Details_Text_Component()
        {
            var safetyTextComponent = await unitOfWork.SafetyTextComponent.GetAsync();
            if (safetyTextComponent != null)
                return View(safetyTextComponent);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("safety");
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

                return RedirectToAction("details_page_access_component", "safety", new { id = pageAccessComponent.Id });
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
