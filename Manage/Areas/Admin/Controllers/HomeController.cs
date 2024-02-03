using System.Threading.Tasks;
using Core;
using Core.Models;
using Manage.Areas.Admin.Models.ViewModels;
using Manage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public HomeController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexViewModel()
            {
                HomeSliderComponents = await unitOfWork.HomeSliderComponent.GetAllAsync(),
                SectionLayoutContents = await unitOfWork.SectionLayoutContent.GetHomeSectionLayoutContentsAsync()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add_slider_component()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_slider_component(HomeSliderComponent sliderComponent)
        {
            if (ModelState.IsValid)
            {
                sliderComponent.PhotoName = await fileService.UploadAsync(sliderComponent.Photo);

                await unitOfWork.HomeSliderComponent.CreateAsync(sliderComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "home");
            }

            return View(sliderComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_slider_component(int? id)
        {
            if (id != null)
            {
                var sliderComponent = await unitOfWork.HomeSliderComponent.GetAsync(id);

                if (sliderComponent != null)
                {
                    HomeSliderComponentEditViewModel model = new HomeSliderComponentEditViewModel()
                    {
                        Id = sliderComponent.Id,
                        Title_AZ = sliderComponent.Title_AZ,
                        Title_RU = sliderComponent.Title_RU,
                        Title_EN = sliderComponent.Title_EN,
                        Title_TR = sliderComponent.Title_TR,
                        ButtonText_AZ = sliderComponent.ButtonText_AZ,
                        ButtonText_RU = sliderComponent.ButtonText_RU,
                        ButtonText_EN = sliderComponent.ButtonText_EN,
                        ButtonText_TR = sliderComponent.ButtonText_TR,
                        Link = sliderComponent.Link,
                        PhotoName = sliderComponent.PhotoName
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_slider_component(HomeSliderComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sliderComponent = await unitOfWork.HomeSliderComponent.GetAsync(model.Id);

                if (sliderComponent != null)
                {
                    if (model.Photo != null)
                    {
                        fileService.Delete(sliderComponent.PhotoName);
                        sliderComponent.PhotoName = await fileService.UploadAsync(model.Photo);
                    }

                    sliderComponent.Title_AZ = model.Title_AZ;
                    sliderComponent.Title_RU = model.Title_RU;
                    sliderComponent.Title_EN = model.Title_EN;
                    sliderComponent.Title_TR = model.Title_TR;
                    sliderComponent.ButtonText_AZ = model.ButtonText_AZ;
                    sliderComponent.ButtonText_RU = model.ButtonText_RU;
                    sliderComponent.ButtonText_EN = model.ButtonText_EN;
                    sliderComponent.ButtonText_TR = model.ButtonText_TR;
                    sliderComponent.Link = model.Link;

                    await unitOfWork.HomeSliderComponent.EditAsync(sliderComponent);
                    await unitOfWork.CommitAsync();

                    return RedirectToAction("detail_slider_component", "home", new { id = sliderComponent.Id });
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Detail_slider_component(int? id)
        {
            if (id != null)
            {
                var sliderComponent = await unitOfWork.HomeSliderComponent.GetAsync(id);

                if (sliderComponent != null)
                    return View(sliderComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_slider_component(int? id)
        {
            if (id != null)
            {
                var homeSliderComponent = await unitOfWork.HomeSliderComponent.GetAsync(id);
                if (homeSliderComponent != null)
                {
                    fileService.Delete(homeSliderComponent.PhotoName);

                    await unitOfWork.HomeSliderComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Add_Section_Layout_Content()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Section_Layout_Content(SectionLayoutContent sectionLayoutContent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.SectionLayoutContent.CreateAsync(sectionLayoutContent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(sectionLayoutContent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Section_Layout_Content(int? id)
        {
            if (id != null)
            {
                var sectionLayoutContent = await unitOfWork.SectionLayoutContent.GetAsync(id);

                if (sectionLayoutContent != null)
                    return View(sectionLayoutContent);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Section_Layout_Content(SectionLayoutContent sectionLayoutContent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.SectionLayoutContent.EditAsync(sectionLayoutContent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("detail_section_layout_content", "home", new { id = sectionLayoutContent.Id });
            }

            return View(sectionLayoutContent);
        }

        [HttpGet]
        public async Task<IActionResult> Detail_Section_Layout_Content(int? id)
        {
            if (id != null)
            {
                var sectionLayoutContent = await unitOfWork.SectionLayoutContent.GetAsync(id);

                if (sectionLayoutContent != null)
                    return View(sectionLayoutContent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_Section_Layout_Content(int? id)
        {
            if (id != null)
            {
                var sectionLayoutContent = await unitOfWork.SectionLayoutContent.GetAsync(id);

                if (sectionLayoutContent != null)
                {
                    await unitOfWork.SectionLayoutContent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }


    }
}
