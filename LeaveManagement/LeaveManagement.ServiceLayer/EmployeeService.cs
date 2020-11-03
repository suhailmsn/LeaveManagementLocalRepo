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
using LeaveManagement.Repository.Interfaces;
using LeaveManagement.ServiceLayer.Interfaces;
using Microsoft.AspNet.Identity;
using System.Web;
using Microsoft.Owin.Security;
using System.Web.UI.WebControls;

namespace LeaveManagement.ServiceLayer
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public string GetUserID()
        {
            return (HttpContext.Current.User.Identity.GetUserId());
        }
        public string GetUserName()
        {
            return (HttpContext.Current.User.Identity.GetUserName());
        }
        public string GetUserEmailByID(string id)
        {
            var appDbContext = new LeaveManagementDbContext();
            var user=appDbContext.ApplicationUser.Where(t => t.Id == id).FirstOrDefault();
            return (user.Email);
        }
        public void EmployeeLogin(LoginViewModel lvm)
        {
            var appDbContext = new LeaveManagementDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(userManager.FindByEmail(lvm.Email).UserName, lvm.Password);
            if (user != null)
            {
                //login
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

            }


        }

        public void EmployeeLogout()
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
        }
        public void UpdateEmployeeInfo(EmployeeInfoViewModel evm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EmployeeInfoViewModel, EmployeeInfo>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            EmployeeInfo e = mapper.Map<EmployeeInfoViewModel, EmployeeInfo>(evm);
            _employeeRepository.UpdateEmployeeInfo(e);
        }

        public EmployeeInfoViewModel ViewEmployeeInfo(string id)
        {
            EmployeeInfo e = _employeeRepository.ViewEmployeeInfo(id);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EmployeeInfo, EmployeeInfoViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            EmployeeInfoViewModel evm = mapper.Map<EmployeeInfo, EmployeeInfoViewModel>(e);
            return evm;
        }
        public void UploadUserImage(EmployeeInfoViewModel evm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EmployeeInfoViewModel, EmployeeInfo>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            EmployeeInfo e = mapper.Map<EmployeeInfoViewModel, EmployeeInfo>(evm);
            _employeeRepository.UploadUserImage(e);

        }
        public void ApplyLeave(NewLeaveViewModel nlvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewLeaveViewModel, LeaveData>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            LeaveData l = mapper.Map<NewLeaveViewModel, LeaveData>(nlvm);
            _employeeRepository.ApplyLeave(l);
        }
        public List<ApplicationUser> GetUsersByRole(string RoleName)
        {
            var appDbContext = new LeaveManagementDbContext();
            List<ApplicationUser> user = appDbContext.ApplicationUser.Where(t => t.RoleName == RoleName).ToList();
            return user;
        }
        public ApplicationUser GetUsersByName(string UserName)
        {
            var appDbContext = new LeaveManagementDbContext();
            ApplicationUser user = appDbContext.ApplicationUser.Where(t => t.UserName == UserName).FirstOrDefault();
            return user;
        }
    }
}