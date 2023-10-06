using Microsoft.AspNetCore.Mvc;

namespace EventManagemenet.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
