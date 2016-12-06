using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Context
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Inventory> Inventories { get; set; }

    public DbSet<Stock> Stocks { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<Status> Statuses { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<Wholesaler> Wholesalers { get; set; }


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
