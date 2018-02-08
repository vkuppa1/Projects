using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    [Table("ShoppingCartItem")]
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemID { get; set; }

        public int ShoppingCartID { get; set; }

        public int PartID { get; set; }

        public int Quantity { get; set; }

        public virtual Part Part { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
