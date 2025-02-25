using Day2_Demo_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day2_Demo_Razor.Controllers
{
    public class CustomerController : Controller
    {
        //------------------------- Task 2-------------------------
        static List<Customer> customer = new List<Customer>() {
        new Customer{Custid=1,Custname="Krushna",Rating=4,City="Pune"},
        new Customer{Custid=2,Custname="Diya",Rating=3,City="Mumbai"},
        new Customer{Custid=3,Custname="Jiya",Rating=2,City="Mumbai"},
        new Customer{Custid=4,Custname="Siya",Rating=4,City="Pune"},
        new Customer{Custid=5,Custname="Raj",Rating=3,City="Pune"},
  };
        // GET: Customer
        //----------------------Task 6----------------------------
        public ActionResult Index()
        {
            return View(customer);
        }
        //---------------------------- Task 3-----------------------
        public ActionResult FilterByCity()
        {
            //Empty view
            return View();
        }
        [HttpPost]
        public ActionResult GetCustomersByCity(string city)
        {
            List<Customer> data = customer.Where(s1 => s1.City == city).ToList();
            return View(data);
        }
        //----------------------- Task 4------------------------------------------
        public ActionResult OrderCustomersByRating()
        {
            var data = customer.OrderBy(x => x.Rating).Select(n => new { customername = n.Custname, rating=n.Rating }).ToList();
            List<Customer> cdata = new List<Customer>();
            foreach (var item in data)
            {
                cdata.Add(new Customer { Custname = item.customername, Rating=item.rating });

            }

            return View(cdata);
        }

       //-----------------------------Task 5--------------------------------------
        public ActionResult GroupCustomersByRating()
        {
            var data = customer.GroupBy(c => c.Rating).ToList();

            List<Customer> clist = new List<Customer>();
            foreach (var item in data)
            {

                var d = item.Select(c => new { customername = c.Custname, rating = c.Rating });
                foreach (var item1 in d)
                {
                    clist.Add(new Customer { Rating = item.Key, Custname=item1.customername });
                }
            }
            ViewBag.CustomerDataGrouped = clist;
            return View();
        }
        //-------------------Task 7---------------------------------------
        public ActionResult DropdownByCity()
        {
            //Empty view
            return View();
        }
        [HttpGet]
        public ActionResult DropdownCustomersByCity(string city)
        {
            List<Customer> data = customer.Where(s1 => s1.City == city).ToList();
            return View(data);
        }
       //--------------------------------- Task 8------------------------------
        public ActionResult FilterCustomerByCustid()
        {
            //Empty view
            return View();
        }
        [HttpPost]
        public ActionResult GetCustomerByCustid(int customerid)
        {
            List<Customer> data = customer.Where(c1 => c1.Custid == customerid).ToList();
            return View(data);
        }

    }
}