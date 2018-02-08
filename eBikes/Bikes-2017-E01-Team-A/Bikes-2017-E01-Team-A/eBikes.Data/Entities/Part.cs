using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace eBikes.Data.Entities
{


    public class Part
    {
        [Key]
        public int PartID { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(40, ErrorMessage = "Description is limited to 40 characters.")]
        public string Description { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal SellingPrice { get; set; }

        public int QuantityOnHand { get; set; }

        public int ReorderLevel { get; set; }

        public int QuantityOnOrder { get; set; }

        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Refundable is required.")]
        [StringLength(1, ErrorMessage = "Refundable is limited to 1 characters.")]
        public string Refundable { get; set; }

        public bool Discontinued { get; set; }

        public int VendorID { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}
