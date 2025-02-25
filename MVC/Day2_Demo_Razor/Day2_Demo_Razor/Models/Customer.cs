using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day2_Demo_Razor.Models
{
    public class Customer
    {
        //--------------------------- Task 1 -----------------------
        public int Custid { get; set; }
        public string Custname { get; set; }

        public int Rating { get; set; }

        public string City { get; set; }
    }
}