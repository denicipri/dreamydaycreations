using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EventManagemenet.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private ICountry _ICountry;

        public CountryController(ICountry ICountry)
        {
            _ICountry = ICountry;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            try
            {
                var listofCountry = _ICountry.ListofCountry();
                listofCountry.Insert(0, new Country { CountryID = 0, Name = "----Select----" });
                return listofCountry;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
