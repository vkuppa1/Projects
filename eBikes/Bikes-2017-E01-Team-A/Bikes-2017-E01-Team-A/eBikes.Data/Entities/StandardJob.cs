using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    public class StandardJob
    {
        [Key]
        public int StandardJobID { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, ErrorMessage = "Description is limited to 100 characters.")]
        public string Description { get; set; }

        public decimal StandardHours { get; set; }

        public virtual ICollection<StandardJobPart> StandardJobParts { get; set; }
    }
}