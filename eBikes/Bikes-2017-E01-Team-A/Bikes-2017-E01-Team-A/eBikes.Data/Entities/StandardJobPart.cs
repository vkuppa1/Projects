using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    public class StandardJobPart
    {
        [Key]
        public int StandardJobPartID { get; set; }

        public int StandardJobID { get; set; }

        public int PartID { get; set; }

        public int Quantity { get; set; }

        public virtual Part Part { get; set; }

        public virtual StandardJob StandardJob { get; set; }
    }
}
