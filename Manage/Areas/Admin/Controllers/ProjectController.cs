using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Models;
using Manage.Areas.Admin.Models.ViewModels;
using Manage.Helpers;
using Manage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public ProjectController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Page()
        {
            var model = new ProjectPageViewModel()
            {
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("project"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("project"),
                ContentAccessComponent = await unitOfWork.ContentAccessComponent.GetByPageNameAsync("project")
            };

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("project");
            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto projectMainPhoto)
        {
            if (ModelState.IsValid)
            {
                projectMainPhoto.PhotoName = await fileService.UploadAsync(projectMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(projectMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("page", "project");
            }

            return View(projectMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("project");
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

                    return RedirectToAction("page", "project");
                }

                return NotFound();

            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("project");
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

                return RedirectToAction("details_page_access_component", "project", new { id = pageAccessComponent.Id });
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
            var pageAccessComponent = await unitOfWork.ContentAccessComponent.GetByPageNameAsync("project");
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

                return RedirectToAction("details_content_access_component", "project", new { id = contentAccessComponent.Id });
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
            var projects = await unitOfWork.Project.GetAllAsync();
            return View(projects);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Orders = await unitOfWork.GalleryComponent.GetEmptyOrdersAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Project project)
        {
            if (ModelState.IsValid)
            {
                project.TitlePhotoName = await fileService.UploadAsync(project.TitlePhoto);
                project.CreatedAt = AzDateTime.Now;

                if (!project.CurrentOrder.HasValue)
                    project.CurrentOrder = await unitOfWork.Project.AddLastCurrentOrderAsync();

                await unitOfWork.Project.CreateAsync(project);
                await unitOfWork.CommitAsync();
                await unitOfWork.Project.RegulateSlugAsync(project);

                foreach (var photo in project.Photos)
                {
                    var photo_ = new ProjectPhoto()
                    {
                        PhotoName = await fileService.UploadAsync(photo),
                        ProjectId = project.Id
                    };

                    await unitOfWork.ProjectPhoto.CreateAsync(photo_);
                    await unitOfWork.CommitAsync();
                }

                if (project.ShowAsGallery)
                {
                    var galleryComponent = new GalleryComponent
                    {
                        Title_AZ = project.Name_AZ,
                        Title_RU = project.Name_RU,
                        Title_EN = project.Name_EN,
                        Title_TR = project.Name_TR,
                        TitlePhotoName = project.TitlePhotoName,
                        ProjectId = project.Id,
                        Date = project.StartingDate
                    };

                    if (project.ShowOnHomePageAsGallery)
                    {
                        galleryComponent.ShowOnHomePage = project.ShowOnHomePageAsGallery;
                        galleryComponent.Order = project.GalleryOrder;
                    }

                    await unitOfWork.GalleryComponent.CreateAsync(galleryComponent);
                    await unitOfWork.CommitAsync();

                    foreach (var projectPhoto in project.ProjectPhotos)
                    {
                        var galleryComponentPhoto = new GalleryComponentPhoto
                        {
                            PhotoName = projectPhoto.PhotoName,
                            GalleryComponentId = galleryComponent.Id,
                        };

                        await unitOfWork.GalleryComponentPhoto.CreateAsync(galleryComponentPhoto);
                        await unitOfWork.CommitAsync();
                    }
                }
                return RedirectToAction("index", "project");
            }
            return View(project);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id != null)
            {
                var project = await unitOfWork.Project.GetBySlugAsync(id);
                if (project != null)
                {
                    project.ShowAsGallery = project.GalleryComponent != null ? true : false;
                    project.ShowOnHomePageAsGallery = project.GalleryComponent?.ShowOnHomePage != null ? project.GalleryComponent.ShowOnHomePage : false;
                    project.GalleryOrder = project.GalleryComponent?.Order != null ? project.GalleryComponent.Order : null;

                    return View(project);
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id != null)
            {
                var project = await unitOfWork.Project.GetBySlugAsync(id);
                if (project != null)
                {
                    ProjectEditViewModel model = new ProjectEditViewModel()
                    {
                        Id = project.Id,
                        Name_AZ = project.Name_AZ,
                        Name_RU = project.Name_RU,
                        Name_EN = project.Name_EN,
                        Name_TR = project.Name_TR,
                        Slug = project.Slug,
                        Type = project.Type,
                        Location_AZ = project.Location_AZ,
                        Location_RU = project.Location_RU,
                        Location_EN = project.Location_EN,
                        Location_TR = project.Location_TR,
                        Description_AZ = project.Description_AZ,
                        Description_RU = project.Description_RU,
                        Description_EN = project.Description_EN,
                        Description_TR = project.Description_TR,
                        StartingDate = project.StartingDate,
                        PlannedCompletionDate = project.PlannedCompletionDate,
                        CompletedDate = project.CompletedDate,
                        TitlePhotoName = project.TitlePhotoName,
                        ProjectPhotos = project.ProjectPhotos,
                        ShowOnHomePage = project.ShowOnHomePage,
                        HomePageOrder = project.HomePageOrder,
                        ShowAsGallery = project.GalleryComponent != null ? true : false,
                        ShowOnHomePageAsGallery = project.GalleryComponent?.ShowOnHomePage != null ? project.GalleryComponent.ShowOnHomePage : false,
                        GalleryOrder = project.GalleryComponent?.Order != null ? project.GalleryComponent.Order : null,
                        CurrentOrder = project.CurrentOrder
                    };

                    ViewBag.Orders = project.GalleryComponent != null ? await unitOfWork.GalleryComponent.GetEmptyOrdersAsync(project.GalleryComponent) : await unitOfWork.GalleryComponent.GetEmptyOrdersAsync(); ;
                    return View(model);
                }
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ProjectEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var project = await unitOfWork.Project.GetAsync(model.Id);
                if (project != null)
                {
                    if (model.TitlePhoto != null)
                    {
                        fileService.Delete(project.TitlePhotoName);
                        project.TitlePhotoName = await fileService.UploadAsync(model.TitlePhoto);
                    }

                    foreach (var photo in model.Photos)
                    {
                        var photo_ = new ProjectPhoto()
                        {
                            PhotoName = await fileService.UploadAsync(photo),
                            ProjectId = project.Id
                        };

                        await unitOfWork.ProjectPhoto.CreateAsync(photo_);
                        await unitOfWork.CommitAsync();

                        if (model.ShowAsGallery && project.GalleryComponent != null)
                        {
                            var galleryComponentPhoto = new GalleryComponentPhoto
                            {
                                PhotoName = photo_.PhotoName,
                                GalleryComponentId = project.GalleryComponent.Id,
                            };

                            await unitOfWork.GalleryComponentPhoto.CreateAsync(galleryComponentPhoto);
                            await unitOfWork.CommitAsync();
                        }
                    }

                    project.Name_AZ = model.Name_AZ;
                    project.Name_RU = model.Name_RU;
                    project.Name_EN = model.Name_EN;
                    project.Name_TR = model.Name_TR;
                    project.Slug = model.Slug;
                    project.Type = model.Type;
                    project.Location_AZ = model.Location_AZ;
                    project.Location_RU = model.Location_RU;
                    project.Location_EN = model.Location_EN;
                    project.Location_TR = model.Location_TR;
                    project.Description_AZ = model.Description_AZ;
                    project.Description_RU = model.Description_RU;
                    project.Description_EN = model.Description_EN;
                    project.Description_TR = model.Description_TR;
                    project.StartingDate = model.StartingDate;
                    project.PlannedCompletionDate = model.PlannedCompletionDate;
                    project.CompletedDate = model.CompletedDate;
                    project.ShowOnHomePage = model.ShowOnHomePage;
                    project.HomePageOrder = model.HomePageOrder;

                    if (model.CurrentOrder.HasValue)
                        project.CurrentOrder = model.CurrentOrder;
                    else
                        project.CurrentOrder = await unitOfWork.Project.AddLastCurrentOrderAsync();

                    await unitOfWork.Project.RegulateSlugAsync(project);
                    await unitOfWork.Project.EditAsync(project);
                    await unitOfWork.CommitAsync();

                    if (model.ShowAsGallery && project.GalleryComponent != null)
                    {
                        var galleryComponent = await unitOfWork.GalleryComponent.GetAsync(project.GalleryComponent.Id);

                        galleryComponent.Title_AZ = project.Name_AZ;
                        galleryComponent.Title_RU = project.Name_RU;
                        galleryComponent.Title_EN = project.Name_EN;
                        galleryComponent.Title_TR = project.Name_TR;
                        galleryComponent.Date = project.StartingDate;
                        galleryComponent.TitlePhotoName = project.TitlePhotoName;
                        galleryComponent.ShowOnHomePage = model.ShowOnHomePageAsGallery;

                        if (model.ShowOnHomePageAsGallery)
                            galleryComponent.Order = model.GalleryOrder;
                        else
                            galleryComponent.Order = null;

                        await unitOfWork.GalleryComponent.EditAsync(galleryComponent);
                        await unitOfWork.CommitAsync();
                    }
                    else if (model.ShowAsGallery)
                    {
                        var galleryComponent = new GalleryComponent
                        {
                            Title_AZ = project.Name_AZ,
                            Title_RU = project.Name_RU,
                            Title_EN = project.Name_EN,
                            Title_TR = project.Name_TR,
                            TitlePhotoName = project.TitlePhotoName,
                            Date = project.StartingDate,
                            ProjectId = project.Id
                        };

                        if (model.ShowOnHomePageAsGallery)
                        {
                            galleryComponent.ShowOnHomePage = model.ShowOnHomePageAsGallery;
                            galleryComponent.Order = model.GalleryOrder;
                        }

                        await unitOfWork.GalleryComponent.CreateAsync(galleryComponent);
                        await unitOfWork.CommitAsync();

                        foreach (var projectPhoto in project.ProjectPhotos)
                        {
                            var galleryComponentPhoto = new GalleryComponentPhoto
                            {
                                PhotoName = projectPhoto.PhotoName,
                                GalleryComponentId = galleryComponent.Id,
                            };

                            await unitOfWork.GalleryComponentPhoto.CreateAsync(galleryComponentPhoto);
                            await unitOfWork.CommitAsync();
                        }
                    }
                    else if (project.GalleryComponent != null)
                    {
                        await unitOfWork.GalleryComponent.DeleteAsync(project.GalleryComponent.Id);
                        await unitOfWork.CommitAsync();
                    }

                    return RedirectToAction("details", "project", new { id = project.Slug });
                }
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var project = await unitOfWork.Project.GetAsync(id);
                if (project != null)
                {
                    fileService.Delete(project.TitlePhotoName);
                    foreach (var projectPhoto in project.ProjectPhotos)
                    {
                        fileService.Delete(projectPhoto.PhotoName);
                    }

                    await unitOfWork.Project.DeleteAsync(project.Id);
                    await unitOfWork.GalleryComponent.DeleteByProjectIdAsync(project.Id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_project_photo(int? id)
        {
            if (id != null)
            {
                var projectPhoto = await unitOfWork.ProjectPhoto.GetAsync(id);
                if (projectPhoto != null)
                {
                    fileService.Delete(projectPhoto.PhotoName);

                    await unitOfWork.ProjectPhoto.DeleteAsync(id);
                    await unitOfWork.GalleryComponentPhoto.DeleteByPhotoName(projectPhoto.PhotoName);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }
    }
}
