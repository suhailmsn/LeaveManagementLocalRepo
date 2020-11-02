using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagement.ViewModels;

namespace LeaveManagement.ServiceLayer.Interfaces
{
    public interface IPMService
    {
        void LeaveApproval(LeaveViewModel lvm);
        LeaveViewModel ViewLeaveByLeaveID(int lid);
        List<LeaveViewModel> ViewAllLeave(string eid);
    }
}
