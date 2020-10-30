using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using LeaveManagement.DataModels;
using LeaveManagement.Repositories;
using LeaveManagement.ServiceLayer.Interfaces;
using LeaveManagement.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace LeaveManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHRService _hrService;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IHRService hrService, IEmployeeService employeeService)
        {
            _hrService = hrService;
            _employeeService = employeeService;

        }
        //Employee register get method
        public ActionResult Register()
        {
            return View();
        }

        //Employee register post method
        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            var result = _hrService.RegisterEmployeeProfile(rvm);
            if (result.Succeeded)
                return RedirectToAction("Login", "Employee");
            else
                return View();
        }

        //Employee Login get method
        public ActionResult Login()
        {

            return View();
        }

        //Employee Login post method
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            //login
            if (ModelState.IsValid)
            {
                _employeeService.EmployeeLogin(lvm);
                return RedirectToAction("Index", "Home");
                
            }
            else
            {
                ModelState.AddModelError("myerror", "Invalid username or password");
                return View();
            }       
        }

        //Logout method
        public ActionResult Logout()
        {
            _employeeService.EmployeeLogout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditInfo()
            {
            var appDbContext = new LeaveManagementDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            string uid = _employeeService.GetUserID();
            EmployeeInfoViewModel ivm=_employeeService.ViewEmployeeInfo(uid);
            return View(ivm);
        }
            [HttpPost]
            public ActionResult EditInfo(EmployeeInfoViewModel evm)
            {
            string uid = _employeeService.GetUserID();
            EmployeeInfoViewModel ivm = _employeeService.ViewEmployeeInfo(uid);
            evm.EmployeeInfoID = ivm.EmployeeInfoID;
            _employeeService.UploadUserImage(evm);
            _employeeService.UpdateEmployeeInfo(evm);
                return RedirectToAction("EditInfo");
            }
        [HttpPost]
        public ActionResult UploadImage(EmployeeInfoViewModel evm)
        {
            string uid = _employeeService.GetUserID();
            EmployeeInfoViewModel ivm = _employeeService.ViewEmployeeInfo(uid);
            evm.EmployeeInfoID = ivm.EmployeeInfoID;
            _employeeService.UpdateEmployeeInfo(evm);
            return View("EditInfo",evm);
        }
    }
    }

