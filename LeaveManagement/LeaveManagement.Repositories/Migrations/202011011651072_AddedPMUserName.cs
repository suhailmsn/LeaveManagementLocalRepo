namespace LeaveManagement.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPMUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaveDatas", "EmployeeUserName", c => c.String());
            AddColumn("dbo.LeaveDatas", "PMUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeaveDatas", "PMUserName");
            DropColumn("dbo.LeaveDatas", "EmployeeUserName");
        }
    }
}
