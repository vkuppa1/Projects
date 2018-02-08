
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{


    [Table("OnlineCustomer")]
    public class OnlineCustomer
    {
        [Key]
        public int OnlineCustomerID { get; set; }

        [StringLength(128, ErrorMessage = "Description is limited to 128 characters.")]
        public string UserName { get; set; }

        public Guid? TrackingCookie { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
