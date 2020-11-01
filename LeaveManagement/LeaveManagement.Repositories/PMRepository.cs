using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeaveManagement.DataModels;
using LeaveManagement.Repository.Interfaces;

namespace LeaveManagement.Repositories
{

    public class PMRepository:IPMRepository
    {
        private LeaveManagementDbContext _db;
        public PMRepository(LeaveManagementDbContext db)
        {
            _db = db;
        }
        public void LeaveApproval(LeaveData l)
        {
            LeaveData ld;
            ld = _db.LeaveDatas.Where(temp => temp.EmployeeID == l.EmployeeID).FirstOrDefault();
            ld.ApprovalStatus = l.ApprovalStatus;
            ld.ApprovedBy = l.ApprovedBy;
            _db.SaveChanges();

        }
        public LeaveData ViewLeaveByLeaveID(int lid, string eid)
        {
            LeaveData ld;
            ld = _db.LeaveDatas.Where(temp => temp.ApprovedBy == eid && temp.LeaveID == lid).FirstOrDefault();
            return ld;

        }
        public List<LeaveData> ViewAllLeave(string eid)
        {
            List<LeaveData> ld;
            ld = _db.LeaveDatas.Where(temp =>temp.ApprovedBy == eid).ToList();
            return ld;
        }
    }
}