namespace LeaveManagement.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTablesforLeaveData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveDatas",
                c => new
                    {
                        LeaveID = c.Int(nullable: false, identity: true),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        DateOfRequest = c.DateTime(nullable: false),
                        LeaveTypeID = c.Int(nullable: false),
                        LeaveReason = c.String(),
                        ApprovalStatus = c.Int(nullable: false),
                        ApprovedBy = c.String(),
                        EmployeeID = c.Int(nullable: false),
                        PMEmployeeID = c.Int(nullable: false),
                        IsForenoonOnly = c.Boolean(nullable: false),
                        IsAfternoonOnly = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LeaveID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.LeaveTypes", t => t.LeaveTypeID, cascadeDelete: true)
                .Index(t => t.LeaveTypeID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.LeaveTypes",
                c => new
                    {
                        LeaveTypeID = c.Int(nullable: false, identity: true),
                        LeaveTypeName = c.String(),
                    })
                .PrimaryKey(t => t.LeaveTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveDatas", "LeaveTypeID", "dbo.LeaveTypes");
            DropForeignKey("dbo.LeaveDatas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.LeaveDatas", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.LeaveDatas", new[] { "LeaveTypeID" });
            DropTable("dbo.LeaveTypes");
            DropTable("dbo.LeaveDatas");
        }
    }
}
