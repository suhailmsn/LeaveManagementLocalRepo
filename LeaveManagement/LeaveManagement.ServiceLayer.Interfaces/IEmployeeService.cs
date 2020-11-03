using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagement.DataModels;
using LeaveManagement.ViewModels;

namespace LeaveManagement.ServiceLayer.Interfaces
{
    public interface IEmployeeService
    {
        void UploadUserImage(EmployeeInfoViewModel evm);
        string GetUserID();
        string GetUserName();
        string GetUserEmailByID(string id);
        void EmployeeLogin(LoginViewModel lvm);
        void EmployeeLogout();
        void UpdateEmployeeInfo(EmployeeInfoViewModel evm);
        EmployeeInfoViewModel ViewEmployeeInfo(string id);
        void ApplyLeave(NewLeaveViewModel nlvm);
        List<ApplicationUser> GetUsersByRole(string RoleName);
        ApplicationUser GetUsersByName(string UserName);

    }
}
