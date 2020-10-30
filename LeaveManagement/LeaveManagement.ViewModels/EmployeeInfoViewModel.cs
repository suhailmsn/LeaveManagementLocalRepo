using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManagement.ViewModels
{
    public class EmployeeInfoViewModel
    {
        public int EmployeeInfoID{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProjectsDone { get; set; }
        public string Bio { get; set; }
        public string Hobbies { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }

    }
}