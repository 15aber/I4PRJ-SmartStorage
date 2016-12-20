using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Migrations.Identity
{
  using System.Data.Entity.Migrations;

  internal sealed class Configuration : DbMigrationsConfiguration<SmartStorage.DAL.Context.Identity.AspNetIdentityDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
      MigrationsDirectory = @"Migrations\Identity";
    }

    protected override void Seed(SmartStorage.DAL.Context.Identity.AspNetIdentityDbContext context)
    {
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
