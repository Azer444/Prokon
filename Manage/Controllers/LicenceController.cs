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
    public class LicenceController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public LicenceController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new LicenceViewModel()
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
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("licence"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("licence"),
                ContentAccessComponent = await unitOfWork.ContentAccessComponent.GetByPageNameAsync("licence"),
                Az_Licences = await unitOfWork.Licence.GetByCountryNameAsync("Azerbaijan"),
                Ru_Licences = await unitOfWork.Licence.GetByCountryNameAsync("Russia"),
                Tr_Licences = await unitOfWork.Licence.GetByCountryNameAsync("Turkey")
            };

            return View(model);
        }
    }
}
