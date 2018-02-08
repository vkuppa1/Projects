using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    public class Sale
    {
        [Key]
        public int SaleID { get; set; }

        public DateTime SaleDate { get; set; }

        [StringLength(128, ErrorMessage = "UserName is limited to 128 characters.")]
        public string UserName { get; set; }

        public int EmployeeID { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal SubTotal { get; set; }

        public int? CouponID { get; set; }

        [Required(ErrorMessage = "PaymentType is required.")]
        [StringLength(1, ErrorMessage = "PaymentType is limited to 1 characters.")]
        public string PaymentType { get; set; }

        public Guid? PaymentToken { get; set; }

        public int? JobID { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; }

        public virtual ICollection<SaleRefund> SaleRefunds { get; set; }
    }
}
