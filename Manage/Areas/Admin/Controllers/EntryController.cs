using System.Threading.Tasks;
using Core;
using Core.Models;
using Manage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Areas.Admin.Controllers
{
    //[Area("Admin")]
    //[Authorize]
    //public class EntryController : Controller
    //{
    //    private readonly IUnitOfWork unitOfWork;
    //    private readonly IFileService fileService;

    //    public EntryController(IUnitOfWork unitOfWork,
    //        IFileService fileService)
    //    {
    //        this.unitOfWork = unitOfWork;
    //        this.fileService = fileService;
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> Index()
    //    {
    //        var sliderComponents = await unitOfWork.SliderComponent.GetEntrySliderComponentsAsync();
    //        return View(sliderComponents);
    //    }

    //    [HttpGet]
    //    public IActionResult Add_slider_component()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Add_slider_component(HomeSliderComponent sliderComponent)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            sliderComponent.PhotoName = await fileService.UploadAsync(sliderComponent.Photo);

    //            await unitOfWork.SliderComponent.CreateAsync(sliderComponent);
    //            await unitOfWork.CommitAsync();

    //            return RedirectToAction("index", "entry");
    //        }

    //        return View(sliderComponent);
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> Delete_slider_component(int? id)
    //    {
    //        if (id != null)
    //        {
    //            var entrySliderComponent = await unitOfWork.SliderComponent.GetAsync(id);

    //            if (entrySliderComponent != null)
    //            {
    //                fileService.Delete(entrySliderComponent.PhotoName);

    //                await unitOfWork.SliderComponent.DeleteAsync(id);
    //                await unitOfWork.CommitAsync();

    //                return Ok();
    //            }
    //        }

    //        return NotFound();
    //    }
    //}
}
