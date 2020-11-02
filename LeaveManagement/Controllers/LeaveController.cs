using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagement.DataModels;
using LeaveManagement.Filters;
using LeaveManagement.ServiceLayer.Interfaces;
using LeaveManagement.ViewModels;

namespace LeaveManagement.Controllers
{
    public class LeaveController : Controller
    {
        private readonly IPMService _pmService;
        private readonly IEmployeeService _employeeService;
        public LeaveController(IPMService pmService, IEmployeeService employeeService)
        {
            _pmService = pmService;
            _employeeService = employeeService;
        }
        

        [AuthenticationFilter]
        public ActionResult ApplyLeave()
        {
            return View();
        }


        [AuthenticationFilter]
        [HttpPost]
        public ActionResult ApplyLeave(NewLeaveViewModel nlvm)
        {
            nlvm.EmployeeUserName = _employeeService.GetUserName();
            nlvm.EmployeeID = _employeeService.GetUserID();
            nlvm.DateOfRequest = DateTime.Now;
            _employeeService.ApplyLeave(nlvm);
            return View();
        }


        [ProjectManagerAuthorizationFilter]
        [AuthenticationFilter]
        public ActionResult ViewLeave()
        {
            string pmname = _employeeService.GetUserName();
            List<LeaveViewModel> lvm = _pmService.ViewAllLeave(pmname);
            return View(lvm);
        }


        [AuthenticationFilter]
        [HttpPost]
        public ActionResult ViewLeave(int[] Leave)
        {
            string pmname = _employeeService.GetUserName();
            LeaveViewModel lvm = _pmService.ViewLeaveByLeaveID(Leave[0], pmname);
            lvm.ApprovalStatus = Leave[1];
            _pmService.LeaveApproval(lvm);
            return RedirectToAction("ViewLeave");
        }
    }
}
