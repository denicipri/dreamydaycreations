using EventManagemenet.Models;
using EventManagemenetApp.DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventManagemenet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IVenue _IVenue;

        public HomeController(IVenue IVenue,ILogger<HomeController> logger)
        {
            _IVenue = IVenue;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var data = _IVenue.EventLists();
            return View(data);
        } 
        
        public IActionResult AboutUs()
        {
            return View();
        }  
        
        public IActionResult Contact()
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