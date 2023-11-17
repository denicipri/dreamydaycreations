using EventManagemenet.Filters;
using EventManagemenetApp.DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EventManagemenet.Controllers
{
    [ValidateUserSession]
    public class PrintOrderController : Controller
    {
        private ITotalbilling _ITotalbilling;
        public PrintOrderController(ITotalbilling ITotalbilling)
        {
            _ITotalbilling = ITotalbilling;
        }

        [HttpGet]
        public IActionResult Print(string BookingNo)
        {
            try
            {
                if (string.IsNullOrEmpty(BookingNo))
                {
                    return RedirectToAction("AllBookings", "ShowBookingDetails");
                }

                var details = _ITotalbilling.GetBillingDetailsbyBookingNo(BookingNo);

                return View(details);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
