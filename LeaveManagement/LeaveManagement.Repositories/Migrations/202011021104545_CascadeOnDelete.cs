namespace LeaveManagement.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeOnDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeInfoes", "ApplicationUser_Id", "dbo.AspNetUsers");
            AddForeignKey("dbo.EmployeeInfoes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeInfoes", "ApplicationUser_Id", "dbo.AspNetUsers");
            AddForeignKey("dbo.EmployeeInfoes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
