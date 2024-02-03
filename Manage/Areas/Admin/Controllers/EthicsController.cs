using System.Threading.Tasks;
using Core;
using Manage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Manage.Areas.Admin.Models.ViewModels;
using Core.Models;
using Manage.Helpers;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class EthicsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public EthicsController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            EthicsIndexViewModel model = new EthicsIndexViewModel()
            {
                MainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("ethics"),
                Components = await unitOfWork.EthicsComponent.GetAllAsync(),
                FileComponents = await unitOfWork.EthicsFileComponent.GetAllAsync(),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("ethics")
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("ethics");

            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto ethicsMainPhoto)
        {
            if (ModelState.IsValid)
            {
                ethicsMainPhoto.PhotoName = await fileService.UploadAsync(ethicsMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(ethicsMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "ethics");
            }

            return View(ethicsMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("ethics");

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
        public async Task<IActionResult> Add_component(EthicsComponent ethicsComponent)
        {
            if (ModelState.IsValid)
            {
                ethicsComponent.PhotoName = await fileService.UploadAsync(ethicsComponent.Photo);
                ethicsComponent.CreatedAt = AzDateTime.Now;

                await unitOfWork.EthicsComponent.CreateAsync(ethicsComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(ethicsComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_component(int? id)
        {
            if (id != null)
            {
                var ethicsComponent = await unitOfWork.EthicsComponent.GetAsync(id);

                if (ethicsComponent != null)
                {
                    EthicsComponentEditViewModel model = new EthicsComponentEditViewModel()
                    {
                        Id = ethicsComponent.Id,
                        Content_AZ = ethicsComponent.Content_AZ,
                        Content_RU = ethicsComponent.Content_RU,
                        Content_EN = ethicsComponent.Content_EN,
                        Content_TR = ethicsComponent.Content_TR,
                        PhotoName = ethicsComponent.PhotoName
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_component(EthicsComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ethicsComponent = await unitOfWork.EthicsComponent.GetAsync(model.Id);

                if (model.Photo != null)
                {
                    fileService.Delete(ethicsComponent.PhotoName);
                    ethicsComponent.PhotoName = await fileService.UploadAsync(model.Photo);
                }

                ethicsComponent.Content_AZ = model.Content_AZ;
                ethicsComponent.Content_RU = model.Content_RU;
                ethicsComponent.Content_EN = model.Content_EN;
                ethicsComponent.Content_TR = model.Content_TR;

                await unitOfWork.EthicsComponent.EditAsync(ethicsComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details_component","ethics",new { id = ethicsComponent.Id });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details_component(int? id)
        {
            if (id != null)
            {
                var ethicsComponent = await unitOfWork.EthicsComponent.GetAsync(id);

                if (ethicsComponent != null)
                    return View(ethicsComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_component(int? id)
        {
            if (id != null)
            {
                var ethicsComponent = await unitOfWork.EthicsComponent.GetAsync(id);

                if (ethicsComponent != null)
                {
                    fileService.Delete(ethicsComponent.PhotoName);

                    await unitOfWork.EthicsComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Add_file_component()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_file_component(EthicsFileComponent ethicsFileComponent)
        {
            if (ModelState.IsValid)
            {
                ethicsFileComponent.FileName = await fileService.UploadAsync(ethicsFileComponent.File);
                ethicsFileComponent.CreatedAt = AzDateTime.Now;

                await unitOfWork.EthicsFileComponent.CreateAsync(ethicsFileComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(ethicsFileComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_file_component(int? id)
        {
            if (id != null)
            {
                var ethicsFileComponent = await unitOfWork.EthicsFileComponent.GetAsync(id);
                if (ethicsFileComponent != null)
                {
                    EthicsFileComponentEditViewModel model = new EthicsFileComponentEditViewModel()
                    {
                        Id = ethicsFileComponent.Id,
                        Title_AZ = ethicsFileComponent.Title_AZ,
                        Title_RU = ethicsFileComponent.Title_RU,
                        Title_EN = ethicsFileComponent.Title_EN,
                        Title_TR = ethicsFileComponent.Title_TR,
                        FileName = ethicsFileComponent.FileName
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_file_component(EthicsFileComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ethicsFileComponent = await unitOfWork.EthicsFileComponent.GetAsync(model.Id);
                if (model.File != null)
                {
                    fileService.Delete(ethicsFileComponent.FileName);
                    ethicsFileComponent.FileName = await fileService.UploadAsync(model.File);
                }

                ethicsFileComponent.Title_AZ = model.Title_AZ;
                ethicsFileComponent.Title_RU = model.Title_RU;
                ethicsFileComponent.Title_EN = model.Title_EN;
                ethicsFileComponent.Title_TR = model.Title_TR;

                await unitOfWork.EthicsFileComponent.EditAsync(ethicsFileComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete_file_component(int? id)
        {
            if (id != null)
            {
                var ethicsFileComponent = await unitOfWork.EthicsFileComponent.GetAsync(id);

                if (ethicsFileComponent != null)
                {
                    fileService.Delete(ethicsFileComponent.FileName);

                    await unitOfWork.EthicsFileComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("ethics");

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

                return RedirectToAction("details_page_access_component", "ethics", new { id = pageAccessComponent.Id });
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
