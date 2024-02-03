using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Models;
using Manage.Helpers;
using Manage.Models;
using Manage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Manage.Controllers
{
    public class EthicsHotlineController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmailService emailService;
        private readonly IOptions<SmtpConfig> smtpConfig;

        public EthicsHotlineController(IUnitOfWork unitOfWork,
            IEmailService emailService,
            IOptions<SmtpConfig> smtpConfig)
        {
            this.unitOfWork = unitOfWork;
            this.emailService = emailService;
            this.smtpConfig = smtpConfig;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new EthicsHotlineViewModel()
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
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("ethics_hotline"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("ethics_hotline"),
                EthicsHotlineFormComponent = await unitOfWork.EthicsHotlineFormComponent.GetAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add_Contact_Message(EthicsHotlineFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contactMessage = new ContactMessage()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message
                };

                await unitOfWork.ContactMessage.CreateAsync(contactMessage);
                await unitOfWork.CommitAsync();

                var body = $"<h2>By {model.Name}</h2>" +
                    $"<h3 style='margin:0;'>Email:</h3>" +
                    $"<p style='margin:0;'>{model.Email}</p>" +
                    $"<h3 style='margin-bottom:0;'>Message:</h3>" +
                    $"<p style='margin:0;'>{model.Message}</p>";
                await emailService.SendEmailAsync(model.Subject, body, smtpConfig.Value.ToContactEmail);

                return Ok();
            }

            return NotFound();
        }
    }
}
