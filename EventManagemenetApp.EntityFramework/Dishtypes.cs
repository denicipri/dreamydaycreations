using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.EntityFramework
{
    public class Dishtypes
    {
        [Key]
        public int ID { get; set; }
        public string Dishtype { get; set; }
    }
}
