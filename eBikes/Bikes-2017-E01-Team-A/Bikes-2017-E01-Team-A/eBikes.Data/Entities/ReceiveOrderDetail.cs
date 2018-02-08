using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{


    public class ReceiveOrderDetail
    {
        [Key]
        public int ReceiveOrderDetailID { get; set; }

        public int ReceiveOrderID { get; set; }

        public int PurchaseOrderDetailID { get; set; }

        public int QuantityReceived { get; set; }

        public virtual PurchaseOrderDetail PurchaseOrderDetail { get; set; }
    }
}
