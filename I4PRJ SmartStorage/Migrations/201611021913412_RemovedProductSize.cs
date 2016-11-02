namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedProductSize : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Size", c => c.Double(nullable: false));
        }
    }
}
