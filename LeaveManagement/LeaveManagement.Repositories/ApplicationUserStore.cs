using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeaveManagement.DataModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeaveManagement.Repositories
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(LeaveManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}



