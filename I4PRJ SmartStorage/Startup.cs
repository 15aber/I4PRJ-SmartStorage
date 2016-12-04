using I4PRJ_SmartStorage.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(I4PRJ_SmartStorage.Startup))]

namespace I4PRJ_SmartStorage
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);
      CreateRolesandUsers();
    }

    // In this method we will create default User roles and Admin user for login   
    private async Task CreateRolesandUsers()
    {
      ApplicationDbContext context = new ApplicationDbContext();

      var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
      var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
      userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
      {
        AllowOnlyAlphanumericUserNames = false,
        RequireUniqueEmail = true
      };

      // In Startup iam creating first Admin Role and creating a default Admin User    
      if (!roleManager.RoleExists("Admin"))
      {

        // first we create Admin rool   
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Admin" };
        roleManager.Create(role);

        //Here we create a Admin super user who will maintain the website                  
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

        var chkUser = await userManager.CreateAsync(user, userPWD);

        //Add default User to Role Admin   
        if (chkUser.Succeeded)
        {
          var result = userManager.AddToRole(user.Id, "Admin");

        }
      }

    }
  }
}