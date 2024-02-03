using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Models;
using Manage.Helpers;
using Manage.Models;
using Manage.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Manage.Controllers
{
    public class CareerController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;
        private readonly IEmailService emailService;
        private readonly IOptions<SmtpConfig> smtpConfig;

        public CareerController(IUnitOfWork unitOfWork,
            IFileService fileService,
            IEmailService emailService,
            IOptions<SmtpConfig> smtpConfig)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
            this.emailService = emailService;
            this.smtpConfig = smtpConfig;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new CareerViewModel()
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
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("career"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("career"),
                ContentAccessComponent = await unitOfWork.ContentAccessComponent.GetByPageNameAsync("career"),
                JobComponents = await unitOfWork.CareerComponent.GetAllByTypeAsync("job"),
                JobOpportunities = await unitOfWork.Opportunity.GetAllByTypeAsync("job"),
                InternshipComponents = await unitOfWork.CareerComponent.GetAllByTypeAsync("internship"),
                InternshipOpportunities = await unitOfWork.Opportunity.GetAllByTypeAsync("internship"),
                CareerFormComponent = await unitOfWork.CareerFormComponent.GetAsync(),
                CareerAppContent = await unitOfWork.CareerAppContent.GetAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add_Opportunity_Apply(CareerFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var opportunityApply = new OpportunityApply()
                {
                    FullName = model.Fullname,
                    Email = model.Email,
                    CVName = await fileService.UploadAsync(model.CV),
                    OpportunityId = (int)model.OpportunityId,
                };

                await unitOfWork.OpportunityApply.CreateAsync(opportunityApply);
                await unitOfWork.CommitAsync();

                var supportingFilesPath = string.Empty;
                foreach (var supportingFile in model.SupportingFiles)
                {
                    var opportunityApplyFile = new OpportunityApplyFile()
                    {
                        FileName = await fileService.UploadAsync(supportingFile),
                        OpportunityApplyId = opportunityApply.Id,
                    };

                    await unitOfWork.OpportunityApplyFile.CreateAsync(opportunityApplyFile);
                    await unitOfWork.CommitAsync();

                    var supportingFilePath = "https://prokon.az/uploads/" + opportunityApplyFile.FileName;
                    supportingFilesPath += supportingFilePath + "<br>";
                }

                var opportunity = await unitOfWork.Opportunity.GetAsync(model.OpportunityId);
                var cvPath = "https://prokon.az/uploads/" + opportunityApply.CVName;

                var body = $"<h2>By {model.Fullname}</h2>" +
                   $"<h3 style='margin:0;'>Email:</h3>" +
                   $"<p  style='margin:0;'>{model.Email}</p>" +
                   $"<h3 style='margin-bottom:0;'>Position:</h3>" +
                   $"<p  style='margin:0;'>{opportunity.Title_EN}</p>" +
                   $"<h3 style='margin-bottom:0;'>CV:</h3>" +
                   $"<p style='margin:0;'>{cvPath}</p>" +
                   $"<h3 style='margin-bottom:0;'>Supporting Files:</h3>" +
                   $"<p style='margin:0;'>{supportingFilesPath}</p>";
                await emailService.SendEmailAsync($"{opportunity.Title_EN} Apply", body, smtpConfig.Value.ToHREmail);

                return Ok();
            }

            return NotFound();
        }

        //[HttpPost]
        //public async Task<IActionResult> Add_General_Apply(CareerGeneralFormViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var generalApply = new GeneralApply()
        //        {
        //            FullName = model.Fullname,
        //            Email = model.Email,
        //            Position = model.Position,
        //            CVName = await fileService.UploadAsync(model.CV),
        //        };

        //        await unitOfWork.GeneralApply.CreateAsync(generalApply);
        //        await unitOfWork.CommitAsync();

        //        var supportingFilesPath = string.Empty;
        //        foreach (var supportingFile in model.SupportingFiles)
        //        {
        //            var generalApplyFile = new GeneralApplyFile()
        //            {
        //                FileName = await fileService.UploadAsync(supportingFile),
        //                GeneralApplyId = generalApply.Id
        //            };

        //            await unitOfWork.GeneralApplyFile.CreateAsync(generalApplyFile);
        //            await unitOfWork.CommitAsync();

        //            var supportingFilePath = "https://prokon.az/uploads/" + generalApplyFile.FileName;
        //            supportingFilesPath += supportingFilePath + "<br>";
        //        }

        //        var cvPath = "https://prokon.az/uploads/" + generalApply.CVName;

        //        var body = $"<h2>By {model.Fullname}</h2>" +
        //           $"<h3 style='margin:0;'>Email:</h3>" +
        //           $"<p style='margin:0;'>{model.Email}</p>" +
        //           $"<h3 style='margin-bottom:0;'>Position:</h3>" +
        //           $"<p style='margin:0;'>{model.Position}</p>" +
        //           $"<h3 style='margin-bottom:0;'>CV:</h3>" +
        //           $"<p style='margin:0;'>{cvPath}</p>" +
        //           $"<h3 style='margin-bottom:0;'>Supporting Files:</h3>" +
        //           $"<p style='margin:0;'>{supportingFilesPath}</p>";
        //        await emailService.SendEmailAsync($"{model.Position} Apply", body, smtpConfig.Value.ToHREmail);

        //        return Ok();
        //    }

        //    return NotFound();
        //}
    }
}
