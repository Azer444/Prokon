using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core;
using Manage.Services;
using Core.Models;
using Manage.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class LicenceController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public LicenceController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Page()
        {
            var model = new LicencePageViewModel()
            {
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("licence"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("licence"),
                ContentAccessComponent = await unitOfWork.ContentAccessComponent.GetByPageNameAsync("licence")
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("licence");

            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto licenceMainPhoto)
        {
            if (ModelState.IsValid)
            {
                licenceMainPhoto.PhotoName = await fileService.UploadAsync(licenceMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(licenceMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("page");
            }

            return View(licenceMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("licence");

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
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("licence");

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

                return RedirectToAction("details_page_access_component", "licence", new { id = pageAccessComponent.Id });
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
            var pageAccessComponent = await unitOfWork.ContentAccessComponent.GetByPageNameAsync("licence");

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

                return RedirectToAction("page");
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

                return RedirectToAction("details_content_access_component", "licence", new { id = contentAccessComponent.Id });
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var licences = await unitOfWork.Licence.GetAllAsync();
            return View(licences);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            LicenceAddViewModel model = new LicenceAddViewModel()
            {
                Countries = await unitOfWork.Country.GetSelectItems()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LicenceAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.PDFName = await fileService.UploadAsync(model.PDF);
                model.PhotoName = await fileService.UploadAsync(model.Photo);

                Licence licence = new Licence()
                {
                    Name_AZ = model.Name_AZ,
                    Name_RU = model.Name_RU,
                    Name_EN = model.Name_EN,
                    Name_TR = model.Name_TR,
                    CountryId = model.CountryId,
                    PDFName = model.PDFName,
                    PhotoName = model.PhotoName
                };

                await unitOfWork.Licence.CreateAsync(licence);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");

            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var licence = await unitOfWork.Licence.GetAsync(id);

                if (licence != null)
                {
                    LicenceEditViewModel model = new LicenceEditViewModel()
                    {
                        Name_AZ = licence.Name_AZ,
                        Name_RU = licence.Name_RU,
                        Name_EN = licence.Name_EN,
                        Name_TR = licence.Name_TR,
                        PhotoName = licence.PhotoName,
                        PDFName = licence.PDFName,
                        CountryId = licence.CountryId,
                        Countries = await unitOfWork.Country.GetSelectItems()
                    };

                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LicenceEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var licence = await unitOfWork.Licence.GetAsync(model.Id);

                if (licence != null)
                {
                    if (model.Photo != null)
                    {
                        fileService.Delete(licence.PhotoName);
                        licence.PhotoName = await fileService.UploadAsync(model.Photo);
                    }

                    if (model.PDF != null)
                    {
                        fileService.Delete(licence.PDFName);
                        licence.PDFName = await fileService.UploadAsync(model.PDF);
                    }

                    licence.Name_AZ = model.Name_AZ;
                    licence.Name_RU = model.Name_RU;
                    licence.Name_EN = model.Name_EN;
                    licence.Name_TR = model.Name_TR;
                    licence.CountryId = model.CountryId;

                    await unitOfWork.Licence.EditAsync(licence);
                    await unitOfWork.CommitAsync();

                    return RedirectToAction("index");

                }

                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var licence = await unitOfWork.Licence.GetAsync(id);

                if (licence != null)
                {
                    fileService.Delete(licence.PhotoName);
                    fileService.Delete(licence.PDFName);

                    await unitOfWork.Licence.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

    }
}
