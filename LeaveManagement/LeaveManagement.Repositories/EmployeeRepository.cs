using System;
using System.Collections.Generic;
using System.Linq;
using LeaveManagement.DataModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LeaveManagement.Repository.Interfaces;
using System.Web;
using Microsoft.AspNet.Identity;

namespace LeaveManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private LeaveManagementDbContext _db;
        public EmployeeRepository(LeaveManagementDbContext db)
        {
            _db = db;
        }

        public void UpdateEmployeeInfo(EmployeeInfo e)
        {
            var appDbContext = new LeaveManagementDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser user = userManager.FindById(e.ApplicationUser.Id);
            
            EmployeeInfo ei;
            ei = _db.EmployeeInfo.Where(temp =>temp.EmployeeInfoID == e.EmployeeInfoID).FirstOrDefault();
            if (ei != null)
            {
                ei.FirstName = e.FirstName;
                ei.LastName = e.LastName;
                ei.ProjectsDone = e.ProjectsDone;
                ei.Address = e.Address;
                ei.Bio = e.Bio;
                ei.Hobbies = e.Hobbies;
                ei.DateOfBirth = e.DateOfBirth;
                ei.ApplicationUser = user;
                _db.SaveChanges();
            }
        }

        public EmployeeInfo ViewEmployeeInfo(string eid)
        {
            EmployeeInfo ei;
            ei = _db.EmployeeInfo.Where(temp =>temp.ApplicationUser.Id == eid).FirstOrDefault();
            return ei;
        }

        public void UploadUserImage(EmployeeInfo e)
        {
            if (HttpContext.Current.Request.Files.Count >= 1)
            {
                var file = HttpContext.Current.Request.Files[0];
                var imgBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                EmployeeInfo ei =_db.EmployeeInfo.Where(temp =>temp.EmployeeInfoID == e.EmployeeInfoID).FirstOrDefault();
                if (ei != null)
                {
                    ei.ImageUrl = base64String;
                    _db.SaveChanges();
                }
            }

        }
        public void ApplyLeave(LeaveData l)
        {
        
            _db.LeaveDatas.Add(l);
            _db.SaveChanges();
        }
    }
}