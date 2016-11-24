namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryIsActivAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsActiv", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "IsActiv");
        }
    }
}
