using Intro_MVC_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intro_MVC_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        //Method in a controller is called as action
        // Return type of method can be anything,like void,bool,string etc, ActionResult
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();


        }

        public ActionResult GreetUser()
        {
            //ContentResult --returns Content (means String)
            //string---content
            return Content("Greetings of the day");
        }
        public ActionResult Register()
        {
            //name of the view should be register becos we are not specifying the viwename diff here and so the default view name is action name 
            //how to create a view and where its created?
            //create view using scaffolding(generating code automatically)
            //it is created in the views folder / ControllerName Folder
            return View();
        }
        // click the button (Create) it is giving ht data to the app and when u clic a button the data goes to the server called post action(POST) which takes parameter
        //of customer data
        [HttpPost]
        public ActionResult Register(Customer custdata)
        {
            Customer c = new Customer();
            c.FirstName = custdata.FirstName;
            c.LastName = custdata.LastName;
            c.Email = custdata.Email;
            c.Mobile = custdata.Mobile;
            return Content("Registration successful.......");

        }
        public ActionResult Login()
        {
            return View();
        }
    }
}