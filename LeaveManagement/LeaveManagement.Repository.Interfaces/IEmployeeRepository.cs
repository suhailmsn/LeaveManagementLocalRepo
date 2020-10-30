using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagement.DataModels;

namespace LeaveManagement.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        void UpdateEmployeeInfo(EmployeeInfo e);
        EmployeeInfo ViewEmployeeInfo(string id);

    }
}
