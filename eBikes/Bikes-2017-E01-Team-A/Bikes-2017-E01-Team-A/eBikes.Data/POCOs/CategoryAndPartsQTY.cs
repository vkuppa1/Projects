using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBikes.Data.POCOs
{
    public class CategoryAndPartsQTY
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int qtyOfParts { get; set; }
    }
}
