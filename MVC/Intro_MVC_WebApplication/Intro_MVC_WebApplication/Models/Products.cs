using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intro_MVC_WebApplication.Models
{
    public class Products
    {


        //Productid,ProductName,Price,UOM,SupplierName,CategoryName
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public float Price { get; set; }
        public string UOM { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
    }
}