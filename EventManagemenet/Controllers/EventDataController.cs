using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EventManagemenet.Controllers
{
    [Route("api/[controller]")]
    public class EventDataController : Controller
    {
        private IEvent _IEvent;
        public EventDataController(IEvent IEvent)
        {
            _IEvent = IEvent;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            try
            {
                return _IEvent.GetAllEvents();
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
