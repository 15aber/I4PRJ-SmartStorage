namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Categories", "IsDeactivated");
            DropColumn("dbo.Products", "IsDeactivated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "IsDeactivated", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "IsDeactivated", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "IsDeleted");
            DropColumn("dbo.Categories", "IsDeleted");
        }
    }
}
