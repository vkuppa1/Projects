using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{
    public class Coupon
    {
        [Key]
        public int CouponID { get; set; }

        [Required(ErrorMessage = "CouponIDValue is required.")]
        [StringLength(10, ErrorMessage = "CouponIDValue is limited to 10 characters.")]
        public string CouponIDValue { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CouponDiscount { get; set; }

        public int SalesOrService { get; set; }

        public virtual ICollection<JobDetail> JobDetails { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
