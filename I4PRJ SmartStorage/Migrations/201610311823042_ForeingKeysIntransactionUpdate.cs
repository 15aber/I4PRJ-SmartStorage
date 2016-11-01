namespace I4PRJ_SmartStorage.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ForeingKeysIntransactionUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "FromInventory_InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Transactions", "ToInventory_InventoryId", "dbo.Inventories");
            DropIndex("dbo.Transactions", new[] { "FromInventory_InventoryId" });
            DropIndex("dbo.Transactions", new[] { "ToInventory_InventoryId" });
            DropColumn("dbo.Transactions", "FromInventoryId");
            DropColumn("dbo.Transactions", "ToInventoryId");
            RenameColumn(table: "dbo.Transactions", name: "FromInventory_InventoryId", newName: "FromInventoryId");
            RenameColumn(table: "dbo.Transactions", name: "ToInventory_InventoryId", newName: "ToInventoryId");
            AlterColumn("dbo.Transactions", "FromInventoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "ToInventoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "FromInventoryId");
            CreateIndex("dbo.Transactions", "ToInventoryId");
            AddForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories", "InventoryId", cascadeDelete: false);
            AddForeignKey("dbo.Transactions", "ToInventoryId", "dbo.Inventories", "InventoryId", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ToInventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories");
            DropIndex("dbo.Transactions", new[] { "ToInventoryId" });
            DropIndex("dbo.Transactions", new[] { "FromInventoryId" });
            AlterColumn("dbo.Transactions", "ToInventoryId", c => c.Int());
            AlterColumn("dbo.Transactions", "FromInventoryId", c => c.Int());
            RenameColumn(table: "dbo.Transactions", name: "ToInventoryId", newName: "ToInventory_InventoryId");
            RenameColumn(table: "dbo.Transactions", name: "FromInventoryId", newName: "FromInventory_InventoryId");
            AddColumn("dbo.Transactions", "ToInventoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "FromInventoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "ToInventory_InventoryId");
            CreateIndex("dbo.Transactions", "FromInventory_InventoryId");
            AddForeignKey("dbo.Transactions", "ToInventory_InventoryId", "dbo.Inventories", "InventoryId");
            AddForeignKey("dbo.Transactions", "FromInventory_InventoryId", "dbo.Inventories", "InventoryId");
        }
    }
}
