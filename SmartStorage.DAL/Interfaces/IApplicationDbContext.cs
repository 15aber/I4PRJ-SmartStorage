using SmartStorage.DAL.Models;
using System.Data.Entity;

namespace SmartStorage.DAL.Interfaces
{
  public interface IApplicationDbContext
  {
    DbSet<Category> Categories { get; set; }
    DbSet<Inventory> Inventories { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Status> Statuses { get; set; }
    DbSet<Stock> Stocks { get; set; }
    DbSet<Supplier> Suppliers { get; set; }
    DbSet<Transaction> Transactions { get; set; }
    DbSet<Wholesaler> Wholesalers { get; set; }
    int SaveChanges();
    void Dispose();
  }
}