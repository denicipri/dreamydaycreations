using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.EntityFramework
{
    public class BookingDetails
    {
        [Key]
        public int BookingID { get; set; }
        public string BookingNo { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string BookingApproval { get; set; }
        public DateTime? BookingApprovalDate { get; set; }
        public string BookingCompletedFlag { get; set; }
    }

    [NotMapped]
    public class BookingDetailTemp
    {
        public int BookingID { get; set; }
        public string BookingNo { get; set; }
        public string BookingDate { get; set; }
        public string Createdby { get; set; }
        public string CreatedDate { get; set; }
        public string BookingApproval { get; set; }
        public string BookingApprovalDate { get; set; }
    }
}
