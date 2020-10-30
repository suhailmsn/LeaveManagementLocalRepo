using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagement.DataModels;
using LeaveManagement.ViewModels;
using Microsoft.AspNet.Identity;

namespace LeaveManagement.ServiceLayer.Interfaces
{
    public interface IHRService
    {
        IdentityResult RegisterEmployeeProfile(RegisterViewModel rvm);


    }
}
