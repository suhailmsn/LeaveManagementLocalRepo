using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using LeaveManagement.ViewModels;
using LeaveManagement.DataModels;
using LeaveManagement.Repositories;
using LeaveManagement.ServiceLayer;
using LeaveManagement.ServiceLayer.Interfaces;
using Microsoft.AspNet.Identity;
using System.Web.Helpers;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeaveManagement.ServiceLayer
{
    public class HRService : IHRService
    {
        private readonly IEmployeeService _employeeService;
        private readonly LeaveManagementDbContext _db;
        public HRService(IEmployeeService employeeService, LeaveManagementDbContext db)
        {
            _employeeService = employeeService;
            _db = db;
        }


        public IdentityResult RegisterEmployeeProfile(RegisterViewModel rvm)
        {
            var appDbContext = new LeaveManagementDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var passwordHash = Crypto.HashPassword(rvm.Password);
            var user = new ApplicationUser() { Email = rvm.Email, UserName = rvm.Name, PasswordHash = passwordHash, PhoneNumber = rvm.Contact, RoleName =rvm.RoleName,IsSpecialPermission=rvm.IsSpecialPermission, EmployeeInfo = new EmployeeInfo() };
            var result = userManager.Create(user);
            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, rvm.RoleName);
            }
            return result;
        }
        public IdentityResult DeleteEmployeeProfile(string Id)
        {
            var appDbContext = new LeaveManagementDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.FindById(Id);
            EmployeeInfo ei=appDbContext.EmployeeInfo.Where(t => t.ApplicationUser.Id == Id).FirstOrDefault();
            appDbContext.EmployeeInfo.Remove(ei);
            //var roleId = userManager.GetRoles(Id).FirstOrDefault();
            //userManager.RemoveFromRole(user.Id,roleId);
            var result = userManager.Delete(user);
            return result;

        }
        public List<IdentityUser> ListAllEmployeeProfile()
        {
            var appDbContext = new LeaveManagementDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            List<IdentityUser> Users = appDbContext.Users.ToList();
            return Users;
        }
        public List<IdentityUser> ListAllEmployeeByName(string UserName)
        {
            List<IdentityUser> user=new List<IdentityUser>();
            return user;
        }
        public List<IdentityUser> ListAllEmployeeByRole(string Role)
        {
            List<IdentityUser> user = new List<IdentityUser>();
            return user;
        }
    }
}