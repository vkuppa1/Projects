using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBikes.Data.POCOs
{
    public class OrderSummary
    {
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GST { get; set; }
        public decimal Total { get; set; }
        public List<string> DiscountinuedItems { get; set; }
        public List<int> DiscountinuedItemsID { get; set; }
        public List<string> OutOfParts { get; set; }
        public List<int> OutOfPartsID { get; set; }
    }
}
