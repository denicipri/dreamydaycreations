using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.EntityFramework
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        public string Name { get; set; }
    }
}
