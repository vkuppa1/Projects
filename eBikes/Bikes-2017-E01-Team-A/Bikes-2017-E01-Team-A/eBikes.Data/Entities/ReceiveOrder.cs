using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    public class ReceiveOrder
    {
        [Key]
        public int ReceiveOrderID { get; set; }

        public int PurchaseOrderID { get; set; }

        public DateTime? ReceiveDate { get; set; }

        public virtual ICollection<ReturnedOrderDetail> ReturnedOrderDetails { get; set; }
    }
}
