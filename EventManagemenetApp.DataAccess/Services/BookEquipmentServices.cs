using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Services
{
    public class BookEquipmentServices : IBookEquipment
    {
        private EventContext _context;

        public BookEquipmentServices(EventContext context)
        {
            _context = context;
        }
        public int BookEquipment(BookingEquipment BookingEquipment)
        {
            try
            {
                if (BookingEquipment != null)
                {
                    _context.BookingEquipment.Add(BookingEquipment);
                    _context.SaveChanges();
                    return BookingEquipment.BookingID;
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
