namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories");
            DropIndex("dbo.Transactions", new[] { "FromInventoryId" });
            AddColumn("dbo.Status", "IsStarted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Transactions", "FromInventoryId", c => c.Int());
            CreateIndex("dbo.Transactions", "FromInventoryId");
            AddForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories", "InventoryId");
            DropColumn("dbo.Status", "IsFinished");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Status", "IsFinished", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories");
            DropIndex("dbo.Transactions", new[] { "FromInventoryId" });
            AlterColumn("dbo.Transactions", "FromInventoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Status", "IsStarted");
            CreateIndex("dbo.Transactions", "FromInventoryId");
            AddForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories", "InventoryId", cascadeDelete: true);
        }
    }
}
