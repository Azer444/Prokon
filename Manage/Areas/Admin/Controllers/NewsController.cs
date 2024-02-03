using System.Threading.Tasks;
using Core;
using Core.Models;
using Manage.Areas.Admin.Models.ViewModels;
using Manage.Helpers;
using Manage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class NewsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public NewsController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Page()
        {
            var model = new NewsPageViewModel()
            {
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("news"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("news"),
                ContentAccessComponent = await unitOfWork.ContentAccessComponent.GetByPageNameAsync("news")
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("news");

            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto newsMainPhoto)
        {
            if (ModelState.IsValid)
            {
                newsMainPhoto.PhotoName = await fileService.UploadAsync(newsMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(newsMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("page");
            }

            return View(newsMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("news");
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
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("news");

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

                return RedirectToAction("details_page_access_component", "news", new { id = pageAccessComponent.Id });
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
            var news = await unitOfWork.News.GetAllAsync();
            return View(news);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(News news)
        {
            if (ModelState.IsValid)
            {
                news.PhotoName = await fileService.UploadAsync(news.Photo);

                await unitOfWork.News.CreateAsync(news);
                await unitOfWork.CommitAsync();
                await unitOfWork.News.RegulateSlugAsync(news);

                return RedirectToAction("index");
            }

            return View(news);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id != null)
            {
                var news = await unitOfWork.News.GetBySlugAsync(id);

                if (news != null)
                {
                    NewsEditViewModel model = new NewsEditViewModel()
                    {
                        Id = news.Id,
                        Title_AZ = news.Title_AZ,
                        Title_RU = news.Title_RU,
                        Title_EN = news.Title_EN,
                        Title_TR = news.Title_TR,
                        Slug = news.Slug,
                        Content_AZ = news.Content_AZ,
                        Content_RU = news.Content_RU,
                        Content_EN = news.Content_EN,
                        Content_TR = news.Content_TR,
                        Location_AZ = news.Location_AZ,
                        Location_RU = news.Location_RU,
                        Location_EN = news.Location_EN,
                        Location_TR = news.Location_TR,
                        CreatedAt = news.CreatedAt,
                        PhotoName = news.PhotoName,
                        Type = news.Type
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewsEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var news = await unitOfWork.News.GetAsync(model.Id);
                if (news != null)
                {
                    if (model.Photo != null)
                    {
                        fileService.Delete(news.PhotoName);
                        news.PhotoName = await fileService.UploadAsync(model.Photo);
                    }

                    news.Title_AZ = model.Title_AZ;
                    news.Title_RU = model.Title_RU;
                    news.Title_EN = model.Title_EN;
                    news.Title_TR = model.Title_TR;
                    news.Slug = model.Slug;
                    news.Content_AZ = model.Content_AZ;
                    news.Content_RU = model.Content_RU;
                    news.Content_EN = model.Content_EN;
                    news.Content_TR = model.Content_TR;
                    news.Location_AZ = model.Location_AZ;
                    news.Location_RU = model.Location_RU;
                    news.Location_EN = model.Location_EN;
                    news.Location_TR = model.Location_TR;
                    news.CreatedAt = model.CreatedAt;
                    news.Type = model.Type;

                    await unitOfWork.News.RegulateSlugAsync(news);
                    await unitOfWork.News.EditAsync(news);
                    await unitOfWork.CommitAsync();

                    return RedirectToAction("index");
                }

                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id != null)
            {
                var news = await unitOfWork.News.GetBySlugAsync(id);

                if (news != null)
                    return View(news);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var news = await unitOfWork.News.GetAsync(id);

                if (news != null)
                {
                    fileService.Delete(news.PhotoName);

                    await unitOfWork.News.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile upload)
        {
            if (upload != null)
            {
                var fileName = await fileService.UploadAsync(upload);
                var url = $"{"/uploads/"}{fileName}";
                var success = new UploadSuccess
                {
                    Uploaded = 1,
                    FileName = fileName,
                    Url = url
                };

                return new JsonResult(success);
            }

            return null;
        }
    }
}
