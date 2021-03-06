﻿using System;
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
       public string RoleName { get; set; }
       public bool IsSpecialPermission { get; set; } 
       public virtual EmployeeInfo EmployeeInfo { get; set; }
       public virtual List<LeaveData> LeaveData { get; set; }

    }
}