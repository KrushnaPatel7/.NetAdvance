using Intro_MVC_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intro_MVC_WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        static List<Customer> customerList = new List<Customer>();
        // GET: Customer
        public ActionResult Index()
        {
            //return Content("Index of Products");
            //passing the Model to the View(ModelView)
            return View(customerList);
        }

        //Create a new product----Create
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Customer custData)
        {
            //1) Insert into database table
            //2) Array of PRoducts and add the new product to the array
            //3) List<Products> ----add the new product to the product list

            customerList.Add(custData);
            return RedirectToAction("Index");
            // return RedirectToAction("GreetUser", "Home");
        }


        public ActionResult Edit(int id)
        {

            Customer c = new Customer();
            string customerData = null;
            foreach (var item in customerList)
            {
                if (item.CustomerID== id)
                {
                    c.CustomerID = item.CustomerID;
                    c.FirstName = item.FirstName;
                    c.LastName = item.LastName;
                    c.Email = item.Email;
                    c.Mobile = item.Mobile;
                    //productData = string.Concat(p.ProductID, p.ProductName, p.Price, p.UOM, p.CategoryName, p.SupplierName);
                    return View(c);

                }
                else
                {
                    customerData = "No customer exists...";


                }

            }

            return Content(customerData);


        }

        [HttpPost]
        public ActionResult Edit(Customer changedData, int id)
        {
            string customerData = null;
            foreach (var item in customerList)
            {
                if (item.CustomerID== id)
                {
                    item.CustomerID = changedData.CustomerID;
                    item.FirstName = changedData.FirstName;
                    item.LastName = changedData.LastName;
                    item.Email = changedData.Email;
                    item.Mobile = changedData.Mobile;
                    
                    //productData = string.Concat(p.ProductID, p.ProductName, p.Price, p.UOM, p.CategoryName, p.SupplierName);
                    return RedirectToAction("Index");

                }
                else
                {
                    customerData = "No customer exists.....";


                }

            }

            return Content(customerData);

        }


        public ActionResult Delete(int id)
        {
            Customer c = new Customer();

            foreach (var item in customerList)
            {
                if (item.CustomerID== id)
                {
                    c.CustomerID = item.CustomerID;
                    c.FirstName = item.FirstName;
                    c.LastName = item.LastName;
                    c.Email = item.Email;
                    c.Mobile = item.Mobile;


                    break;

                }

            }
            return View(c);

        }


        [HttpPost]
        public ActionResult Delete(Customer c1, int id)
        {


            foreach (var item in customerList)
            {
                if (item.CustomerID == id)
                {
                    customerList.Remove(item);
                    break;

                }

            }



            return RedirectToAction("Index");
        }




    }
}