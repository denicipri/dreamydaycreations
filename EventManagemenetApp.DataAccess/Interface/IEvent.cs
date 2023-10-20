using EventManagemenetApp.EntityFramework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Interface
{
    public interface IEvent
    {
        IEnumerable<Event> GetAllEvents();
    }
}
