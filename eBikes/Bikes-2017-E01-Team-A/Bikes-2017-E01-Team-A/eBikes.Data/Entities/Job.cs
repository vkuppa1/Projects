using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    public class Job
    {
        [Key]

        public int JobID { get; set; }

        public DateTime JobDateIn { get; set; }

        public DateTime? JobDateStarted { get; set; }

        public DateTime? JobDateDone { get; set; }

        public DateTime? JobDateOut { get; set; }

        public int CustomerID { get; set; }

        public int EmployeeID { get; set; }

        public decimal ShopRate { get; set; }

        [Required(ErrorMessage = "StatusCode is required.")]
        [StringLength(1, ErrorMessage = "StatusCode is limited to 1 characters.")]
        public string StatusCode { get; set; }

        [Required(ErrorMessage = "VehicleIdentification is required.")]
        [StringLength(50, ErrorMessage = "VehicleIdentification is limited to 50 characters.")]
        public string VehicleIdentification { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<JobDetail> JobDetails { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
