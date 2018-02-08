using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    public class SaleRefund
    {
        [Key]
        public int SaleRefundID { get; set; }

        public DateTime SaleRefundDate { get; set; }

        public int SaleID { get; set; }

        public int EmployeeID { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal SubTotal { get; set; }

        public virtual ICollection<SaleRefundDetail> SaleRefundDetails { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
