namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RemoveUpdatetimeUserVersion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "LastUpdated");
            DropColumn("dbo.Categories", "ByUser");
            DropColumn("dbo.Categories", "Version");
            DropColumn("dbo.Inventories", "LastUpdated");
            DropColumn("dbo.Inventories", "ByUser");
            DropColumn("dbo.Inventories", "Version");
            DropColumn("dbo.Products", "LastUpdated");
            DropColumn("dbo.Products", "ByUser");
            DropColumn("dbo.Products", "Version");
            DropColumn("dbo.Stocks", "LastUpdated");
            DropColumn("dbo.Stocks", "ByUser");
            DropColumn("dbo.Stocks", "Version");
            DropColumn("dbo.Transactions", "LastUpdated");
            DropColumn("dbo.Transactions", "ByUser");
            DropColumn("dbo.Transactions", "Version");
        }

        public override void Down()
        {
            AddColumn("dbo.Transactions", "Version",
                c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Transactions", "ByUser", c => c.String());
            AddColumn("dbo.Transactions", "LastUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stocks", "Version",
                c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Stocks", "ByUser", c => c.String());
            AddColumn("dbo.Stocks", "LastUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Version",
                c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Products", "ByUser", c => c.String());
            AddColumn("dbo.Products", "LastUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Inventories", "Version",
                c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Inventories", "ByUser", c => c.String());
            AddColumn("dbo.Inventories", "LastUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "Version",
                c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Categories", "ByUser", c => c.String());
            AddColumn("dbo.Categories", "LastUpdated", c => c.DateTime(nullable: false));
        }
    }
}