using Day2_Demo_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Day2_Demo_Razor.Controllers
{
    public class StudentsController : Controller
    {
        static List<Students> students = new List<Students>() {
        new Students{RollNo=1,StudName="Ashwini",City="Pune",Age=10 },
        new Students{RollNo=2,StudName="Shravani",City="Mumbai",Age=20 },
        new Students{ RollNo=3,StudName="Hari",City="Pune",Age=20},
        new Students{ RollNo=4,StudName="Jack",City="Bangalore", Age = 20},
        new Students{ RollNo=5,StudName="Jill",City="Mumbai", Age = 10},
        new Students{ RollNo=6,StudName="Ana",City="Pune", Age = 9}
                };
        // GET: Students
        public ActionResult Index()
        {

            return View(students);
        }


        public ActionResult GroupByDemo()
        {
            var data = students.GroupBy(s => s.City).ToList();

            List<Students> slist = new List<Students>();
            foreach (var item in data)
            {

                var d = item.Select(s => new { rno = s.RollNo, name = s.StudName });
                foreach (var item1 in d)
                {
                    slist.Add(new Students { City = item.Key, RollNo = item1.rno, StudName = item1.name });
                }
            }
            ViewBag.StudentsDataGrouped = slist;
            return View();
        }

        public ActionResult GroupByCityExample()
        {
            var cityGroups = students.GroupBy(c => c.City);
            Dictionary<int, Students> studData = new Dictionary<int, Students>();
            string cityname;
            foreach (var item in cityGroups)
            {
                cityname = item.Key;
                var sData = item.Select(x => new { Roll = x.RollNo, name = x.StudName, age = x.Age });
                foreach (var item1 in sData)
                {
                    studData.Add(item1.Roll, new Students { RollNo = item1.Roll, StudName = item1.name, Age = item1.age, City = item.Key });
                }

            }
            //dynamic i = 10;
            //i = "Hello";

            //var j = 10;
            //j = 100;


            //name of the viewbag variable is StudentsGroupedData which is of a dynamic/ViewBag uses dynamic type
            //ViewBag is used to pass data from the controller to the view.
            ViewBag.StudentsGroupedData = studData;
            return View();
        }

        public ActionResult ShowRazor()
        {
            return View();

        }
        public ActionResult CreateAction(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAction()
        {

            return View();

        }

        public ActionResult AddNumbers()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddNumbers(int i, int j)
        {

            int ans = i + j;
            return Content(ans.ToString());
        }



        public ActionResult FilterByCity()
        {
            //Empty view
            return View();
        }


        [HttpPost]
        public ActionResult ShowListByCity(string city)
        {
            //list
            List<Students> data = students.Where(s1 => s1.City == city).ToList();
            return View(data);
        }
        public ActionResult AgeWithInitialNameLetter()
        {
            //List view
            var sdataWithAge = students.Select(x => new { studage = x.Age, InitialLetter = x.StudName[0] }).ToList();

            List<Students> studList = new List<Students>();


            foreach (var item in sdataWithAge)
            {
                studList.Add(new Students { Age = item.studage, StudName = item.InitialLetter.ToString() });
            }
            return View(studList);
        }




        public ActionResult AgeDescendingOrder()
        {
            var ageData = students.OrderBy(x => x.Age).ToList();

            return View(ageData);
        }

        public ActionResult DataWithNameAge()
        {
            var data = students.OrderBy(x => x.City).ThenBy(s => s.Age).ThenBy(s => s.StudName).Select(n => new { sname = n.StudName, age = n.Age, studcity = n.City }).ToList();
            List<Students> sdata = new List<Students>();
            foreach (var item in data)
            {
                sdata.Add(new Students { StudName = item.sname, Age = item.age, City = item.studcity });

            }

            return View(sdata);
        }






    }
}