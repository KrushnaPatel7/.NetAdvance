using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeUT.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentID { get; set; }
    }
}