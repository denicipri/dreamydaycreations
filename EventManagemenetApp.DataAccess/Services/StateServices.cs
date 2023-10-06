using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Services
{
    public class StateServices:IState
    {
        private EventContext _context;

        public StateServices(EventContext context)
        {
            _context = context;
        }

        public List<States> ListofState(int? ID)
        {
            if (ID == null)
            {
                return new List<States>();
            }

            var listofState = (from states in _context.States
                               where states.CountryID == ID
                               select states).ToList();

            listofState.Insert(0, new States { StateID = 0, StateName = "----Select----" });

            return listofState;
        }

    }
}
