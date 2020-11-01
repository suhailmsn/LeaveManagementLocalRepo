using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagement.DataModels;

namespace LeaveManagement.Repository.Interfaces
{
    public interface IPMRepository
    {
        void LeaveApproval(LeaveData l);
        LeaveData ViewLeaveByLeaveID(int lid, string eid);
        List<LeaveData> ViewAllLeave(string eid);

    }
}
