namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddTimeAndUserToTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "ByUser", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Transactions", "ByUser");
            DropColumn("dbo.Transactions", "DateTime");
        }
    }
}