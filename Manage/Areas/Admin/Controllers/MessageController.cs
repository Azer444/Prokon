using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager, Admin")]
    public class MessageController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public MessageController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contactMessages = await unitOfWork.ContactMessage.GetAllAsync();
            return View(contactMessages);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var contactMessage = await unitOfWork.ContactMessage.GetAsync(id);

                if (contactMessage != null)
                    return View(contactMessage);
            }

            return NotFound();
        }
    }
}
