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
    public class GovernanceController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public GovernanceController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            GovernanceIndexViewModel model = new GovernanceIndexViewModel()
            {
                GovernanceMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("governance"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("governance"),
                GovernanceComponents = await unitOfWork.GovernanceComponent.GetAllAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("gocernance");

            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto governanceMainPhoto)
        {
            if (ModelState.IsValid)
            {
                governanceMainPhoto.PhotoName = await fileService.UploadAsync(governanceMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(governanceMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "governance");
            }

            return View(governanceMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("governance");

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

                    return RedirectToAction("index", "governance");
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
        public async Task<IActionResult> Add_component(GovernanceComponent governanceComponent)
        {
            if (ModelState.IsValid)
            {
                governanceComponent.PhotoName = await fileService.UploadAsync(governanceComponent.Photo);
                governanceComponent.CreatedAt = AzDateTime.Now;

                await unitOfWork.GovernanceComponent.CreateAsync(governanceComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "governance");
            }

            return View(governanceComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_component(int? id)
        {
            if (id != null)
            {
                var governanceComponent = await unitOfWork.GovernanceComponent.GetAsync(id);

                if (governanceComponent != null)
                {
                    GovernanceComponentEditViewModel model = new GovernanceComponentEditViewModel()
                    {
                        Id = governanceComponent.Id,
                        Title_AZ = governanceComponent.Title_AZ,
                        Title_RU = governanceComponent.Title_RU,
                        Title_EN = governanceComponent.Title_EN,
                        Title_TR = governanceComponent.Title_TR,
                        Content_AZ = governanceComponent.Content_AZ,
                        Content_RU = governanceComponent.Content_RU,
                        Content_EN = governanceComponent.Content_EN,
                        Content_TR = governanceComponent.Content_TR,
                        PhotoName = governanceComponent.PhotoName
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_component(GovernanceComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var governanceComponent = await unitOfWork.GovernanceComponent.GetAsync(model.Id);

                if (governanceComponent != null)
                {
                    if (model.Photo != null)
                    {
                        fileService.Delete(governanceComponent.PhotoName);
                        governanceComponent.PhotoName = await fileService.UploadAsync(model.Photo);
                    }

                    governanceComponent.Title_AZ = model.Title_AZ;
                    governanceComponent.Title_RU = model.Title_RU;
                    governanceComponent.Title_EN = model.Title_EN;
                    governanceComponent.Title_TR = model.Title_TR;
                    governanceComponent.Content_AZ = model.Content_AZ;
                    governanceComponent.Content_RU = model.Content_RU;
                    governanceComponent.Content_EN = model.Content_EN;
                    governanceComponent.Content_TR = model.Content_TR;

                    await unitOfWork.GovernanceComponent.EditAsync(governanceComponent);
                    await unitOfWork.CommitAsync();

                    return RedirectToAction("index", "governance");
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
                var governanceComponent = await unitOfWork.GovernanceComponent.GetAsync(id);

                if (governanceComponent != null)
                    return View(governanceComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_component(int? id)
        {
            if (id != null)
            {
                var governanceComponent = await unitOfWork.GovernanceComponent.GetAsync(id);

                if (governanceComponent != null)
                {
                    fileService.Delete(governanceComponent.PhotoName);

                    await unitOfWork.GovernanceComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("governance");

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

                return RedirectToAction("details_page_access_component", "governance", new { id = pageAccessComponent.Id });
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
