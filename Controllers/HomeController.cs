using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neerogilksample.Data.Services;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotificationService _service;

        public HomeController(ILogger<HomeController> logger, INotificationService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
                     
            var allNotifications = await _service.GetAllAsync();
            var notificationCount = allNotifications.Count();
            ViewBag.NotificationCount = notificationCount;
            return View();

        }
        public IActionResult AdminDashboard()
        {

            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
