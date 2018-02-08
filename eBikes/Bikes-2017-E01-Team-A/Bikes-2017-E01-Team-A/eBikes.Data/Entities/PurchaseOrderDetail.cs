using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    public class PurchaseOrderDetail
    {

        [Key]
        public int PurchaseOrderDetailID { get; set; }

        public int PurchaseOrderID { get; set; }

        public int PartID { get; set; }

        public int Quantity { get; set; }


        public decimal PurchasePrice { get; set; }

        [StringLength(50, ErrorMessage = "VendorPartNumber is limited to 50 characters.")]
        public string VendorPartNumber { get; set; }

        public virtual Part Part { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }


        public virtual ICollection<ReceiveOrderDetail> ReceiveOrderDetails { get; set; }
    }
}
