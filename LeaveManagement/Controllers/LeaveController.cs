using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagement.DataModels;
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
        public ActionResult ApplyLeave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ApplyLeave(NewLeaveViewModel nlvm)
        {
            nlvm.EmployeeID = _employeeService.GetUserID();
            nlvm.DateOfRequest = DateTime.Now;
            _employeeService.ApplyLeave(nlvm);
            return View();
        }
        public ActionResult ViewLeave()
        {
            string pmname = _employeeService.GetUserName();
            List<LeaveViewModel> lvm = _pmService.ViewAllLeave(pmname);
            return View(lvm);
        }
        public ActionResult LeaveApproval(int LeaveID=2)
        {
            string pmname = _employeeService.GetUserName();
            LeaveViewModel lvm = _pmService.ViewLeaveByLeaveID(LeaveID, pmname);
            return View(lvm);
        }

        [HttpPost]
        public ActionResult LeaveApproval(LeaveViewModel lvm)
        {
            _pmService.LeaveApproval(lvm);
            return View();
        }
    }
}
