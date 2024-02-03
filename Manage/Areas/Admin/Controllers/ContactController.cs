using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Manage.Areas.Admin.Models.ViewModels;
using Core;
using Manage.Services;
using Core.Models;

namespace Prokon.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public ContactController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new ContactIndexViewModel()
            {
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("contact"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("contact"),
                ContactComponents = await unitOfWork.ContactComponent.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("contact");

            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto contactMainPhoto)
        {
            if (ModelState.IsValid)
            {
                contactMainPhoto.PhotoName = await fileService.UploadAsync(contactMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(contactMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "contact");
            }

            return View(contactMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("contact");

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

                    return RedirectToAction("index", "contact");
                }

                return NotFound();

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Add_Component()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Component(ContactComponent contactComponent)
        {
            if (ModelState.IsValid)
            {
                contactComponent.PhotoName = await fileService.UploadAsync(contactComponent.Photo);

                await unitOfWork.ContactComponent.CreateAsync(contactComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(contactComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Component(int? id)
        {
            if (id != null)
            {
                var contactComponent = await unitOfWork.ContactComponent.GetAsync(id);
                if (contactComponent != null)
                {
                    var model = new ContactComponentEditViewModel()
                    {
                        Id = contactComponent.Id,
                        Title_AZ = contactComponent.Title_AZ,
                        Title_RU = contactComponent.Title_RU,
                        Title_EN = contactComponent.Title_EN,
                        Title_TR = contactComponent.Title_TR,
                        Content_AZ = contactComponent.Content_AZ,
                        Content_RU = contactComponent.Content_RU,
                        Content_EN = contactComponent.Content_EN,
                        Content_TR = contactComponent.Content_TR,
                        PhotoName = contactComponent.PhotoName
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Component(ContactComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contactComponent = await unitOfWork.ContactComponent.GetAsync(model.Id);

                if (model.Photo != null)
                {
                    fileService.Delete(contactComponent.PhotoName);
                    contactComponent.PhotoName = await fileService.UploadAsync(model.Photo);
                }

                contactComponent.Title_AZ = model.Title_AZ;
                contactComponent.Title_RU = model.Title_RU;
                contactComponent.Title_EN = model.Title_EN;
                contactComponent.Title_TR = model.Title_TR;
                contactComponent.Content_AZ = model.Content_AZ;
                contactComponent.Content_RU = model.Content_RU;
                contactComponent.Content_EN = model.Content_EN;
                contactComponent.Content_TR = model.Content_TR;

                await unitOfWork.ContactComponent.EditAsync(contactComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details_component(int? id)
        {
            if (id != null)
            {
                var contactComponent = await unitOfWork.ContactComponent.GetAsync(id);

                if (contactComponent != null)
                    return View(contactComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_component(int? id)
        {
            if (id != null)
            {
                var contactComponent = await unitOfWork.ContactComponent.GetAsync(id);

                if (contactComponent != null)
                {
                    fileService.Delete(contactComponent.PhotoName);

                    await unitOfWork.ContactComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("contact");

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

                return RedirectToAction("details_page_access_component", "contact", new { id = pageAccessComponent.Id });
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
