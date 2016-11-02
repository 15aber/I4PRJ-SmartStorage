namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsDeactivated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsDeactivated", c => c.Boolean(nullable: false));
            DropColumn("dbo.Categories", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Categories", "IsDeactivated");
        }
    }
}
