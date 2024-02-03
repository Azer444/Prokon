using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class NavController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public NavController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var navTitleComponents = await unitOfWork.NavTitleComponent.GetAllAsync();
            return View(navTitleComponents);
        }

        [HttpGet]
        public IActionResult Add_Title_Component()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Title_Component(NavTitleComponent navTitleComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.NavTitleComponent.CreateAsync(navTitleComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(navTitleComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Title_Component(int? id)
        {
            if (id != null)
            {
                var navTitleComponent = await unitOfWork.NavTitleComponent.GetAsync(id);
                if (navTitleComponent != null)
                    return View(navTitleComponent);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Title_Component(NavTitleComponent navTitleComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.NavTitleComponent.EditAsync(navTitleComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(navTitleComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Detail_Title_Component(int? id)
        {
            if (id != null)
            {
                var navTitleComponent = await unitOfWork.NavTitleComponent.GetAsync(id);
                if (navTitleComponent != null)
                    return View(navTitleComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_Title_Component(int? id)
        {
            if (id != null)
            {
                var navTitleComponent = await unitOfWork.NavTitleComponent.GetAsync(id);
                if (navTitleComponent != null)
                {
                    await unitOfWork.NavTitleComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> Add_Component(int? id)
        {
            if (id != null)
            {
                var navTitleComponent = await unitOfWork.NavTitleComponent.GetAsync(id);

                if (navTitleComponent != null)
                    return View();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Component(NavComponent navComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.NavComponent.CreateAsync(navComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("detail_title_component", "nav", new { id = navComponent.NavTitleComponentId });
            }

            return View(navComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Component(int? id)
        {
            if (id != null)
            {
                var navComponent = await unitOfWork.NavComponent.GetAsync(id);

                if (navComponent != null)
                    return View(navComponent);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_Component(NavComponent navComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.NavComponent.EditAsync(navComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("detail_title_component", "nav", new { id = navComponent.NavTitleComponentId });
            }

            return View(navComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Detail_Component(int? id)
        {
            if (id != null)
            {
                var navComponent = await unitOfWork.NavComponent.GetAsync(id);

                if (navComponent != null)
                    return View(navComponent);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete_Component(int? id)
        {
            if (id != null)
            {
                var navComponent = await unitOfWork.NavComponent.GetAsync(id);
                if (navComponent != null)
                {
                    await unitOfWork.NavComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Add_SubComponent(int? id)
        {
            if (id != null)
            {
                var navComponent = await unitOfWork.NavComponent.GetAsync(id);

                if (navComponent != null)
                    return View();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add_SubComponent(NavSubComponent navSubComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.NavSubComponent.CreateAsync(navSubComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("detail_component", "nav", new { id = navSubComponent.NavComponentId });
            }

            return View(navSubComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit_SubComponent(int? id)
        {
            if (id != null)
            {
                var navSubComponent = await unitOfWork.NavSubComponent.GetAsync(id);

                if (navSubComponent != null)
                    return View(navSubComponent);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit_SubComponent(NavSubComponent navSubComponent)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.NavSubComponent.EditAsync(navSubComponent);
                await unitOfWork.CommitAsync();

                return RedirectToAction("detail_component", "nav", new { id = navSubComponent.NavComponentId });
            }

            return View(navSubComponent);
        }

        [HttpGet]
        public async Task<IActionResult> Delete_SubComponent(int? id)
        {
            if (id != null)
            {
                var navSubComponent = await unitOfWork.NavSubComponent.GetAsync(id);
                if (navSubComponent != null)
                {
                    await unitOfWork.NavSubComponent.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }
    }
}
