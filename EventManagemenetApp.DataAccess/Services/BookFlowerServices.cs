using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Services
{
    public class BookFlowerServices : IBookFlower
    {
        private EventContext _context;

        public BookFlowerServices(EventContext context)
        {
            _context = context;
        }

        public int BookFlower(BookingFlower bookingflower)
        {
            try
            {
                if (bookingflower != null)
                {
                    _context.BookingFlower.Add(bookingflower);
                    _context.SaveChanges();
                    return bookingflower.BookingFlowerID;
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
