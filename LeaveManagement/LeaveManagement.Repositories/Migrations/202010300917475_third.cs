﻿namespace LeaveManagement.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeInfoes", "Bio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeInfoes", "Bio");
        }
    }
}
