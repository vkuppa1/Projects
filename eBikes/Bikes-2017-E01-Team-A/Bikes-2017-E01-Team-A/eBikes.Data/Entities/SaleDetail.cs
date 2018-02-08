﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Data.Entities
{

    public class SaleDetail
    {
        [Key]
        public int SaleDetailID { get; set; }

        public int SaleID { get; set; }

        public int PartID { get; set; }

        public int Quantity { get; set; }

        public decimal SellingPrice { get; set; }

        public bool Backordered { get; set; }

        public DateTime? ShippedDate { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
