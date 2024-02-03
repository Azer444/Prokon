using System;
using System.IO;
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
    public class PartnerController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public PartnerController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Page()
        {
            PartnerIndexViewModel model = new PartnerIndexViewModel()
            {
                MainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("partner"),
                Component = await unitOfWork.PartnerComponent.GetAsync(),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("partner")
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("partner");

            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto clientMainPhoto)
        {
            if (ModelState.IsValid)
            {
                clientMainPhoto.PhotoName = await fileService.UploadAsync(clientMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(clientMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("page");
            }

            return View(clientMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("partner");

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
        public async Task<IActionResult> Define_component()
        {
            var partnerComponent = await unitOfWork.PartnerComponent.GetAsync();

            if (partnerComponent == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_component(PartnerComponent partnerComponent)
        {
            if (ModelState.IsValid)
            {
                partnerComponent.PhotoName = await fileService.UploadAsync(partnerComponent.Photo);

                await unitOfWork.PartnerComponent.CreateAsync(partnerComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("page");
            }

            return View(partnerComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_component()
        {
            var partnerComponent = await unitOfWork.PartnerComponent.GetAsync();

            if (partnerComponent != null)
            {
                PartnerComponentEditViewModel model = new PartnerComponentEditViewModel()
                {
                    Content_AZ = partnerComponent.Content_AZ,
                    Content_RU = partnerComponent.Content_RU,
                    Content_EN = partnerComponent.Content_EN,
                    Content_TR = partnerComponent.Content_TR,
                    PhotoName = partnerComponent.PhotoName
                };

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_component(PartnerComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var partnerComponent = await unitOfWork.PartnerComponent.GetAsync();

                if (model.Photo != null)
                {
                    fileService.Delete(partnerComponent.PhotoName);
                    partnerComponent.PhotoName = await fileService.UploadAsync(model.Photo);
                }

                partnerComponent.Content_AZ = model.Content_AZ;
                partnerComponent.Content_RU = model.Content_RU;
                partnerComponent.Content_EN = model.Content_EN;
                partnerComponent.Content_TR = model.Content_TR;

                await unitOfWork.PartnerComponent.EditAsync(partnerComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("page");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details_component()
        {
            var partnerComponent = await unitOfWork.PartnerComponent.GetAsync();

            if (partnerComponent != null)
                return View(partnerComponent);

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("partner");

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

                return RedirectToAction("details_page_access_component", "partner", new { id = pageAccessComponent.Id });
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
            var partners = await unitOfWork.Partner.GetAllAsync();
            return View(partners);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Partner partner)
        {
            if (ModelState.IsValid)
            {
                partner.LogoName = await fileService.UploadAsync(partner.Logo);

                await unitOfWork.Partner.CreateAsync(partner);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(partner);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var partner = await unitOfWork.Partner.GetAsync(id);

                if (partner != null)
                {
                    fileService.Delete(partner.LogoName);

                    await unitOfWork.Partner.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }
    }
}
