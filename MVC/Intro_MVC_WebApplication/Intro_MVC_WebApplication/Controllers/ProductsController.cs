using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intro_MVC_WebApplication.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        static List<Products> productList = new List<Products>();


        //static ProductsController()
        //{
        //    //Collection Initializer
        //    productList.Add(new Products { ProductID = 1, ProductName = "Lays", Price = 20, UOM = "Packet", CategoryName = "Snacks", SupplierName = "Parle" });
        //    productList.Add(new Products { ProductID = 2, ProductName = "Kurkure", Price = 20, UOM = "Packet", CategoryName = "Snacks", SupplierName = "Parle" });
        //    productList.Add(new Products { ProductID = 3, ProductName = "Chips", Price = 20, UOM = "Packet", CategoryName = "Snacks", SupplierName = "Parle" });

        //}

        // GET: Products
        //ShowAll
        public ActionResult Index()
        {
            //return Content("Index of Products");
            //passing the Model to the View(ModelView)
            return View(productList);
        }

        //Create a new product----Create
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Products prodData)
        {
            //1) Insert into database table
            //2) Array of PRoducts and add the new product to the array
            //3) List<Products> ----add the new product to the product list

            productList.Add(prodData);
            return RedirectToAction("Index");
            // return RedirectToAction("GreetUser", "Home");
        }


        public ActionResult Edit(int id)
        {

            Products p = new Products();
            string productData = null;
            foreach (var item in productList)
            {
                if (item.ProductID == id)
                {
                    p.ProductID = item.ProductID;
                    p.ProductName = item.ProductName;
                    p.Price = item.Price;
                    p.UOM = item.UOM;
                    p.CategoryName = item.CategoryName;
                    p.SupplierName = item.SupplierName;
                    //productData = string.Concat(p.ProductID, p.ProductName, p.Price, p.UOM, p.CategoryName, p.SupplierName);
                    return View(p);

                }
                else
                {
                    productData = "No such product exists.....";


                }

            }

            return Content(productData);


        }

        [HttpPost]
        public ActionResult Edit(Products changedData, int id)
        {
            string productData = null;
            foreach (var item in productList)
            {
                if (item.ProductID == id)
                {
                    item.ProductID = changedData.ProductID;
                    item.ProductName = changedData.ProductName;
                    item.Price = changedData.Price;
                    item.UOM = changedData.UOM;
                    item.CategoryName = changedData.CategoryName;
                    item.SupplierName = changedData.SupplierName;
                    //productData = string.Concat(p.ProductID, p.ProductName, p.Price, p.UOM, p.CategoryName, p.SupplierName);
                    return RedirectToAction("Index");

                }
                else
                {
                    productData = "No such product exists.....";


                }

            }

            return Content(productData);

        }


        public ActionResult Delete(int id)
        {
            Products p = new Products();

            foreach (var item in productList)
            {
                if (item.ProductID == id)
                {
                    p.ProductID = item.ProductID;
                    p.ProductName = item.ProductName;
                    p.Price = item.Price;
                    p.UOM = item.UOM;
                    p.CategoryName = item.CategoryName;
                    p.SupplierName = item.SupplierName;


                    break;

                }

            }
            return View(p);

        }


        [HttpPost]
        public ActionResult Delete(Products p1, int id)
        {


            foreach (var item in productList)
            {
                if (item.ProductID == id)
                {
                    productList.Remove(item);
                    break;

                }

            }



            return RedirectToAction("Index");
        }








    }
}