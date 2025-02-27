using Day2_Demo_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day2_Demo_Razor.Controllers
{
    public class ProductsController : Controller
    {
        static List<Products> productList = new List<Products>() {
        new Products{ProductId=1,ProductName="Tea",UnitPrice=10,CategoryId=1 },
        new Products{ ProductId=2,ProductName="Bournvita",UnitPrice=30,CategoryId=2 },
            new Products{ProductId = 3, ProductName = "Green Tea", UnitPrice = 15,CategoryId=3 },
        new Products{ ProductId = 4, ProductName = "Tetly Tea", UnitPrice = 20,CategoryId=3 },
        new Products{ ProductId = 5, ProductName = "Black Tea", UnitPrice = 40,CategoryId=1 },
         new Products{ ProductId = 6, ProductName = "Special Tea", UnitPrice = 50 , CategoryId = 1}
        };

        //For Productid =1,5,6 ,  category id =1
        //For Productid =2, category id =2
        //For Productid =3,4 , categoryid=3
        public ActionResult AggregateProductPrices()
        {

            int totalPrice = productList.Sum(x => x.UnitPrice);
            ViewBag.TotalPriceOfProducts = totalPrice;

            double AveragePrice = productList.Average(x => x.UnitPrice);
            ViewBag.AveragePriceOfProducts = AveragePrice;

            double MinPrice = productList.Min(x => x.UnitPrice);
            ViewBag.MinimumPriceOfProducts = MinPrice;

            double MaxPrice = productList.Max(x => x.UnitPrice);
            ViewBag.MaximumPriceOfProducts = MaxPrice;



            ViewBag.AllProducts = productList;
            return View();
        }
        public ActionResult TakeSkipDemo()
        {
            int priceOfFirstTwoProducts = productList.Take(2).Sum(x => x.UnitPrice);
            ViewBag.priceOfFirstTwoProducts = priceOfFirstTwoProducts;//40

            int SkipOneTakeTwo = productList.Skip(1).Take(2).Sum(x => x.UnitPrice);
            ViewBag.SkipOneTakeTwo = SkipOneTakeTwo;//45

            double skipandTake = productList.Skip(4).Take(2).Average(x => x.UnitPrice);
            ViewBag.AverageSkipAndTake = skipandTake;
            return View();
        }
        public ActionResult AnyAllDemo()
        {
            //var foundOrNot= productList.Any(x => x.ProductName.Contains("Limca"));
            var foundOrNot = productList.Any(x => x.UnitPrice > 30);
            if (foundOrNot)
            {
                ViewBag.Message = "Found";

            }
            else
            {
                ViewBag.Message = "Not Found";
            }

            //var Alldata=productList.All(x=>x.UnitPrice > 30);//False
            //var Alldata = productList.All(x => x.UnitPrice > 10);//False
            var Alldata = productList.All(x => x.UnitPrice > 9 && x.UnitPrice <= 50);//True

            int cnt = productList.Count();// 6
            ViewBag.AllDataTrue = Alldata;
            return View();
        }
        // GET: Products
        public ActionResult Index()
        {

            return View(productList);
        }
        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var productFound = productList.Find(x => x.ProductId == id);//find returns one element

            if (productFound == null)
            {
                throw new ArgumentNullException("This product id is not found....");

            }
            return View(productFound);
        }
        public ActionResult FindDetailsByCategoryID()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FindDetailsByCategoryID(int id)
        {
            var AllDataForCategories = productList.FindAll(p => p.CategoryId == id);//multiple rows can be returned using find all
            ViewBag.GetDataByCategoryID = AllDataForCategories;

            var d1 = productList.FindAll(p => p.CategoryId == id).Take(1);
            var d2=productList.FindAll(p => p.CategoryId == id).Skip(1).Take(1);
            var d3 = productList.FindAll(p => p.CategoryId == id).OrderByDescending(p=>p.ProductId).Take(1);
            var d4=from p in productList
                 where p.CategoryId==id
                   select p;
           
            return View();
        }
        public ActionResult QuerySyntaxGroupByDemo()
        {
            var groupedData = from p1 in productList
                              group p1 by p1.CategoryId into C
                              select new { catid = C.Key, AveragePrices = C.Average(s => s.UnitPrice) };

            Dictionary<int, double> values = new Dictionary<int, double>();
            foreach(var item in groupedData)
            {
                values.Add(item.catid, item.AveragePrices);
            }


            ViewBag.GroupByDemo = values;
            return View();
        }
        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
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

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
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

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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