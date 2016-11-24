namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newUpdates : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Inventories", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventories", "IsDeleted", c => c.Boolean(nullable: false));
        }
    }
}
