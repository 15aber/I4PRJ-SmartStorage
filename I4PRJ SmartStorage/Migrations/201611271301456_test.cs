namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories");
            DropIndex("dbo.Transactions", new[] { "FromInventoryId" });
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
            
            AddColumn("dbo.Products", "Package", c => c.Int());
            AddColumn("dbo.Products", "SupplierId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "WholesalerId", c => c.Int(nullable: false));
            AddColumn("dbo.Status", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Status", "ByUser", c => c.String());
            AddColumn("dbo.Transactions", "Updated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Status", "Quantity", c => c.Double(nullable: false));
            AlterColumn("dbo.Status", "Difference", c => c.Double(nullable: false));
            AlterColumn("dbo.Transactions", "FromInventoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "SupplierId");
            CreateIndex("dbo.Products", "WholesalerId");
            CreateIndex("dbo.Transactions", "FromInventoryId");
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: false);
            AddForeignKey("dbo.Products", "WholesalerId", "dbo.Wholesalers", "WholesalerId", cascadeDelete: false);
            AddForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories", "InventoryId", cascadeDelete: false);
            DropColumn("dbo.Status", "DateTime");
            DropColumn("dbo.Transactions", "DateTime");
            DropColumn("dbo.AspNetUsers", "Fullname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Fullname", c => c.String());
            AddColumn("dbo.Transactions", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Status", "DateTime", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Products", "WholesalerId", "dbo.Wholesalers");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Transactions", new[] { "FromInventoryId" });
            DropIndex("dbo.Products", new[] { "WholesalerId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            AlterColumn("dbo.Transactions", "FromInventoryId", c => c.Int());
            AlterColumn("dbo.Status", "Difference", c => c.Int(nullable: false));
            AlterColumn("dbo.Status", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Transactions", "Updated");
            DropColumn("dbo.Status", "ByUser");
            DropColumn("dbo.Status", "Updated");
            DropColumn("dbo.Products", "WholesalerId");
            DropColumn("dbo.Products", "SupplierId");
            DropColumn("dbo.Products", "Package");
            DropTable("dbo.Wholesalers");
            DropTable("dbo.Suppliers");
            CreateIndex("dbo.Transactions", "FromInventoryId");
            AddForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories", "InventoryId");
        }
    }
}
