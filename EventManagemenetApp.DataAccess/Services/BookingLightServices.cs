using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Services
{
    public class BookingLightServices:IBookingLight
    {
        private EventContext _context;

        public BookingLightServices(EventContext context)
        {
            _context = context;
        }

        public int BookingLight(BookingLight bookinglight)
        {
            try
            {
                if (bookinglight != null)
                {
                    _context.BookingLight.Add(bookinglight);
                    _context.SaveChanges();
                    return bookinglight.BookLightID;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
