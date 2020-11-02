namespace LeaveManagement.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSpecialPermission : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "IsSpecialPermission", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "IsSpecialPermission", c => c.Boolean());
        }
    }
}
