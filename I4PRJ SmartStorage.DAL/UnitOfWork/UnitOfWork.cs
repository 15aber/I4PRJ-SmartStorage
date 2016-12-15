using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;

namespace SmartStorage.DAL.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly IApplicationDbContext _context;

    public UnitOfWork(IApplicationDbContext context, ICategoriesRepository categories, IInventoriesRepository inventories, IProductsRepository products, IStatusesRepository statuses, IStocksRepository stocks, ISuppliersRepository suppliers, ITransactionsRepository transactions, IWholesalersRepository wholesalers)
    {
      _context = context;
      Categories = categories;
      Inventories = inventories;
      Products = products;
      Statuses = statuses;
      Stocks = stocks;
      Suppliers = suppliers;
      Transactions = transactions;
      Wholesalers = wholesalers;
      //Categories = new CategoriesRepository(_context);
      //Inventories = new InventoriesRepository(_context);
      //Products = new ProductsRepository(_context);
      //Statuses = new StatusesRepository(_context);
      //Stocks = new StocksRepository(_context);
      //Suppliers = new SuppliersRepository(_context);
      //Transactions = new TransactionsRepository(_context);
      //Wholesalers = new WholesalersRepository(_context);
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
