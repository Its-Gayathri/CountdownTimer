using CountdownTimer.Models;
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

        public HomeController(ILogger<HomeController> logger, IFlowObjectForHomePage flowObjectForHomePage)
        {
            _logger = logger;
            this.flowObjectForHomePage = flowObjectForHomePage;
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
