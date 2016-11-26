namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class master : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ByUser = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
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
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ByUser = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.Wholesalers",
                c => new
                    {
                        WholesalerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ByUser = c.String(),
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
                        Quantity = c.Double(nullable: false),
                        Difference = c.Double(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ByUser = c.String(),
                        IsStarted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StatusId)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
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
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .Index(t => t.InventoryId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        FromInventoryId = c.Int(nullable: false),
                        ToInventoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        ByUser = c.String(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Inventories", t => t.FromInventoryId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.Inventories", t => t.ToInventoryId, cascadeDelete: false)
                .Index(t => t.FromInventoryId)
                .Index(t => t.ToInventoryId)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Products", "Package", c => c.Int());
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "SupplierId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "WholesalerId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "ByUser", c => c.String());
            AddColumn("dbo.Products", "IsDeleted", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "SupplierId");
            CreateIndex("dbo.Products", "WholesalerId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: false);
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: false);
            AddForeignKey("dbo.Products", "WholesalerId", "dbo.Wholesalers", "WholesalerId", cascadeDelete: false);
            DropColumn("dbo.Products", "ProductName");
            DropColumn("dbo.Products", "Size");
            DropColumn("dbo.Products", "Category");
            DropColumn("dbo.AspNetUsers", "Fullname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Fullname", c => c.String());
            AddColumn("dbo.Products", "Category", c => c.String());
            AddColumn("dbo.Products", "Size", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "ProductName", c => c.String());
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
            DropColumn("dbo.Products", "IsDeleted");
            DropColumn("dbo.Products", "ByUser");
            DropColumn("dbo.Products", "Updated");
            DropColumn("dbo.Products", "WholesalerId");
            DropColumn("dbo.Products", "SupplierId");
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "Package");
            DropColumn("dbo.Products", "Name");
            DropTable("dbo.Transactions");
            DropTable("dbo.Stocks");
            DropTable("dbo.Status");
            DropTable("dbo.Wholesalers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Inventories");
            DropTable("dbo.Categories");
        }
    }
}
