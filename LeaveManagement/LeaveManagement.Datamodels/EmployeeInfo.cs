using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.DataModels
{
    public class EmployeeInfo 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeInfoID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ProjectsDone { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Hobbies { get; set; }
        public string ImageUrl { get; set; }
        public string EmployeeID { get; set; }

        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}