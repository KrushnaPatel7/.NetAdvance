using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intro_MVC_WebApplication.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long Mobile { get; set; }
    }
}