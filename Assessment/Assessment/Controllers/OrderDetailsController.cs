using Assessment.Models;
using DB_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assessment.Controllers
{
    public class OrderDetailsController : Controller
    {
        public static NorthwindEntities obj = new NorthwindEntities();
        public static IEnumerable<Order_Detail> or = obj.Order_Details;
        public static List<OrderModel> orList = new List<OrderModel>();
        // GET: OrderDetails
        public ActionResult Index()
        {
            
            foreach (var item in or)
            {
                orList.Add(new OrderModel { OrderID = item.OrderID, ProductID = item.ProductID, UnitPrice = item.UnitPrice, Quantity = item.Quantity, Discount = item.Discount});
            }


            return View(orList);

        }
        //----------------------------------------Task2----------------------------------------------------
        public ActionResult TotalOrderValue()
        {
            // Fetch all order details
            var orderDetails = obj.Order_Details.ToList();

            // Calculate total order value (Qty * UnitPrice)
            decimal totalValue = orderDetails.Sum(o => o.Quantity * o.UnitPrice);

            // Store result in ViewBag
            ViewBag.TotalOrderValue = totalValue;

            return View();
            
        }
        //---------------------------------Task 3---------------------------------------------------
        public ActionResult ProductsSold()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ProductsSoldById(int id)
        {
           

            List<OrderModel> byId = orList.Where(i => i.ProductID == id).ToList();

            double ans = byId.Any() ? byId.Average(i => i.Quantity) : 0;

            ViewBag.avg = ans;
            return View(byId);
        }
        //------------------------------------Task 4---------------------------------------------------
        public ActionResult ProductsByOrderId()
        {

            return View();
        }

        [HttpPost]
        public ActionResult GetProductsByOrderId(int id)
        {


            List<OrderModel> byId = orList.FindAll(i => i.OrderID == id).ToList();

            return View(byId);
        }
        // GET: OrderDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetails/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
