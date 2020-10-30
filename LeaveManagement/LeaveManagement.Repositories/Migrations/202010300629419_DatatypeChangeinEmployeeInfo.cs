namespace LeaveManagement.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatatypeChangeinEmployeeInfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeInfoes", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeInfoes", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
