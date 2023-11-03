using EventManagemenetApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Interface
{
    public interface IBookingLight
    {
        int BookingLight(BookingLight bookinglight);
    }
}
