using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day2_Demo_Razor.Models
{
    public class CustOrders
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }


    }

    public class Orders
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amt { get; set; }
        public int CustomerID { get; set; }


    }


    public class DispalyData
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public double Amt { get; set; }


    }
}