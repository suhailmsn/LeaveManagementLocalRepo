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
        private readonly IHRService _hrService;
        private readonly IEmployeeService _employeeService;
        public LeaveController(IPMService pmService, IEmployeeService employeeService, IHRService hrService)
        {
            _pmService = pmService;
            _employeeService = employeeService;
            _hrService=hrService;
        }
        

        [AuthenticationFilter]
        public ActionResult ApplyLeave()
        {
            var users = _hrService.ListAllEmployeeProfile();
            var user = users.Where(t => t.RoleName == "ProjectManager").ToList();
            return View(user);
        }


        [AuthenticationFilter]
        [HttpPost]
        public ActionResult ApplyLeave(NewLeaveViewModel nlvm)
        {
            var users = _hrService.ListAllEmployeeProfile();
            var user = users.Where(t => t.RoleName == "ProjectManager").ToList();
            nlvm.EmployeeUserName = _employeeService.GetUserName();
            nlvm.EmployeeID = _employeeService.GetUserID();
            nlvm.DateOfRequest = DateTime.Now;
            _employeeService.ApplyLeave(nlvm);
            return View(user);
        }


        [CustomAuthorizationFilter]
        [AuthenticationFilter]
        public ActionResult ViewLeave()
        {
            string pmname = _employeeService.GetUserName();
            List<LeaveViewModel> lvm = _pmService.ViewAllLeave(pmname);
            return View(lvm);
        }

        [CustomAuthorizationFilter]
        [AuthenticationFilter]
        [HttpPost]
        public ActionResult ViewLeave(int[] Leave)
        {
            string pmname = _employeeService.GetUserName();
            LeaveViewModel lvm = _pmService.ViewLeaveByLeaveID(Leave[0]);
            string email = _employeeService.GetUserEmailByID(lvm.EmployeeID);
            lvm.ApprovalStatus = Leave[1];
            _pmService.LeaveApproval(lvm);
            return RedirectToAction("SendMail", new { ToEmail = email });
        }
        public ActionResult SendMail(string ToEmail)
        {
            ViewBag.FromEmail="projectleave7@gmail.com";
            ViewBag.ToEmail = ToEmail;
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(MailViewModel mvm)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = (new System.Net.Mail.MailAddress(mvm.FromEmail.Trim()));
            mailMessage.To.Add(new System.Net.Mail.MailAddress(mvm.ToEmail.Trim()));

            mailMessage.Priority = System.Net.Mail.MailPriority.Normal;
            mailMessage.IsBodyHtml = false;
            mailMessage.Subject = mvm.Subject;
            mailMessage.Body = mvm.Body.Trim();

            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();

            smtpClient.Send(mailMessage);
            return RedirectToAction("Index", "Home");
        }
    }
}
