using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day2_Demo_Razor.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int CategoryId { get; set; }

    }
}