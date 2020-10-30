using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using LeaveManagement.DataModels;
using LeaveManagement.Repositories;

[assembly: OwinStartup(typeof(LeaveManagement.Startup))]

namespace LeaveManagement
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login") });
            this.CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new LeaveManagementDbContext()));
            var appDbContext = new LeaveManagementDbContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appUserStore);

            //Create Admin Role
            if (!roleManager.RoleExists("HumanResources"))
            {
                var role = new IdentityRole();
                role.Name = "HumanResources";
                var rolecreate = roleManager.Create(role);
            }

            //Create Admin User
            if (userManager.FindByName("HumanResources") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "HumanResources";
                user.Email = "humanresources@gmail.com";
                string userPassword = "humanresources123";
                var chkUser = userManager.Create(user, userPassword);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "HumanResources");
                }
            }

            //Create Manager Role
            if (!roleManager.RoleExists("ProjectManager"))
            {
                var role = new IdentityRole();
                role.Name = "ProjectManager";
                roleManager.Create(role);
            }

            //Create Manager User
            if (userManager.FindByName("ProjectManager") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "ProjectManager";
                user.Email = "projectmanager@gmail.com";
                string userPassword = "projectmanager123";
                var chkUser = userManager.Create(user, userPassword);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "ProjectManager");
                }
            }

            //Create Customer Role
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);
            }
        }
    }
}

