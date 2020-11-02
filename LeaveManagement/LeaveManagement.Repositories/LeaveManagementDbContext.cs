using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LeaveManagement.DataModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeaveManagement.Repositories
{
    public class LeaveManagementDbContext : IdentityDbContext
    {
        public LeaveManagementDbContext() : base("LeaveManagementDbConnectionString")
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public DbSet<LeaveData> LeaveDatas { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                    
                    .HasRequired(m => m.EmployeeInfo)
                    .WithRequiredPrincipal(k => k.ApplicationUser)
                    .WillCascadeOnDelete(true);

        }

    }
}



