using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace eBikes.Data.Entities
{

    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderID { get; set; }

        public int? PurchaseOrderNumber { get; set; }

        public DateTime? OrderDate { get; set; }


        public decimal TaxAmount { get; set; }

        public decimal SubTotal { get; set; }

        public bool Closed { get; set; }

        [StringLength(100, ErrorMessage = "Notes is limited to 100 characters.")]
        public string Notes { get; set; }

        public int EmployeeID { get; set; }

        public int VendorID { get; set; }


        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
