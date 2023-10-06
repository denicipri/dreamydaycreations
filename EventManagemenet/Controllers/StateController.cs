using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EventManagemenet.Controllers
{
    [Route("api/[controller]")]
    public class StateController : Controller
    {
        private IState _IState;

        public StateController(IState IState)
        {
            _IState = IState;
        }

        // POST api/values
        [HttpPost]
        public List<States> Post(string id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }

                var listofState = _IState.ListofState(Convert.ToInt32(id));
                return listofState;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
