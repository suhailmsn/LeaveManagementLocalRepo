using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeaveManagement.DataModels;
using LeaveManagement.Repository.Interfaces;
using Microsoft.AspNet.Identity;

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
            var appDbContext = new LeaveManagementDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            LeaveData ld = _db.LeaveDatas.Where(temp => temp.LeaveID == l.LeaveID).FirstOrDefault();
            ld.ApprovedBy = HttpContext.Current.User.Identity.GetUserName();
            ld.ApprovalStatus = l.ApprovalStatus;
            _db.SaveChanges();

        }
        public LeaveData ViewLeaveByLeaveID(int lid)
        {
            LeaveData ld;
            ld = _db.LeaveDatas.Where(temp=>temp.LeaveID == lid).FirstOrDefault();
            return ld;

        }
        public List<LeaveData> ViewAllLeave(string eid)
        {
            if (HttpContext.Current.User.IsInRole("HumanResources") == false)
            {
                List<LeaveData> ld;
                ld = _db.LeaveDatas.Where(temp => temp.ApprovedBy == eid).ToList();
                return ld;
            }
            else
            {
                List<LeaveData> ld;
                ld = _db.LeaveDatas.ToList();
                return ld;
            }
        }
    }
}