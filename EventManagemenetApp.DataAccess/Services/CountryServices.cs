using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Services
{
    public class CountryServices:ICountry
    {
        private EventContext _context;

        public CountryServices(EventContext context)
        {
            _context = context;
        }

        public List<Country> ListofCountry()
        {
            return _context.Country.ToList();
        }

    }
}
