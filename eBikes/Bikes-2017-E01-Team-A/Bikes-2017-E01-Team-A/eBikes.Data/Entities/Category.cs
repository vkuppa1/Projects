using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{


    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(40, ErrorMessage = "Description is limited to 40 characters.")]
        public string Description { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
