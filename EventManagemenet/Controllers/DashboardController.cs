using Microsoft.AspNetCore.Mvc;

namespace EventManagemenet.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
