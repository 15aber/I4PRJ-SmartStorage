using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Context.Identity
{
  [ExcludeFromCodeCoverage]
  public class AspNetIdentityDbContext : IdentityDbContext<ApplicationUser>
  {
    public AspNetIdentityDbContext()
        : base("DefaultConnection", throwIfV1Schema: false)
    {
    }

    public static AspNetIdentityDbContext Create()
    {
      return new AspNetIdentityDbContext();
    }
  }
}
