using SmartStorage.DAL.Interfaces.Repositories;

namespace SmartStorage.DAL.Interfaces
{
  public interface IUnitOfWork
  {
    ICategoriesRepository Categories { get; }
    IInventoriesRepository Inventories { get; }
    IProductsRepository Products { get; }
    IStatusesRepository Statuses { get; }
    IStocksRepository Stocks { get; }
    ISuppliersRepository Suppliers { get; }
    ITransactionsRepository Transactions { get; }
    IWholesalersRepository Wholesalers { get; }

    int Complete();
    void Dispose();
  }
}