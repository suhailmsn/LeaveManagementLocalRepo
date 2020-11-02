using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LeaveManagement.Filters
{
    public class ProjectManagerAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.IsInRole("ProjectManager") == false)
            {
                filterContext.Result = new RedirectToRouteResult(new
            RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }
    }
}