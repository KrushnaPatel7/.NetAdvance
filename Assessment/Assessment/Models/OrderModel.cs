using DB_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assessment.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual OrderModel Order { get; set; }
        public virtual Product Product { get; set; }
    }
}