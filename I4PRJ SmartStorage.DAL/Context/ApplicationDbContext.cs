using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Models;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartStorage.DAL.Context
{
  [ExcludeFromCodeCoverage]
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
  {
    public IDbSet<Product> Products { get; set; }

    public IDbSet<Category> Categories { get; set; }

    public IDbSet<Inventory> Inventories { get; set; }

    public IDbSet<Stock> Stocks { get; set; }

    public IDbSet<Transaction> Transactions { get; set; }

    public IDbSet<Status> Statuses { get; set; }

    public IDbSet<Supplier> Suppliers { get; set; }

    public IDbSet<Wholesaler> Wholesalers { get; set; }

    public ApplicationDbContext()
        : base("DefaultConnection", throwIfV1Schema: false)
    {
    }

    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }
  }
}
