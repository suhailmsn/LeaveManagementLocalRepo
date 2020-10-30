namespace LeaveManagement.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeIDForeignkeyAdded : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.EmployeeEducations", new[] { "EmployeeEducationID" });
            DropIndex("dbo.EmployeeInfoes", new[] { "EmployeeInfoID" });
            DropPrimaryKey("dbo.EmployeeEducations");
            DropPrimaryKey("dbo.EmployeeInfoes");
            AlterColumn("dbo.EmployeeEducations", "EmployeeEducationID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeInfoes", "EmployeeInfoID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.EmployeeEducations", "EmployeeEducationID");
            AddPrimaryKey("dbo.EmployeeInfoes", "EmployeeInfoID");
            CreateIndex("dbo.EmployeeEducations", "EmployeeEducationID");
            CreateIndex("dbo.EmployeeInfoes", "EmployeeInfoID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.EmployeeInfoes", new[] { "EmployeeInfoID" });
            DropIndex("dbo.EmployeeEducations", new[] { "EmployeeEducationID" });
            DropPrimaryKey("dbo.EmployeeInfoes");
            DropPrimaryKey("dbo.EmployeeEducations");
            AlterColumn("dbo.EmployeeInfoes", "EmployeeInfoID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.EmployeeEducations", "EmployeeEducationID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.EmployeeInfoes", "EmployeeInfoID");
            AddPrimaryKey("dbo.EmployeeEducations", "EmployeeEducationID");
            CreateIndex("dbo.EmployeeInfoes", "EmployeeInfoID");
            CreateIndex("dbo.EmployeeEducations", "EmployeeEducationID");
        }
    }
}
