using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    public class JobDetail
    {
        [Key]

        public int JobDetailID { get; set; }

        public int JobID { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, ErrorMessage = "Description is limited to 100 characters.")]
        public string Description { get; set; }

        public decimal JobHours { get; set; }

        public string Comments { get; set; }

        public int? CouponID { get; set; }

        public bool? Completed { get; set; }

        public virtual Coupon Coupon { get; set; }


        public virtual ICollection<JobDetailPart> JobDetailParts { get; set; }

        public virtual Job Job { get; set; }
    }
}
