//using System.Threading.Tasks;
//using Core;
//using Core.Models;
//using Manage.Areas.Admin.Models.ViewModels;
//using Manage.Services;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace Manage.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    [Authorize]
//    public class TeamController : Controller
//    {
//        private readonly IUnitOfWork unitOfWork;
//        private readonly IFileService fileService;

//        public TeamController(IUnitOfWork unitOfWork,
//            IFileService fileService)
//        {
//            this.unitOfWork = unitOfWork;
//            this.fileService = fileService;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Index()
//        {
//            TeamIndexViewModel model = new TeamIndexViewModel()
//            {
//                MainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("team"),
//                Components = await unitOfWork.TeamComponent.GetAllAsync()
//            };

//            return View(model);
//        }

//        [HttpGet]
//        public IActionResult Define_main_photo()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Define_main_photo(PageMainPhoto teamMainPhoto)
//        {
//            if (ModelState.IsValid)
//            {
//                teamMainPhoto.PhotoName = await fileService.UploadAsync(teamMainPhoto.Photo);

//                await unitOfWork.PageMainPhoto.CreateAsync(teamMainPhoto);
//                await unitOfWork.CommitAsync();

//                return RedirectToAction("index", "team");
//            }

//            return View(teamMainPhoto);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Edit_main_photo(int? id)
//        {
//            if (id != null)
//            {
//                var mainPhoto = await unitOfWork.PageMainPhoto.GetAsync(id);

//                if (mainPhoto != null)
//                {
//                    MainPhotoEditViewModel model = new MainPhotoEditViewModel()
//                    {
//                        Title_AZ = mainPhoto.Title_AZ,
//                        Title_RU = mainPhoto.Title_RU,
//                        Title_EN = mainPhoto.Title_EN,
//                        Title_TR = mainPhoto.Title_TR,
//                        PhotoName = mainPhoto.PhotoName
//                    };

//                    return View(model);
//                }
//            }

//            return NotFound();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit_main_photo(MainPhotoEditViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("team");

//                if (mainPhoto != null)
//                {
//                    if (model.Photo != null)
//                    {
//                        fileService.Delete(mainPhoto.PhotoName);

//                        mainPhoto.PhotoName = await fileService.UploadAsync(model.Photo);
//                    }

//                    mainPhoto.Title_AZ = model.Title_AZ;
//                    mainPhoto.Title_RU = model.Title_RU;
//                    mainPhoto.Title_EN = model.Title_EN;
//                    mainPhoto.Title_TR = model.Title_TR;

//                    await unitOfWork.PageMainPhoto.EditAsync(mainPhoto);
//                    await unitOfWork.CommitAsync();

//                    return RedirectToAction("index", "team");
//                }

//                return NotFound();
//            }

//            return View(model);
//        }

//        [HttpGet]
//        public IActionResult Add_component()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Add_component(TeamComponent teamComponent)
//        {
//            if (ModelState.IsValid)
//            {
//                await unitOfWork.TeamComponent.CreateAsync(teamComponent);
//                await unitOfWork.CommitAsync();

//                return RedirectToAction("index", "team");
//            }

//            return View(teamComponent);
//        }


//        [HttpGet]
//        public async Task<IActionResult> Delete_component(int? id)
//        {
//            if (id != null)
//            {
//                var teamComponent = await unitOfWork.TeamComponent.GetAsync(id);

//                if (teamComponent != null)
//                {
//                    await unitOfWork.TeamComponent.DeleteAsync(id);
//                    await unitOfWork.CommitAsync();

//                    return Ok();
//                }
//            }

//            return NotFound();
//        }
//    }
//}
