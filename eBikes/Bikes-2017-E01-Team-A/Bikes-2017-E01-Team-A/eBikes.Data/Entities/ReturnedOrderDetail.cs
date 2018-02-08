using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    public class ReturnedOrderDetail
    {
        [Key]
        public int ReturnedOrderDetailID { get; set; }

        public int ReceiveOrderID { get; set; }

        public int? PurchaseOrderDetailID { get; set; }

        [StringLength(50, ErrorMessage = "ItemDescription is limited to 50 characters.")]
        public string ItemDescription { get; set; }

        public int Quantity { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
        [StringLength(50, ErrorMessage = "Reason is limited to 50 characters.")]
        public string Reason { get; set; }

        [StringLength(50, ErrorMessage = "VendorPartNumber is limited to 50 characters.")]
        public string VendorPartNumber { get; set; }

        public virtual ReceiveOrder ReceiveOrder { get; set; }
    }
}
