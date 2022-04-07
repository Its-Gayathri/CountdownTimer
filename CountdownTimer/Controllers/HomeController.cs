﻿using CountdownTimer.Models;
using CountdownTimer.ServiceProviders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CountdownTimer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlowObjectForHomePage flowObjectForHomePage;
        private readonly IFlowObjectForAddingReminder flowObjectForAddingReminder;

        public HomeController(ILogger<HomeController> logger, IFlowObjectForHomePage flowObjectForHomePage, IFlowObjectForAddingReminder flowObjectForAddingReminder)
        {
            _logger = logger;
            this.flowObjectForHomePage = flowObjectForHomePage;
            this.flowObjectForAddingReminder = flowObjectForAddingReminder;
        }

      
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Timer()
        {
            TimerPageViewModel reminderViewModel = new TimerPageViewModel();
            reminderViewModel = flowObjectForHomePage.Flow();
            return View(reminderViewModel);
        }
        [HttpPost]
        public bool AddReminder(ReminderViewModel reminderViewModel)
        {
            bool reminderAdded = flowObjectForAddingReminder.Flow(reminderViewModel);
            return reminderAdded;
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
