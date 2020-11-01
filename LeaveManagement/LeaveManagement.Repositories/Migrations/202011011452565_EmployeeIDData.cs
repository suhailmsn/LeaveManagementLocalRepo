namespace LeaveManagement.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeIDData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LeaveDatas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.LeaveDatas", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.EmployeeInfoes", "EmployeeID", c => c.String());
            AlterColumn("dbo.LeaveDatas", "EmployeeID", c => c.String());
            AlterColumn("dbo.LeaveDatas", "PMEmployeeID", c => c.String());
            AlterColumn("dbo.LeaveDatas", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.LeaveDatas", "ApplicationUser_Id");
            AddForeignKey("dbo.LeaveDatas", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveDatas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.LeaveDatas", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.LeaveDatas", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.LeaveDatas", "PMEmployeeID", c => c.Int(nullable: false));
            AlterColumn("dbo.LeaveDatas", "EmployeeID", c => c.Int(nullable: false));
            DropColumn("dbo.EmployeeInfoes", "EmployeeID");
            CreateIndex("dbo.LeaveDatas", "ApplicationUser_Id");
            AddForeignKey("dbo.LeaveDatas", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
