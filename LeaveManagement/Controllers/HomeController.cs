﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaveManagement.DataModels;
using LeaveManagement.Filters;
using LeaveManagement.ServiceLayer.Interfaces;

namespace LeaveManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHRService _hrService;
        private readonly IEmployeeService _employeeService;

        public HomeController(IHRService hrService, IEmployeeService employeeService)
        {
            _hrService = hrService;
            _employeeService = employeeService;

        }
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Search
        [AuthenticationFilter]
        public ActionResult Search()
        {
            var users=_hrService.ListAllEmployeeProfile();
            return View(users);
        }

        // POST: Search by role
        [AuthenticationFilter]
        [HttpPost]
        public ActionResult SearchResult(string roleName)
        {
            List<ApplicationUser> users = _employeeService.GetUsersByRole(roleName);
            return View(users);
        }

        // POST: Search by name
        [AuthenticationFilter]
        [HttpPost]
        public ActionResult SearchResultByName(string UserName)
        {
            ApplicationUser users = _employeeService.GetUsersByName(UserName);
            return View(users);
        }
    }
}