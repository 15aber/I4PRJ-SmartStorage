using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace I4PRJ_SmartStorage.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  internal sealed class Configuration : DbMigrationsConfiguration<I4PRJ_SmartStorage.Models.ApplicationDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
    }

    protected override void Seed(I4PRJ_SmartStorage.Models.ApplicationDbContext context)
    {
      context.Inventories.AddOrUpdate(i => i.Name,
          new Inventory { Name = "Main storage", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
          new Inventory { Name = "Bar 1", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
          new Inventory { Name = "Bar 2", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
          new Inventory { Name = "Hostess station", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false }
          );

      context.Categories.AddOrUpdate(c => c.Name,
          new Category { Name = "Liquor", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
          new Category { Name = "Beer", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
          new Category { Name = "Soft Drink", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
          new Category { Name = "Champange", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false }
      );

      context.Suppliers.AddOrUpdate(s => s.Name,
          new Supplier { Name = "Liquor manufacturer", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
          new Supplier { Name = "Beer manufacturer", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false }
      );

      context.Wholesalers.AddOrUpdate(w => w.Name,
          new Wholesaler { Name = "Liquor wholesaler", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false },
          new Wholesaler { Name = "Beer wholesaler", ByUser = "Dummy", Updated = DateTime.Now, IsDeleted = false }
      );

      var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
      var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
      userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
      {
        AllowOnlyAlphanumericUserNames = false,
        RequireUniqueEmail = true
      };

      if (!roleManager.RoleExists("Admin"))
      {
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Admin" };
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
        userInDb.LockoutEnabled = false;

        if (!userManager.IsInRole(userInDb.Id, "Admin"))
        {
          userManager.AddToRole(userInDb.Id, "Admin");
        }
      }
    }
  }
}
