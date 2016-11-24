namespace I4PRJ_SmartStorage.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class MergeInit : DbMigration
  {
    public override void Up()
    {
      CreateTable(
          "dbo.Categories",
          c => new
          {
            CategoryId = c.Int(nullable: false, identity: true),
            Name = c.String(nullable: false),
            Updated = c.DateTime(nullable: false),
            ByUser = c.String(),
            IsDeleted = c.Boolean(nullable: false),
          })
          .PrimaryKey(t => t.CategoryId);

      CreateTable(
          "dbo.Inventories",
          c => new
          {
            InventoryId = c.Int(nullable: false, identity: true),
            Name = c.String(nullable: false),
            Updated = c.DateTime(nullable: false),
            ByUser = c.String(),
            IsDeleted = c.Boolean(nullable: false),
          })
          .PrimaryKey(t => t.InventoryId);

      CreateTable(
          "dbo.Products",
          c => new
          {
            ProductId = c.Int(nullable: false, identity: true),
            Name = c.String(nullable: false, maxLength: 255),
            PurchasePrice = c.Double(nullable: false),
            Package = c.Int(),
            CategoryId = c.Int(nullable: false),
            SupplierId = c.Int(nullable: false),
            WholesalerId = c.Int(nullable: false),
            Updated = c.DateTime(nullable: false),
            ByUser = c.String(),
            IsDeleted = c.Boolean(nullable: false),
          })
          .PrimaryKey(t => t.ProductId)
          .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
          .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: false)
          .ForeignKey("dbo.Wholesalers", t => t.WholesalerId, cascadeDelete: false)
          .Index(t => t.CategoryId)
          .Index(t => t.SupplierId)
          .Index(t => t.WholesalerId);

      CreateTable(
          "dbo.Suppliers",
          c => new
          {
            SupplierId = c.Int(nullable: false, identity: true),
            Name = c.String(nullable: false),
            Updated = c.DateTime(nullable: false),
            ByUser = c.String(),
            IsDeleted = c.Boolean(nullable: false),
          })
          .PrimaryKey(t => t.SupplierId);

      CreateTable(
          "dbo.Wholesalers",
          c => new
          {
            WholesalerId = c.Int(nullable: false, identity: true),
            Name = c.String(nullable: false),
            Updated = c.DateTime(nullable: false),
            ByUser = c.String(),
            IsDeleted = c.Boolean(nullable: false),
          })
          .PrimaryKey(t => t.WholesalerId);

      CreateTable(
          "dbo.AspNetRoles",
          c => new
          {
            Id = c.String(nullable: false, maxLength: 128),
            Name = c.String(nullable: false, maxLength: 256),
          })
          .PrimaryKey(t => t.Id)
          .Index(t => t.Name, unique: true, name: "RoleNameIndex");

      CreateTable(
          "dbo.AspNetUserRoles",
          c => new
          {
            UserId = c.String(nullable: false, maxLength: 128),
            RoleId = c.String(nullable: false, maxLength: 128),
          })
          .PrimaryKey(t => new { t.UserId, t.RoleId })
          .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
          .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
          .Index(t => t.UserId)
          .Index(t => t.RoleId);

      CreateTable(
          "dbo.Status",
          c => new
          {
            StatusId = c.Int(nullable: false, identity: true),
            InventoryId = c.Int(nullable: false),
            ProductId = c.Int(nullable: false),
            Quantity = c.Double(nullable: false),
            Difference = c.Double(nullable: false),
            Updated = c.DateTime(nullable: false),
            ByUser = c.String(),
            IsStarted = c.Boolean(nullable: false),
          })
          .PrimaryKey(t => t.StatusId)
          .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: false)
          .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
          .Index(t => t.InventoryId)
          .Index(t => t.ProductId);

      CreateTable(
          "dbo.Stocks",
          c => new
          {
            InventoryId = c.Int(nullable: false),
            ProductId = c.Int(nullable: false),
            Quantity = c.Double(nullable: false),
          })
          .PrimaryKey(t => new { t.InventoryId, t.ProductId })
          .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: false)
          .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
          .Index(t => t.InventoryId)
          .Index(t => t.ProductId);

      CreateTable(
          "dbo.Transactions",
          c => new
          {
            TransactionId = c.Int(nullable: false, identity: true),
            FromInventoryId = c.Int(nullable: false),
            ToInventoryId = c.Int(nullable: false),
            ProductId = c.Int(nullable: false),
            Quantity = c.Double(nullable: false),
            Updated = c.DateTime(nullable: false),
            ByUser = c.String(),
          })
          .PrimaryKey(t => t.TransactionId)
          .ForeignKey("dbo.Inventories", t => t.FromInventoryId, cascadeDelete: false)
          .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
          .ForeignKey("dbo.Inventories", t => t.ToInventoryId, cascadeDelete: false)
          .Index(t => t.FromInventoryId)
          .Index(t => t.ToInventoryId)
          .Index(t => t.ProductId);

      CreateTable(
          "dbo.AspNetUsers",
          c => new
          {
            Id = c.String(nullable: false, maxLength: 128),
            Firstname = c.String(),
            Middlename = c.String(),
            Lastname = c.String(),
            ProfilePicture = c.String(),
            Email = c.String(maxLength: 256),
            EmailConfirmed = c.Boolean(nullable: false),
            PasswordHash = c.String(),
            SecurityStamp = c.String(),
            PhoneNumber = c.String(),
            PhoneNumberConfirmed = c.Boolean(nullable: false),
            TwoFactorEnabled = c.Boolean(nullable: false),
            LockoutEndDateUtc = c.DateTime(),
            LockoutEnabled = c.Boolean(nullable: false),
            AccessFailedCount = c.Int(nullable: false),
            UserName = c.String(nullable: false, maxLength: 256),
          })
          .PrimaryKey(t => t.Id)
          .Index(t => t.UserName, unique: true, name: "UserNameIndex");

      CreateTable(
          "dbo.AspNetUserClaims",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            UserId = c.String(nullable: false, maxLength: 128),
            ClaimType = c.String(),
            ClaimValue = c.String(),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
          .Index(t => t.UserId);

      CreateTable(
          "dbo.AspNetUserLogins",
          c => new
          {
            LoginProvider = c.String(nullable: false, maxLength: 128),
            ProviderKey = c.String(nullable: false, maxLength: 128),
            UserId = c.String(nullable: false, maxLength: 128),
          })
          .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
          .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
          .Index(t => t.UserId);

    }

    public override void Down()
    {
      DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
      DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
      DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
      DropForeignKey("dbo.Transactions", "ToInventoryId", "dbo.Inventories");
      DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
      DropForeignKey("dbo.Transactions", "FromInventoryId", "dbo.Inventories");
      DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
      DropForeignKey("dbo.Stocks", "InventoryId", "dbo.Inventories");
      DropForeignKey("dbo.Status", "ProductId", "dbo.Products");
      DropForeignKey("dbo.Status", "InventoryId", "dbo.Inventories");
      DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
      DropForeignKey("dbo.Products", "WholesalerId", "dbo.Wholesalers");
      DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
      DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
      DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
      DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
      DropIndex("dbo.AspNetUsers", "UserNameIndex");
      DropIndex("dbo.Transactions", new[] { "ProductId" });
      DropIndex("dbo.Transactions", new[] { "ToInventoryId" });
      DropIndex("dbo.Transactions", new[] { "FromInventoryId" });
      DropIndex("dbo.Stocks", new[] { "ProductId" });
      DropIndex("dbo.Stocks", new[] { "InventoryId" });
      DropIndex("dbo.Status", new[] { "ProductId" });
      DropIndex("dbo.Status", new[] { "InventoryId" });
      DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
      DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
      DropIndex("dbo.AspNetRoles", "RoleNameIndex");
      DropIndex("dbo.Products", new[] { "WholesalerId" });
      DropIndex("dbo.Products", new[] { "SupplierId" });
      DropIndex("dbo.Products", new[] { "CategoryId" });
      DropTable("dbo.AspNetUserLogins");
      DropTable("dbo.AspNetUserClaims");
      DropTable("dbo.AspNetUsers");
      DropTable("dbo.Transactions");
      DropTable("dbo.Stocks");
      DropTable("dbo.Status");
      DropTable("dbo.AspNetUserRoles");
      DropTable("dbo.AspNetRoles");
      DropTable("dbo.Wholesalers");
      DropTable("dbo.Suppliers");
      DropTable("dbo.Products");
      DropTable("dbo.Inventories");
      DropTable("dbo.Categories");
    }
  }
}