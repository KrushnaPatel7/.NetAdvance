using Day2_Demo_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day2_Demo_Razor.Controllers
{
    public class CustOrdersController : Controller
    {

        // GET: CustOrders

        List<CustOrders> custlist = new List<CustOrders>() {
              new CustOrders{CustomerId=1,Name="Jack" },
              new CustOrders{CustomerId=2,Name="Jill"}
        };



        List<Orders> orders = new List<Orders>() {
            new Orders{OrderID=1,OrderDate=new DateTime(2001,07,11),Amt=100000,CustomerID=1 },
            new Orders{OrderID=2,OrderDate=new DateTime(2001,07,11),Amt=20000,CustomerID=1},
            new Orders{OrderID=3,OrderDate=new DateTime(2001,07,11),Amt=30000, CustomerID = 1},
            new Orders{OrderID=4,OrderDate=new DateTime(2001,07,11),Amt=40000, CustomerID = 1},
            new Orders{OrderID=10,OrderDate=new DateTime(2001,07,11),Amt=10000,CustomerID=2 },
            new Orders{OrderID=20 , OrderDate=new DateTime(2001,07,11),Amt=5000,CustomerID = 2}
        };



        public ActionResult Index()
        {
            var custOrders = custlist.Join(orders, c => c.CustomerId, p => p.CustomerID, (c1, p) => new { Customerid = c1.CustomerId, Custname = c1.Name, OrderDate = p.OrderDate, Amt = p.Amt, OrderID = p.OrderID });

            List<DispalyData> custdata = new List<DispalyData>();
            foreach (var item in custOrders)
            {
                custdata.Add(new DispalyData { CustomerId = item.Customerid, OrderID = item.OrderID, OrderDate = item.OrderDate.ToShortDateString(), Amt = item.Amt });
            }

            ViewBag.AllData = custdata;

            return View();
        }


















    }
}