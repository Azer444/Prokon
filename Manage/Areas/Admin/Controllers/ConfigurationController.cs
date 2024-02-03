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
    public class ConfigurationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public ConfigurationController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var configuration = await unitOfWork.Configuration.GetAsync();
            return View(configuration);
        }

        [HttpGet]
        public async Task<IActionResult> Define()
        {
            var configuration = await unitOfWork.Configuration.GetAsync();

            if (configuration == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define(SiteConfig siteConfig)
        {
            if (ModelState.IsValid)
            {
                siteConfig.FirstLogoName = await fileService.UploadAsync(siteConfig.FirstLogo);
                siteConfig.SecondLogoName = await fileService.UploadAsync(siteConfig.SecondLogo);

                await unitOfWork.Configuration.DefineAsync(siteConfig);
                await unitOfWork.CommitAsync();

                foreach (var footerPartnerPhoto in siteConfig.FooterPartnerPhotos)
                {
                    var footerPartner = new FooterPartner()
                    {
                        PhotoName = await fileService.UploadAsync(footerPartnerPhoto),
                        SiteConfigId = siteConfig.Id
                    };

                    await unitOfWork.FooterPartner.CreateAsync(footerPartner);
                    await unitOfWork.CommitAsync();
                }

                return RedirectToAction("index", "configuration");
            }

            return View(siteConfig);
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var configuration = await unitOfWork.Configuration.GetAsync();

            if (configuration != null)
            {
                SiteConfigEditViewModel model = new SiteConfigEditViewModel()
                {
                    Id = configuration.Id,
                    FirstLogoName = configuration.FirstLogoName,
                    SecondLogoName = configuration.SecondLogoName,
                    HeadOffice_AZ = configuration.HeadOffice_AZ,
                    HeadOffice_RU = configuration.HeadOffice_RU,
                    HeadOffice_EN = configuration.HeadOffice_EN,
                    HeadOffice_TR = configuration.HeadOffice_TR,
                    CopyrightText_AZ = configuration.CopyrightText_AZ,
                    CopyrightText_RU = configuration.CopyrightText_RU,
                    CopyrightText_EN = configuration.CopyrightText_EN,
                    CopyrightText_TR = configuration.CopyrightText_TR,
                    LinkedinText = configuration.LinkedinText,
                    LinkedinText_RU = configuration.LinkedinText_RU,
                    LinkedinLink = configuration.LinkedinLink,
                    FacebookText = configuration.FacebookText,
                    FacebookText_RU = configuration.FacebookText_RU,
                    FacebookLink = configuration.FacebookLink,
                    TwitterText = configuration.TwitterText,
                    TwitterText_RU = configuration.TwitterText_RU,
                    TwitterLink = configuration.TwitterLink,
                    Email = configuration.Email,
                    Phone = configuration.Phone,
                    FooterPartners = configuration.FooterPartners
                };

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SiteConfigEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var configuration = await unitOfWork.Configuration.GetAsync();

                if (model.FirstLogo != null)
                {
                    fileService.Delete(configuration.FirstLogoName);
                    configuration.FirstLogoName = await fileService.UploadAsync(model.FirstLogo);
                }

                if (model.SecondLogo != null)
                {
                    fileService.Delete(configuration.SecondLogoName);
                    configuration.SecondLogoName = await fileService.UploadAsync(model.SecondLogo);
                }

                foreach (var footerPartnerPhoto in model.FooterPartnerPhotos)
                {
                    var footerPartner = new FooterPartner()
                    {
                        PhotoName = await fileService.UploadAsync(footerPartnerPhoto),
                        SiteConfigId = configuration.Id
                    };

                    await unitOfWork.FooterPartner.CreateAsync(footerPartner);
                    await unitOfWork.CommitAsync();
                }

                configuration.HeadOffice_AZ = model.HeadOffice_AZ;
                configuration.HeadOffice_RU = model.HeadOffice_RU;
                configuration.HeadOffice_EN = model.HeadOffice_EN;
                configuration.HeadOffice_TR = model.HeadOffice_TR;
                configuration.CopyrightText_AZ = model.CopyrightText_AZ;
                configuration.CopyrightText_RU = model.CopyrightText_RU;
                configuration.CopyrightText_EN = model.CopyrightText_EN;
                configuration.CopyrightText_TR = model.CopyrightText_TR;
                configuration.LinkedinText = model.LinkedinText;
                configuration.LinkedinText_RU = model.LinkedinText_RU;
                configuration.LinkedinLink = model.LinkedinLink;
                configuration.FacebookText = model.FacebookText;
                configuration.FacebookText_RU = model.FacebookText_RU;
                configuration.FacebookLink = model.FacebookLink;
                configuration.TwitterText = model.TwitterText;
                configuration.TwitterText_RU = model.TwitterText_RU;
                configuration.TwitterLink = model.TwitterLink;
                configuration.Email = model.Email;
                configuration.Phone = model.Phone;

                await unitOfWork.Configuration.EditAsync(configuration);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details", "configuration");
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var configuration = await unitOfWork.Configuration.GetAsync();

            if (configuration != null)
                return View(configuration);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_Footer_Partner(int? id)
        {
            if (id != null)
            {
                var footerPartner = await unitOfWork.FooterPartner.GetAsync(id);
                if (footerPartner != null)
                {
                    await unitOfWork.FooterPartner.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }
    }
}
