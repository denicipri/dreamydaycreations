using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Services
{
    public class DishtypesServices :IDishtypes
    {
        private EventContext _context;

        public DishtypesServices(EventContext context)
        {
            _context = context;
        }

        public List<Dishtypes> GetDishtypeList()
        {
            try
            {
                return _context.Dishtypes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
