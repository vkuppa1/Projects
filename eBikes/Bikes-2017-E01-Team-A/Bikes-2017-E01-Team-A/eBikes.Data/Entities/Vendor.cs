using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{
    public class Vendor
    {
        [Key]
        public int VendorID { get; set; }

        [Required(ErrorMessage = "VendorName is required.")]
        [StringLength(100, ErrorMessage = "VendorName is limited to 100 characters.")]
        public string VendorName { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [StringLength(12, ErrorMessage = "Phone is limited to 12 characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(30, ErrorMessage = "Address is limited to 30 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(30, ErrorMessage = "City is limited to 30 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "ProvinceID is required.")]
        [StringLength(2, ErrorMessage = "ProvinceID is limited to 2 characters.")]
        public string ProvinceID { get; set; }

        [Required(ErrorMessage = "PostalCode is required.")]
        [StringLength(6, ErrorMessage = "PostalCode is limited to 6 characters.")]
        public string PostalCode { get; set; }

        public virtual ICollection<Part> Parts { get; set; }


        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
