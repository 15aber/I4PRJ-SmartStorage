namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatus : DbMigration
    {
        public override void Up()
        {
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
                        IsFinished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StatusId)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InventoryId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Status", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Status", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.Status", new[] { "ProductId" });
            DropIndex("dbo.Status", new[] { "InventoryId" });
            DropTable("dbo.Status");
        }
    }
}
