using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day2_Demo_Razor.Models
{
    public class Students
    {

        public int RollNo { get; set; }
        public string StudName { get; set; }
        public string City { get; set; }
        public int Age { get; internal set; }


    }

}