namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            DropColumn("dbo.AspNetUsers", "Firstname");
            DropColumn("dbo.AspNetUsers", "Middlename");
            DropColumn("dbo.AspNetUsers", "Lastname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Lastname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Middlename", c => c.String());
            AddColumn("dbo.AspNetUsers", "Firstname", c => c.String());
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
