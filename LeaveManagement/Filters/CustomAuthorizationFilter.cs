using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LeaveManagement.Repositories;
using Microsoft.AspNet.Identity;

namespace LeaveManagement.Filters
{
    public class CustomAuthorizationFilter : FilterAttribute, IActionFilter
    {
    
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
    
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var appDbContext = new LeaveManagementDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.FindById(filterContext.HttpContext.User.Identity.GetUserId());
            if (filterContext.HttpContext.User.IsInRole("ProjectManager") == false && user.IsSpecialPermission == false)
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }
    }
}