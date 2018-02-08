using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    [Table("UnorderedPurchaseItemCart")]
    public class UnorderedPurchaseItemCart
    {
        [Key]
        public int CartID { get; set; }

        public int PurchaseOrderNumber { get; set; }

        [StringLength(100, ErrorMessage = "Description is limited to 100 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "VendorPartNumber is required.")]
        [StringLength(50, ErrorMessage = "VendorPartNumber is limited to 50 characters.")]
        public string VendorPartNumber { get; set; }

        public int Quantity { get; set; }
    }
}
