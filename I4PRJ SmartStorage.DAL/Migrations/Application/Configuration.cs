using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Migrations.Application
{
  using System;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<SmartStorage.DAL.Context.Application.ApplicationDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
      MigrationsDirectory = @"Migrations\Application";
    }

    protected override void Seed(SmartStorage.DAL.Context.Application.ApplicationDbContext context)
    {
      // Inventory
      context.Inventories.AddOrUpdate(i => i.Name,
        new Inventory { Name = "Main storage", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Inventory { Name = "Bar 1", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Inventory { Name = "Bar 2", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Inventory { Name = "Hostess station", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false }
      );

      // Category
      context.Categories.AddOrUpdate(c => c.Name,
        new Category { Name = "Liquor", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Category { Name = "Beer", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Category { Name = "Soft Drink", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Category { Name = "RTD", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Category { Name = "Champange", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false }
      );

      // Supplier
      context.Suppliers.AddOrUpdate(s => s.Name,
        new Supplier { Name = "Liquor supplier", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Supplier { Name = "Beer supplier", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Supplier { Name = "Energy supplier", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Supplier { Name = "RTD Supplier", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Supplier { Name = "Champange Supplier", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Supplier { Name = "Others Supplier", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false }
      );

      // Wholesaler
      context.Wholesalers.AddOrUpdate(w => w.Name,
        new Wholesaler { Name = "Main wholesaler", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Wholesaler { Name = "Other wholesaler", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false }
      );

      context.SaveChanges();

      // Product
      context.Products.AddOrUpdate(p => p.Name,
        new Product { Name = "Vodka 0,70 L", CategoryId = context.Categories.First(c => c.Name == "Liquor").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Liquor supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Main wholesaler").WholesalerId, PurchasePrice = 91.47, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Rom 0,70 L", CategoryId = context.Categories.First(c => c.Name == "Liquor").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Liquor supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Main wholesaler").WholesalerId, PurchasePrice = 88.56, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Gin 0,70 L", CategoryId = context.Categories.First(c => c.Name == "Liquor").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Liquor supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Main wholesaler").WholesalerId, PurchasePrice = 89.75, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Tequila 0,70 L", CategoryId = context.Categories.First(c => c.Name == "Liquor").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Liquor supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Main wholesaler").WholesalerId, PurchasePrice = 83.37, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Royal 33,0 CL", CategoryId = context.Categories.First(c => c.Name == "Beer").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Beer supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Other wholesaler").WholesalerId, PurchasePrice = 4.45, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Classic 33,0 CL", CategoryId = context.Categories.First(c => c.Name == "Beer").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Beer supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Other wholesaler").WholesalerId, PurchasePrice = 7.28, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "X-Mas 33,0 CL", CategoryId = context.Categories.First(c => c.Name == "Beer").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Beer supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Other wholesaler").WholesalerId, PurchasePrice = 5.13, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Spring water 0,50 L", CategoryId = context.Categories.First(c => c.Name == "Soft Drink").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Beer supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Other wholesaler").WholesalerId, PurchasePrice = 4.70, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Energy 25,0 CL", CategoryId = context.Categories.First(c => c.Name == "Soft Drink").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Energy supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Other wholesaler").WholesalerId, PurchasePrice = 9.95, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Juice 1,00 L", CategoryId = context.Categories.First(c => c.Name == "Soft Drink").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Others supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Main wholesaler").WholesalerId, PurchasePrice = 7.95, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Soda 25,0 CL", CategoryId = context.Categories.First(c => c.Name == "Soft Drink").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Beer supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Other wholesaler").WholesalerId, PurchasePrice = 4.37, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Pineapple Alko-Soda 27,5 CL", CategoryId = context.Categories.First(c => c.Name == "RTD").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "RTD supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Main wholesaler").WholesalerId, PurchasePrice = 10.69, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Orange Alko-Soda 27,5 CL", CategoryId = context.Categories.First(c => c.Name == "RTD").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "RTD supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Main wholesaler").WholesalerId, PurchasePrice = 10.69, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Brut 0,75 L", CategoryId = context.Categories.First(c => c.Name == "Champange").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Champange supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Main wholesaler").WholesalerId, PurchasePrice = 249.80, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
        new Product { Name = "Demi-Sec 0,75 L", CategoryId = context.Categories.First(c => c.Name == "Champange").CategoryId, SupplierId = context.Suppliers.First(c => c.Name == "Champange supplier").SupplierId, WholesalerId = context.Wholesalers.First(w => w.Name == "Main wholesaler").WholesalerId, PurchasePrice = 269.99, ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false }
      );

      context.SaveChanges();

      // Transaction
      context.Transactions.AddOrUpdate(t => t.ProductId,
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Vodka 0,70 L").ProductId, Quantity = 300, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Rom 0,70 L").ProductId, Quantity = 300, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Gin 0,70 L").ProductId, Quantity = 300, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Tequila 0,70 L").ProductId, Quantity = 150, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Royal 33,0 CL").ProductId, Quantity = 240, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Classic 33,0 CL").ProductId, Quantity = 120, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "X-Mas 33,0 CL").ProductId, Quantity = 120, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Spring water 0,50 L").ProductId, Quantity = 96, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Energy 25,0 CL").ProductId, Quantity = 240, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Juice 1,00 L").ProductId, Quantity = 60, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Soda 25,0 CL").ProductId, Quantity = 90, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Pineapple Alko-Soda 27,5 CL").ProductId, Quantity = 240, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Orange Alko-Soda 27,5 CL").ProductId, Quantity = 240, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Brut 0,75 L").ProductId, Quantity = 60, ByUser = "Dummy", Updated = DateTime.Now },
        new Transaction { ToInventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Demi-Sec 0,75 L").ProductId, Quantity = 60, ByUser = "Dummy", Updated = DateTime.Now }
      );

      context.SaveChanges();

      // Stock
      context.Stocks.AddOrUpdate(s => s.ProductId,
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Vodka 0,70 L").ProductId, Quantity = 300 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Rom 0,70 L").ProductId, Quantity = 300 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Gin 0,70 L").ProductId, Quantity = 300 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Tequila 0,70 L").ProductId, Quantity = 150 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Royal 33,0 CL").ProductId, Quantity = 240 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Classic 33,0 CL").ProductId, Quantity = 120 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "X-Mas 33,0 CL").ProductId, Quantity = 120 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Spring water 0,50 L").ProductId, Quantity = 96 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Energy 25,0 CL").ProductId, Quantity = 240 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Juice 1,00 L").ProductId, Quantity = 60 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Soda 25,0 CL").ProductId, Quantity = 90 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Pineapple Alko-Soda 27,5 CL").ProductId, Quantity = 240 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Orange Alko-Soda 27,5 CL").ProductId, Quantity = 240 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Brut 0,75 L").ProductId, Quantity = 60 },
        new Stock { InventoryId = context.Inventories.First(i => i.Name == "Main storage").InventoryId, ProductId = context.Products.First(p => p.Name == "Demi-Sec 0,75 L").ProductId, Quantity = 60 }
      );

      context.SaveChanges();

    }
  }
}

