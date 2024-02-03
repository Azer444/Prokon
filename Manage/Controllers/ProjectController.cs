using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Manage.Models;
using Manage.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProjectController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new ProjectViewModel()
            {
                HeaderPartialViewModel = new HeaderPartialViewModel()
                {
                    NavTitleComponents = await unitOfWork.NavTitleComponent.GetAllAsync(),
                    SiteConfig = await unitOfWork.SiteConfig.GetConfigAsync()
                },
                FooterPartialViewModel = new FooterPartialViewModel()
                {
                    NavTitleComponents = await unitOfWork.NavTitleComponent.GetAllAsync(),
                    SiteConfig = await unitOfWork.SiteConfig.GetConfigAsync()
                },
                MobileMenuPartialViewModel = new MobileMenuPartialViewModel()
                {
                    NavTitleComponents = await unitOfWork.NavTitleComponent.GetAllAsync(),
                    SiteConfig = await unitOfWork.SiteConfig.GetConfigAsync()
                },
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("project"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("project"),
                ContentAccessComponent = await unitOfWork.ContentAccessComponent.GetByPageNameAsync("project"),
                CompletedProjects = await unitOfWork.Project.GetCompletedProjectsAsync(),
                CurrentProjects = await unitOfWork.Project.GetCurrentProjectsAsync(),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id != null)
            {
                var project = await unitOfWork.Project.GetBySlugAsync(id);
                var model = new ProjectDetailsViewModel()
                {
                    HeaderPartialViewModel = new HeaderPartialViewModel()
                    {
                        NavTitleComponents = await unitOfWork.NavTitleComponent.GetAllAsync(),
                        SiteConfig = await unitOfWork.SiteConfig.GetConfigAsync()
                    },
                    FooterPartialViewModel = new FooterPartialViewModel()
                    {
                        NavTitleComponents = await unitOfWork.NavTitleComponent.GetAllAsync(),
                        SiteConfig = await unitOfWork.SiteConfig.GetConfigAsync()
                    },
                    MobileMenuPartialViewModel = new MobileMenuPartialViewModel()
                    {
                        NavTitleComponents = await unitOfWork.NavTitleComponent.GetAllAsync(),
                        SiteConfig = await unitOfWork.SiteConfig.GetConfigAsync()
                    },
                    PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("project"),
                    PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("project"),
                    Project = project != null ? await unitOfWork.Project.PrepareSplitedContentsAsync(project) : null
                };

                return View(model);
            }

            return NotFound();
        }
    }
}
