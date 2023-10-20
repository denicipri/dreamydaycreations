using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EventManagemenet.Controllers
{
    [Route("api/[controller]")]
    public class VenueDataController : Controller
    {
        private IVenue _IVenue;
        public VenueDataController(IVenue IVenue)
        {
            _IVenue = IVenue;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Venue> Get()
        {
            return _IVenue.ShowAllVenue();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Venue Get(int id)
        {
            return _IVenue.VenueByID(id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _IVenue.DeleteVenue(id);
            return "Success";
        }
    }
}
