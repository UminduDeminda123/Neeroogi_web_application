using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Neerogilksample.Data;
using Neerogilksample.Data.Services;
using Neerogilksample.Data.Static;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class NotificationController : Controller
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allNotifications = await _service.GetAllAsync();
            //var notificationCount = allNotifications.Count();
            //ViewBag.NotificationCount = notificationCount;
            return View(allNotifications);
        }
        //Get: Notification/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("NotiDate,Type,NotiDescription")] Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return View(notification);
            }
            await _service.AddAsync(notification);
            return RedirectToAction(nameof(Index));
        }

        //Get Request
        //Doctors/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var notificationDetails = await _service.GetByIdAsync(id);
            if (notificationDetails == null) return View("NotFound");
            return View(notificationDetails);

        }

        //Doctors/Update
        public async Task<IActionResult> Edit(int id)
        {
            var notificationDetails = await _service.GetByIdAsync(id);
            if (notificationDetails == null) return View("NotFound");

            return View(notificationDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NotiDate,Type,NotiDescription")] Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return View(notification);
            }
            await _service.UpdateAsync(id, notification);
            return RedirectToAction(nameof(Index));
        }
        //Doctors/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var notificationDetails = await _service.GetByIdAsync(id);
            if (notificationDetails == null) return View("NotFound");

            return View(notificationDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notificationDetails = await _service.GetByIdAsync(id);
            if (notificationDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
