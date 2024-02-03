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

    public class ContactController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new ContactViewModel()
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
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("contact"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("contact"),
                ContactComponents = await unitOfWork.ContactComponent.GetAllAsync()
            };

            return View(model);
        }
    }
}
