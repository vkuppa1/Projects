using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    public class SaleRefundDetail
    {
        [Key]
        public int SaleRefundDetailID { get; set; }

        public int SaleRefundID { get; set; }

        public int PartID { get; set; }

        public int Quantity { get; set; }

        public decimal SellingPrice { get; set; }

        [StringLength(150, ErrorMessage = "Reason is limited to 150 characters.")]
        public string Reason { get; set; }

        public virtual SaleRefund SaleRefund { get; set; }
    }
}
