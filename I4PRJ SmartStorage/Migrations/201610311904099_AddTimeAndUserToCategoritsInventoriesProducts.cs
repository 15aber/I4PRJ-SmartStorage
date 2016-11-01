namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeAndUserToCategoritsInventoriesProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "ByUser", c => c.String());
            AddColumn("dbo.Inventories", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Inventories", "ByUser", c => c.String());
            AddColumn("dbo.Products", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "ByUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ByUser");
            DropColumn("dbo.Products", "Updated");
            DropColumn("dbo.Inventories", "ByUser");
            DropColumn("dbo.Inventories", "Updated");
            DropColumn("dbo.Categories", "ByUser");
            DropColumn("dbo.Categories", "Updated");
        }
    }
}
