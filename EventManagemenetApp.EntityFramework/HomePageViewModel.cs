using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.EntityFramework
{
    public class HomePageViewModel
    {
        public List<Venue> Venues { get; set; }
        public List<Equipment> Equipment { get; set; }
        public List<Food> Foods { get; set; }
        public List<Flower> Flowers { get; set; }
        public List<Light> Lights { get; set; }
    }
}
