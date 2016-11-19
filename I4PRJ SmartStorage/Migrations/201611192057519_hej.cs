namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hej : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ByUser = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PurchasePrice = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ByUser = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        InventoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Difference = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        IsStarted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StatusId)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InventoryId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockId = c.Int(nullable: false, identity: true),
                        InventoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StockId)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InventoryId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        FromInventoryId = c.Int(),
                        ToInventoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        ByUser = c.String(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Inventories", t => t.FromInventoryId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Inventories", t => t.ToInventoryId, cascadeDelete: true)
                .Index(t => t.FromInventoryId)
                .Index(t => t.ToInventoryId)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Categories", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "ByUser", c => c.String());
            AddColumn("dbo.Categories", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ToInventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Stocks", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Status", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Status", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            DropIndex("dbo.Transactions", new[] { "ToInventoryId" });
            DropIndex("dbo.Transactions", new[] { "FromInventoryId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Stocks", new[] { "InventoryId" });
            DropIndex("dbo.Status", new[] { "ProductId" });
            DropIndex("dbo.Status", new[] { "InventoryId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Categories", "Name", c => c.String());
            DropColumn("dbo.Categories", "IsDeleted");
            DropColumn("dbo.Categories", "ByUser");
            DropColumn("dbo.Categories", "Updated");
            DropTable("dbo.Transactions");
            DropTable("dbo.Stocks");
            DropTable("dbo.Status");
            DropTable("dbo.Products");
            DropTable("dbo.Inventories");
        }
    }
}
