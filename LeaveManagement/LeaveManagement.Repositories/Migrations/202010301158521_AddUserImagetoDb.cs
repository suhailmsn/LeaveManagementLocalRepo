namespace LeaveManagement.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserImagetoDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeInfoes", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeInfoes", "ImageUrl");
        }
    }
}
