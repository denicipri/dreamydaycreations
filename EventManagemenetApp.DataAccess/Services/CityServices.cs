using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Services
{
    public class CityServices:ICity
    {
        private EventContext _context;

        public CityServices(EventContext context)
        {
            _context = context;
        }

        public List<City> ListofCity(int? ID)
        {
            if (ID == null)
            {
                return new List<City>();
            }

            var listofcities = (from cities in _context.City
                                where cities.StateID == ID
                                select cities).ToList();

            listofcities.Insert(0, new City { CityID = 0, CityName = "----Select----" });

            return listofcities;
        }
    }
}
