namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsStarted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Status", "IsStarted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Status", "IsFinished");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Status", "IsFinished", c => c.Boolean(nullable: false));
            DropColumn("dbo.Status", "IsStarted");
        }
    }
}
