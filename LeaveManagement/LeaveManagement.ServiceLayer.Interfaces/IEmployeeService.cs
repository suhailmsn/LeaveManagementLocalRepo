using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagement.DataModels;
using LeaveManagement.ViewModels;

namespace LeaveManagement.ServiceLayer.Interfaces
{
    public interface IEmployeeService
    {
        string getUserID();
        void EmployeeLogin(LoginViewModel lvm);
        void EmployeeLogout();
        void UpdateEmployeeInfo(EmployeeInfoViewModel evm);
        EmployeeInfoViewModel ViewEmployeeInfo(string id);
    }
}
