using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace LeaveManagement.DataModels
{
    public class ApplicationUser:IdentityUser
    {  
       public EmployeeInfo EmployeeInfo { get; set; }
        
    }
}