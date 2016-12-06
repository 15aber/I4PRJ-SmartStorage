using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.Interfaces;
using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using I4PRJ_SmartStorage.DAL.Repositories;

namespace I4PRJ_SmartStorage.DAL.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
      _context = context;
      Categories = new CategoriesRepository(_context);
      Inventories = new InventoriesRepository(_context);
      Products = new ProductsRepository(_context);
      Statuses = new StatusesRepository(_context);
      Stocks = new StocksRepository(_context);
      Suppliers = new SuppliersRepository(_context);
      Transactions = new TransactionsRepository(_context);
      Wholesalers = new WholesalersRepository(_context);
    }

    public ICategoriesRepository Categories { get; private set; }
    public IInventoriesRepository Inventories { get; private set; }
    public IProductsRepository Products { get; private set; }
    public IStatusesRepository Statuses { get; private set; }
    public IStocksRepository Stocks { get; private set; }
    public ISuppliersRepository Suppliers { get; private set; }
    public ITransactionsRepository Transactions { get; private set; }
    public IWholesalersRepository Wholesalers { get; private set; }

    public int Complete()
    {
      return _context.SaveChanges();
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
