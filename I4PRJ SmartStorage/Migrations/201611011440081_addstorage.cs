namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstorage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        StorageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StorageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Storages");
        }
    }
}
