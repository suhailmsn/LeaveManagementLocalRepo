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
using System.Net.Http;


namespace LeaveManagement.ServiceLayer
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public string getUserID()
        {
            return (HttpContext.Current.User.Identity.GetUserId());
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
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EmployeeInfoViewModel,EmployeeInfo>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            EmployeeInfo e = mapper.Map<EmployeeInfoViewModel, EmployeeInfo>(evm);
            _employeeRepository.UpdateEmployeeInfo(e);
        }

        public EmployeeInfoViewModel ViewEmployeeInfo(string  id)
        {
            EmployeeInfo e = _employeeRepository.ViewEmployeeInfo(id);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EmployeeInfo,EmployeeInfoViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            EmployeeInfoViewModel evm = mapper.Map<EmployeeInfo, EmployeeInfoViewModel>(e);
            return evm;
        }
    }    
}