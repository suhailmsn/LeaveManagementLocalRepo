using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace LeaveManagement.ViewModels
{
    public class NewLeaveViewModel
    {
        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [Required]
        public DateTime DateOfRequest { get; set; }

        [Required]
        public int LeaveTypeID { get; set; }

        [Required]
        public string ApprovedBy { get; set; }

        [Required]
        public string LeaveReason { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeUserName { get; set; }
        public string PMEmployeeID { get; set; }
        public string PMUserName { get; set; }
        public bool IsForenoonOnly { get; set; }
        public bool IsAfternoonOnly { get; set; }


    }
}