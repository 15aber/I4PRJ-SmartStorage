using SmartStorage.DAL.Models;
using System.Data.Entity;

namespace SmartStorage.DAL.Interfaces
{
  public interface IApplicationDbContext
  {
    IDbSet<Category> Categories { get; set; }
    IDbSet<Inventory> Inventories { get; set; }
    IDbSet<Product> Products { get; set; }
    IDbSet<Status> Statuses { get; set; }
    IDbSet<Stock> Stocks { get; set; }
    IDbSet<Supplier> Suppliers { get; set; }
    IDbSet<Transaction> Transactions { get; set; }
    IDbSet<Wholesaler> Wholesalers { get; set; }
    int SaveChanges();
    void Dispose();
  }
}