namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Inventories", "Updated");
            DropColumn("dbo.Inventories", "UpdatedByUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventories", "UpdatedByUser", c => c.String());
            AddColumn("dbo.Inventories", "Updated", c => c.DateTime(nullable: false));
        }
    }
}
