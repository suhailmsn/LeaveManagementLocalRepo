using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.DataModels
{
    public class LeaveData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime DateOfRequest { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveReason { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovedBy { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeUserName{ get; set; }
        public string PMEmployeeID { get; set; }
        public string PMUserName { get; set; }
        public bool IsForenoonOnly { get; set; }
        public bool IsAfternoonOnly { get; set; }

        [ForeignKey("LeaveTypeID")]
        public virtual LeaveType LeaveType{get; set;}

        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}