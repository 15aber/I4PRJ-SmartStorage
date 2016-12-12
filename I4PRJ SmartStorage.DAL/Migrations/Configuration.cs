using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SmartStorage.DAL.Migrations
{
  internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(ApplicationDbContext context)
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

      // Admin User
      var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
      var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
      userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
      {
        AllowOnlyAlphanumericUserNames = false,
        RequireUniqueEmail = true
      };

      if (!roleManager.RoleExists("Admin"))
      {
        var role = new IdentityRole { Name = "Admin" };
        roleManager.Create(role);
      }

      var userInDb = userManager.FindByName("no-reply@smartstorage.dk");

      if (userInDb == null)
      {
        var user = new ApplicationUser
        {
          UserName = "no-reply@smartstorage.dk",
          Email = "no-reply@smartstorage.dk",
          FullName = "Admin",
          PhoneNumber = "12345678",
          ProfilePicture = "/Content/images/rubber-duck.png",
          EmailConfirmed = true,
          PhoneNumberConfirmed = true,
          LockoutEnabled = false
        };

        string userPWD = "SmartStorage2016";

        var result = userManager.Create(user, userPWD);

        if (result.Succeeded)
        {
          userManager.AddToRole(user.Id, "Admin");
        }
      }
      else
      {
        userInDb.Email = "no-reply@smartstorage.dk";
        userInDb.FullName = "Admin";
        userInDb.PhoneNumber = "12345678";
        userInDb.ProfilePicture = "/Content/images/rubber-duck.png";
        userInDb.EmailConfirmed = true;
        userInDb.PhoneNumberConfirmed = true;
        userInDb.LockoutEnabled = false;

        if (!userManager.IsInRole(userInDb.Id, "Admin"))
        {
          userManager.AddToRole(userInDb.Id, "Admin");
        }
      }
    }
  }
}
