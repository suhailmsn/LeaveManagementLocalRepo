using System;
using System.Collections.Generic;
using System.Linq;
using LeaveManagement.DataModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LeaveManagement.Repository.Interfaces;

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
            EmployeeInfo ei;
            ei = _db.EmployeeInfo.Where(temp => (temp.EmployeeInfoID == e.EmployeeInfoID)).FirstOrDefault();
            if (ei != null)
            {
                ei.FirstName = e.FirstName;
                ei.LastName = e.LastName;
                ei.ProjectsDone = e.ProjectsDone;
                ei.Address = e.Address;
                ei.Bio = e.Bio;
                ei.Hobbies = e.Hobbies;
                ei.DateOfBirth = e.DateOfBirth;
                _db.SaveChanges();
            }
        }

        public EmployeeInfo ViewEmployeeInfo(string eid)
        {
            EmployeeInfo ei;
            ei = _db.EmployeeInfo.Where(temp => (temp.ApplicationUser.Id == eid)).FirstOrDefault();
            return ei;
        }

    }
}