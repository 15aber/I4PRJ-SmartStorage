using I4PRJ_SmartStorage.DAL.Models;
using System.Data.Entity;

namespace I4PRJ_SmartStorage.DAL
{
  public class SmartStorageContext : DbContext
  {
    public SmartStorageContext()
        : base("name=SmartStorageConnection")
    {
      //this.Configuration.LazyLoadingEnabled = false;
    }

    public DbSet<ProductModel> Products { get; set; }

    public DbSet<CategoryModel> Categories { get; set; }

    public DbSet<InventoryModel> Inventories { get; set; }

    public DbSet<StockModel> Stocks { get; set; }

    public DbSet<TransactionModel> Transactions { get; set; }

    public DbSet<StatusModel> Statuses { get; set; }

    public DbSet<SupplierModel> Suppliers { get; set; }

    public DbSet<WholesalerModel> Wholesalers { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //modelBuilder.Configurations.Add(new Configuration());
    }
  }
}
