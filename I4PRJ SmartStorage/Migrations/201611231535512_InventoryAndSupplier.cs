namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryAndSupplier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Inventories", "UpdatedByUser", c => c.String());
            AddColumn("dbo.Inventories", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Inventories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "Name", c => c.String());
            AlterColumn("dbo.Inventories", "Name", c => c.String());
            DropColumn("dbo.Inventories", "IsDeleted");
            DropColumn("dbo.Inventories", "UpdatedByUser");
            DropColumn("dbo.Inventories", "Updated");
        }
    }
}
