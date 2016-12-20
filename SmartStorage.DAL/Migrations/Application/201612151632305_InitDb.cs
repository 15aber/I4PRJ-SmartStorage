namespace SmartStorage.DAL.Migrations.Application
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Updated = c.DateTime(),
                        ByUser = c.String(maxLength: 256),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Updated = c.DateTime(),
                        ByUser = c.String(maxLength: 256),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        PurchasePrice = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        WholesalerId = c.Int(nullable: false),
                        Updated = c.DateTime(),
                        ByUser = c.String(maxLength: 256),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Wholesalers", t => t.WholesalerId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.SupplierId)
                .Index(t => t.WholesalerId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Updated = c.DateTime(),
                        ByUser = c.String(maxLength: 256),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.Wholesalers",
                c => new
                    {
                        WholesalerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Updated = c.DateTime(),
                        ByUser = c.String(maxLength: 256),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WholesalerId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        InventoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ExpQuantity = c.Double(nullable: false),
                        CurQuantity = c.Double(nullable: false),
                        Difference = c.Double(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ByUser = c.String(maxLength: 256),
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
                        InventoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.InventoryId, t.ProductId })
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
                        Updated = c.DateTime(),
                        ByUser = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Inventories", t => t.FromInventoryId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Inventories", t => t.ToInventoryId, cascadeDelete: true)
                .Index(t => t.FromInventoryId)
                .Index(t => t.ToInventoryId)
                .Index(t => t.ProductId);
            
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
            DropForeignKey("dbo.Products", "WholesalerId", "dbo.Wholesalers");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            DropIndex("dbo.Transactions", new[] { "ToInventoryId" });
            DropIndex("dbo.Transactions", new[] { "FromInventoryId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Stocks", new[] { "InventoryId" });
            DropIndex("dbo.Status", new[] { "ProductId" });
            DropIndex("dbo.Status", new[] { "InventoryId" });
            DropIndex("dbo.Products", new[] { "WholesalerId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Stocks");
            DropTable("dbo.Status");
            DropTable("dbo.Wholesalers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
            DropTable("dbo.Inventories");
            DropTable("dbo.Categories");
        }
    }
}
