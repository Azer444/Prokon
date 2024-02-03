using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core;
using Core.Models;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class CountryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CountryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var countries = await unitOfWork.Country.GetAllAsync();
            return View(countries);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Country country)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Country.CreateAsync(country);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "country");
            }

            return View(country);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var country = await unitOfWork.Country.GetAsync(id);

                if (country != null)
                    return View(country);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Country.EditAsync(country);
                await unitOfWork.CommitAsync();

                return RedirectToAction("index", "country");
            }

            return View(country);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var country = await unitOfWork.Country.GetAsync(id);

                if (country != null)
                    return View(country);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var country =  await unitOfWork.Country.GetAsync(id);

                if (country != null)
                {
                    await unitOfWork.Country.DeleteAsync(id);
                    await unitOfWork.CommitAsync();

                    return Ok();
                }
            }

            return NotFound();
        }
    }
}

