namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        FromInventoryId = c.Int(nullable: false),
                        ToInventoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        ByUser = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        FromInventory_InventoryId = c.Int(),
                        ToInventory_InventoryId = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Inventories", t => t.FromInventory_InventoryId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Inventories", t => t.ToInventory_InventoryId)
                .Index(t => t.ProductId)
                .Index(t => t.FromInventory_InventoryId)
                .Index(t => t.ToInventory_InventoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ToInventory_InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Transactions", "FromInventory_InventoryId", "dbo.Inventories");
            DropIndex("dbo.Transactions", new[] { "ToInventory_InventoryId" });
            DropIndex("dbo.Transactions", new[] { "FromInventory_InventoryId" });
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            DropTable("dbo.Transactions");
        }
    }
}
