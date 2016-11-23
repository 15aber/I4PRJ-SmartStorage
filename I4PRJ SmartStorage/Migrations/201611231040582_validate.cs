namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Stocks");
            AddPrimaryKey("dbo.Stocks", new[] { "InventoryId", "ProductId" });
            DropColumn("dbo.Stocks", "StockId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "StockId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Stocks");
            AddPrimaryKey("dbo.Stocks", "StockId");
        }
    }
}
