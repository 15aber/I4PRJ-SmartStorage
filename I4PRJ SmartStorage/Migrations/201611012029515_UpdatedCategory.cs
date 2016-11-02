namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "ByUser", c => c.String());
            AddColumn("dbo.Categories", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
            DropColumn("dbo.Categories", "IsActive");
            DropColumn("dbo.Categories", "ByUser");
            DropColumn("dbo.Categories", "Updated");
        }
    }
}
