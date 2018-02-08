using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{


    public class JobDetailPart
    {
        [Key]
        public int JobDetailPartID { get; set; }

        public int JobDetailID { get; set; }

        public int PartID { get; set; }

        public short Quantity { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal SellingPrice { get; set; }

        public virtual JobDetail JobDetail { get; set; }

        public virtual Part Part { get; set; }
    }
}
