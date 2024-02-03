using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Manage.Areas.Admin.Models.ViewModels;
using Core;
using Core.Models;
using Manage.Services;
using Manage.Helpers;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin, HR")]
    public class CareerController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public CareerController(IUnitOfWork unitOfWork,
           IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Page()
        {
            var model = new CareerPageViewModel()
            {
                PageMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("career"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("career"),
                ContentAccessComponent = await unitOfWork.ContentAccessComponent.GetByPageNameAsync("career"),
                JobComponents = await unitOfWork.CareerComponent.GetAllByTypeAsync("job"),
                InternshipComponents = await unitOfWork.CareerComponent.GetAllByTypeAsync("internship"),
                CareerFormComponent = await unitOfWork.CareerFormComponent.GetAsync(),
                CareerAppContent = await unitOfWork.CareerAppContent.GetAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("career");

            if (mainPhoto == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto careerMainPhoto)
        {
            if (ModelState.IsValid)
            {
                careerMainPhoto.PhotoName = await fileService.UploadAsync(careerMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(careerMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("page", "career");
            }

            return View(careerMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("career");

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

                    return RedirectToAction("page", "career");
                }

                return NotFound();
            }

            return View(model);
        }
       

        [HttpGet]
        public IActionResult Add_Job_Component()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Job_Component(CareerComponent careerComponent)
        {
            if (ModelState.IsValid)
            {
                careerComponent.PhotoName = await fileService.UploadAsync(careerComponent.Photo);
                careerComponent.CreatedAt = AzDateTime.Now;

                await unitOfWork.CareerComponent.CreateAsync(careerComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("page");
            }

            return View(careerComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Job_Component(int? id)
        {
            if (id != null)
            {
                var careerComponent = await unitOfWork.CareerComponent.GetAsync(id);

                if (careerComponent != null)
                {
                    CareerComponentEditViewModel model = new CareerComponentEditViewModel()
                    {
                        Id = careerComponent.Id,
                        Content_AZ = careerComponent.Content_AZ,
                        Content_RU = careerComponent.Content_RU,
                        Content_EN = careerComponent.Content_EN,
                        Content_TR = careerComponent.Content_TR,
                        PhotoName = careerComponent.PhotoName
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Job_Component(CareerComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var careerComponent = await unitOfWork.CareerComponent.GetAsync(model.Id);

                if (model.Photo != null)
                {
                    fileService.Delete(careerComponent.PhotoName);
                    careerComponent.PhotoName = await fileService.UploadAsync(model.Photo);
                }

                careerComponent.Content_AZ = model.Content_AZ;
                careerComponent.Content_RU = model.Content_RU;
                careerComponent.Content_EN = model.Content_EN;
                careerComponent.Content_TR = model.Content_TR;

                await unitOfWork.CareerComponent.EditAsync(careerComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details_job_component","career",new { id = careerComponent.Id });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details_Job_Component(int? id)
        {
            if (id != null)
            {
                var careerComponent = await unitOfWork.CareerComponent.GetAsync(id);

                if (careerComponent != null)
                    return View(careerComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_Job_Component(int? id)
        {
            if (id != null)
            {
                var careerComponent = await unitOfWork.CareerComponent.GetAsync(id);

                if (careerComponent != null)
                {
                    fileService.Delete(careerComponent.PhotoName);

                    await unitOfWork.CareerComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Add_Internship_Component()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Internship_Component(CareerComponent careerComponent)
        {
            if (ModelState.IsValid)
            {
                careerComponent.PhotoName = await fileService.UploadAsync(careerComponent.Photo);
                careerComponent.CreatedAt = AzDateTime.Now;

                await unitOfWork.CareerComponent.CreateAsync(careerComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("page");
            }

            return View(careerComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Internship_Component(int? id)
        {
            if (id != null)
            {
                var careerComponent = await unitOfWork.CareerComponent.GetAsync(id);

                if (careerComponent != null)
                {
                    CareerComponentEditViewModel model = new CareerComponentEditViewModel()
                    {
                        Id = careerComponent.Id,
                        Content_AZ = careerComponent.Content_AZ,
                        Content_RU = careerComponent.Content_RU,
                        Content_EN = careerComponent.Content_EN,
                        Content_TR = careerComponent.Content_TR,
                        PhotoName = careerComponent.PhotoName
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Internship_Component(CareerComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var careerComponent = await unitOfWork.CareerComponent.GetAsync(model.Id);

                if (model.Photo != null)
                {
                    fileService.Delete(careerComponent.PhotoName);
                    careerComponent.PhotoName = await fileService.UploadAsync(model.Photo);
                }

                careerComponent.Content_AZ = model.Content_AZ;
                careerComponent.Content_RU = model.Content_RU;
                careerComponent.Content_EN = model.Content_EN;
                careerComponent.Content_TR = model.Content_TR;

                await unitOfWork.CareerComponent.EditAsync(careerComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details_internship_component","career", new { id = careerComponent.Id });
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details_Internship_Component(int? id)
        {
            if (id != null)
            {
                var careerComponent = await unitOfWork.CareerComponent.GetAsync(id);

                if (careerComponent != null)
                    return View(careerComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_Internship_Component(int? id)
        {
            if (id != null)
            {
                var careerComponent = await unitOfWork.CareerComponent.GetAsync(id);

                if (careerComponent != null)
                {
                    fileService.Delete(careerComponent.PhotoName);

                    await unitOfWork.CareerComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_app_content()
        {
            var appContent = await unitOfWork.CareerAppContent.GetAsync();

            if (appContent == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_app_content(CareerAppContent careerAppContent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.CareerAppContent.CreateAsync(careerAppContent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("page");
            }

            return View(careerAppContent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_app_content()
        {
            var appContent = await unitOfWork.CareerAppContent.GetAsync();

            if (appContent != null)
                return View(appContent);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_app_content(CareerAppContent careerAppContent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.CareerAppContent.EditAsync(careerAppContent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details_app_content", "career");
            }

            return View(careerAppContent);
        }

        [HttpGet]
        public async Task<IActionResult> Details_app_content()
        {
            var appContent = await unitOfWork.CareerAppContent.GetAsync();

            if (appContent != null)
                return View(appContent);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_form_component()
        {
            var formComponent = await unitOfWork.CareerFormComponent.GetAsync();

            if (formComponent == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_form_component(CareerFormComponent careerFormComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.CareerFormComponent.CreateAsync(careerFormComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("page");
            }

            return View(careerFormComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_form_component()
        {
            var formComponent = await unitOfWork.CareerFormComponent.GetAsync();

            if (formComponent != null)
                return View(formComponent);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_form_component(CareerFormComponent careerFormComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.CareerFormComponent.EditAsync(careerFormComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details_form_component", "career");
            }

            return View(careerFormComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Details_form_component()
        {
            var formComponent = await unitOfWork.CareerFormComponent.GetAsync();

            if (formComponent != null)
                return View(formComponent);

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("career");

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

                return RedirectToAction("details_page_access_component", "career", new { id = pageAccessComponent.Id });
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
            var pageAccessComponent = await unitOfWork.ContentAccessComponent.GetByPageNameAsync("career");

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

                return RedirectToAction("details_content_access_component", "career", new { id = contentAccessComponent.Id });
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
            var model = new CareerIndexViewModel()
            {
                JobOpportunities = await unitOfWork.Opportunity.GetAllByTypeAsync("job"),
                InternshipOpportunities = await unitOfWork.Opportunity.GetAllByTypeAsync("internship"),
                GeneralApplies = await unitOfWork.GeneralApply.GetAllAsync()
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult Add_Job_Opportunity()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Job_Opportunity(Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                opportunity.CreatedAt = AzDateTime.Now;

                await unitOfWork.Opportunity.CreateAsync(opportunity);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(opportunity);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Job_Opportunity(int? id)
        {
            if (id != null)
            {
                var jobOpportunity = await unitOfWork.Opportunity.GetAsync(id);

                if (jobOpportunity != null)
                    return View(jobOpportunity);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Job_Opportunity(Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Opportunity.EditAsync(opportunity);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details_job_opportunity", "career", new { id = opportunity.Id });
            }

            return View(opportunity);
        }

        [HttpGet]
        public async Task<IActionResult> Details_Job_Opportunity(int? id)
        {
            if (id != null)
            {
                var jobOpportunity = await unitOfWork.Opportunity.GetAsync(id);

                if (jobOpportunity != null)
                    return View(jobOpportunity);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_Job_Opportunity(int? id)
        {
            if (id != null)
            {
                var jobOpportunity = await unitOfWork.Opportunity.GetAsync(id);

                if (jobOpportunity != null)
                {
                    await unitOfWork.Opportunity.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Add_Internship_Opportunity()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Internship_Opportunity(Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                opportunity.CreatedAt = AzDateTime.Now;

                await unitOfWork.Opportunity.CreateAsync(opportunity);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(opportunity);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Internship_Opportunity(int? id)
        {
            if (id != null)
            {
                var internshipOpportunity = await unitOfWork.Opportunity.GetAsync(id);

                if (internshipOpportunity != null)
                    return View(internshipOpportunity);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Internship_Opportunity(Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Opportunity.EditAsync(opportunity);
                await unitOfWork.CommitAsync();

                return RedirectToAction("details_internship_opportunity", "career", new { id = opportunity.Id });
            }

            return View(opportunity);
        }

        [HttpGet]
        public async Task<IActionResult> Details_Internship_Opportunity(int? id)
        {
            if (id != null)
            {
                var internshipOpportunity = await unitOfWork.Opportunity.GetAsync(id);

                if (internshipOpportunity != null)
                    return View(internshipOpportunity);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_Internship_Opportunity(int? id)
        {
            if (id != null)
            {
                var internshipOpportunity = await unitOfWork.Opportunity.GetAsync(id);

                if (internshipOpportunity != null)
                {
                    await unitOfWork.Opportunity.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Opportunity_Applies(int? id)
        {
            if (id != null)
            {
                var opportunity = await unitOfWork.Opportunity.GetAsync(id);

                if (opportunity != null)
                    return View(opportunity);
            }

            return NotFound();
        }
    }
}
