using Core;
using Core.Models;
using Manage.Areas.Admin.Models.ViewModels;
using Manage.Helpers;
using Manage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class VMVController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public VMVController(IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            VMVIndexViewModel model = new VMVIndexViewModel()
            {
                VMVMainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("vmv"),
                VMVComponents = await unitOfWork.VMVComponent.GetAllAsync(),
                ValuesComponents = await unitOfWork.ValuesComponent.GetAllAsync(),
                ValuesLayoutContent = await unitOfWork.SectionLayoutContent.GetByNameAsync("values"),
                PageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("vmv")
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Define_main_photo()
        {
            var main_photo = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("vmv");

            if (main_photo == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_main_photo(PageMainPhoto vmvMainPhoto)
        {
            if (ModelState.IsValid)
            {
                vmvMainPhoto.PhotoName = await fileService.UploadAsync(vmvMainPhoto.Photo);

                await unitOfWork.PageMainPhoto.CreateAsync(vmvMainPhoto);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "vmv");
            }

            return View(vmvMainPhoto);
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
                var mainPhoto = await unitOfWork.PageMainPhoto.GetPageMainPhotoAsync("vmv");

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

                    return RedirectToAction("index", "vmv");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Add_vmv_component()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_vmv_component(VMVComponent vmvComponent)
        {
            if (ModelState.IsValid)
            {
                vmvComponent.PhotoName = await fileService.UploadAsync(vmvComponent.Photo);
                vmvComponent.CreatedAt = AzDateTime.Now;

                await unitOfWork.VMVComponent.CreateAsync(vmvComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "vmv");
            }

            return View(vmvComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_vmv_component(int? id)
        {
            if (id != null)
            {
                var vmvComponent = await unitOfWork.VMVComponent.GetAsync(id);

                if (vmvComponent != null)
                {
                    VMVComponentEditViewModel model = new VMVComponentEditViewModel()
                    {
                        Id = vmvComponent.Id,
                        Title_AZ = vmvComponent.Title_AZ,
                        Title_RU = vmvComponent.Title_RU,
                        Title_EN = vmvComponent.Title_EN,
                        Title_TR = vmvComponent.Title_TR,
                        Content_AZ = vmvComponent.Content_AZ,
                        Content_RU = vmvComponent.Content_RU,
                        Content_EN = vmvComponent.Content_EN,
                        Content_TR = vmvComponent.Content_TR,
                        PhotoName = vmvComponent.PhotoName
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_vmv_component(VMVComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var vmvComponent = await unitOfWork.VMVComponent.GetAsync(model.Id);

                if (vmvComponent != null)
                {
                    if (model.Photo != null)
                    {
                        fileService.Delete(vmvComponent.PhotoName);
                        vmvComponent.PhotoName = await fileService.UploadAsync(model.Photo);
                    }

                    vmvComponent.Title_AZ = model.Title_AZ;
                    vmvComponent.Title_RU = model.Title_RU;
                    vmvComponent.Title_EN = model.Title_EN;
                    vmvComponent.Title_TR = model.Title_TR;
                    vmvComponent.Content_AZ = model.Content_AZ;
                    vmvComponent.Content_RU = model.Content_RU;
                    vmvComponent.Content_EN = model.Content_EN;
                    vmvComponent.Content_TR = model.Content_TR;

                    await unitOfWork.VMVComponent.EditAsync(vmvComponent);
                    await unitOfWork.CommitAsync();

                    return RedirectToAction("index", "vmv");
                }

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details_vmv_component(int? id)
        {
            if (id != null)
            {
                var vmvComponent = await unitOfWork.VMVComponent.GetAsync(id);

                if (vmvComponent != null)
                    return View(vmvComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_vmv_component(int? id)
        {
            if (id != null)
            {
                var vmvComponent = await unitOfWork.VMVComponent.GetAsync(id);

                if (vmvComponent != null)
                {
                    fileService.Delete(vmvComponent.PhotoName);

                    await unitOfWork.VMVComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Add_values_component()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_values_component(ValuesComponent valuesComponent)
        {
            if (ModelState.IsValid)
            {
                valuesComponent.PhotoName = await fileService.UploadAsync(valuesComponent.Photo);
                valuesComponent.CreatedAt = AzDateTime.Now;

                await unitOfWork.ValuesComponent.CreateAsync(valuesComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "vmv");
            }

            return View(valuesComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_values_component(int? id)
        {
            if (id != null)
            {
                var valuesComponent = await unitOfWork.ValuesComponent.GetAsync(id);

                if (valuesComponent != null)
                {
                    VMVComponentEditViewModel model = new VMVComponentEditViewModel()
                    {
                        Id = valuesComponent.Id,
                        Title_AZ = valuesComponent.Title_AZ,
                        Title_RU = valuesComponent.Title_RU,
                        Title_EN = valuesComponent.Title_EN,
                        Title_TR = valuesComponent.Title_TR,
                        Content_AZ = valuesComponent.Content_AZ,
                        Content_RU = valuesComponent.Content_RU,
                        Content_EN = valuesComponent.Content_EN,
                        Content_TR = valuesComponent.Content_TR,
                        PhotoName = valuesComponent.PhotoName
                    };

                    return View(model);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_values_component(VMVComponentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var valuesComponent = await unitOfWork.ValuesComponent.GetAsync(model.Id);

                if (valuesComponent != null)
                {
                    if (model.Photo != null)
                    {
                        fileService.Delete(valuesComponent.PhotoName);
                        valuesComponent.PhotoName = await fileService.UploadAsync(model.Photo);
                    }

                    valuesComponent.Title_AZ = model.Title_AZ;
                    valuesComponent.Title_RU = model.Title_RU;
                    valuesComponent.Title_EN = model.Title_EN;
                    valuesComponent.Title_TR = model.Title_TR;
                    valuesComponent.Content_AZ = model.Content_AZ;
                    valuesComponent.Content_RU = model.Content_RU;
                    valuesComponent.Content_EN = model.Content_EN;
                    valuesComponent.Content_TR = model.Content_TR;

                    await unitOfWork.ValuesComponent.EditAsync(valuesComponent);
                    await unitOfWork.CommitAsync();

                    return RedirectToAction("index", "vmv");
                }

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details_values_component(int? id)
        {
            if (id != null)
            {
                var valuesComponent = await unitOfWork.ValuesComponent.GetAsync(id);

                if (valuesComponent != null)
                    return View(valuesComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_values_component(int? id)
        {
            if (id != null)
            {
                var valuesComponent = await unitOfWork.ValuesComponent.GetAsync(id);

                if (valuesComponent != null)
                {
                    fileService.Delete(valuesComponent.PhotoName);

                    await unitOfWork.ValuesComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_Values_Layout_Content()
        {
            var layoutContent = await unitOfWork.SectionLayoutContent.GetByNameAsync("values");

            if (layoutContent == null)
                return View();

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Define_Values_Layout_Content(SectionLayoutContent sectionLayoutContent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.SectionLayoutContent.CreateAsync(sectionLayoutContent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Values_Layout_Content(int? id)
        {
            if (id != null)
            {
                var layoutContent = await unitOfWork.SectionLayoutContent.GetByNameAsync("values");

                if (layoutContent != null)
                    return View(layoutContent);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Values_Layout_Content(SectionLayoutContent sectionLayoutContent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.SectionLayoutContent.EditAsync(sectionLayoutContent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Define_Page_Access_Component()
        {
            var pageAccessComponent = await unitOfWork.PageAccessComponent.GetByPageNameAsync("vmv");

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

                return RedirectToAction("index");
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

                return RedirectToAction("details_page_access_component", "vmv", new { id = pageAccessComponent.Id });
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
    }
}
