using DB_Logic1;
using EmployeeUT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUT.Controllers
{
    public class EmployeeController : Controller
    {
        public static CompanyEntities obj = new CompanyEntities();
        public static IEnumerable<Employee> emp = obj.Employees;
        public static List<EmployeeModel> eList = new List<EmployeeModel>();
        // GET: Employee

        //--------------Task 2--------------------------------------
        public ActionResult Index()
        {
            foreach (var item in emp)
            {
                eList.Add(new EmployeeModel { EmployeeID = item.EmployeeID, FirstName = item.FirstName, LastName = item.LastName, Salary = item.Salary, DepartmentID=item.DepartmentID });
            }
            return View(eList);
        }

        //---------------------Task 3--------------------------------

        public ActionResult TotalSalarySummary()
        {
            decimal totalsalary = eList.Sum(i =>i.Salary); 
            ViewBag.Totalsalary = totalsalary;
            return View();
        }

        public ActionResult AverageSalaryByDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AverageSalaryByDepartmentByID(int id)
        {
            List<EmployeeModel> byId = eList.Where(e => e.DepartmentID == id).ToList();

            // Cast the average to double explicitly
            double ans = byId.Any() ? (double)byId.Average(e => e.Salary) : 0;

            ViewBag.avg = ans;
            return View(byId);


        }


        public ActionResult GetEmployeesByDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetEmployeesByDepartmentByID(int id)
        {
            List<EmployeeModel> byId = eList.FindAll(e => e.DepartmentID == id).ToList();
            return View(byId);
        }
        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
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

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
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

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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
