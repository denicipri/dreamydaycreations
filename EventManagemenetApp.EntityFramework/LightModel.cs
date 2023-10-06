using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.EntityFramework
{
    public class LightModel
    {
        public int LightID { get; set; }
        public string LightName { get; set; }

        [NotMapped]
        public bool LightChecked { get; set; }
    }
}
