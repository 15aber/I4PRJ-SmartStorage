namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableFromInventoryId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories");
            DropIndex("dbo.Transactions", new[] { "FromInventoryId" });
            AlterColumn("dbo.Transactions", "FromInventoryId", c => c.Int());
            CreateIndex("dbo.Transactions", "FromInventoryId");
            AddForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories", "InventoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories");
            DropIndex("dbo.Transactions", new[] { "FromInventoryId" });
            AlterColumn("dbo.Transactions", "FromInventoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "FromInventoryId");
            AddForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories", "InventoryId", cascadeDelete: true);
        }
    }
}
