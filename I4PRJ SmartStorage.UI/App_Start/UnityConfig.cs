using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using I4PRJ_SmartStorage.BLL.Services;
using I4PRJ_SmartStorage.Controllers;
using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.Interfaces;
using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using I4PRJ_SmartStorage.DAL.Repositories;
using I4PRJ_SmartStorage.DAL.UnitOfWork;
using Microsoft.Practices.Unity;
using System;

namespace I4PRJ_SmartStorage
{
  /// <summary>
  /// Specifies the Unity configuration for the main container.
  /// </summary>
  public class UnityConfig
  {
    #region Unity Container
    private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
    {
      var container = new UnityContainer();
      RegisterTypes(container);
      return container;
    });

    /// <summary>
    /// Gets the configured Unity container.
    /// </summary>
    public static IUnityContainer GetConfiguredContainer()
    {
      return container.Value;
    }
    #endregion

    /// <summary>Registers the type mappings with the Unity container.</summary>
    /// <param name="container">The unity container to configure.</param>
    /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
    /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
    public static void RegisterTypes(IUnityContainer container)
    {
      // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
      // container.LoadConfiguration();

      //DAL
      container.RegisterType<IUnitOfWork, UnitOfWork>(new InjectionConstructor(new ApplicationDbContext()));
      container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
      container.RegisterType<ICategoriesRepository, CategoriesRepository>();
      container.RegisterType<IInventoriesRepository, InventoriesRepository>();
      container.RegisterType<IProductsRepository, ProductsRepository>();
      container.RegisterType<IStatusesRepository, StatusesRepository>();
      container.RegisterType<IStocksRepository, StocksRepository>();
      container.RegisterType<ISuppliersRepository, SuppliersRepository>();
      container.RegisterType<ITransactionsRepository, TransactionsRepository>();
      container.RegisterType<IWholesalersRepository, WholesalersRepository>();

      //BLL
      container.RegisterType<ICategoryService, CategoryService>();
      container.RegisterType<IInventoryService, InventoryService>();
      container.RegisterType<IProductService, ProductService>();
      container.RegisterType<IStatusService, StatusService>();
      container.RegisterType<IStockService, StockService>();
      container.RegisterType<ISupplierService, SupplierService>();
      container.RegisterType<ITransactionService, TransactionService>();
      container.RegisterType<IWholesalerService, WholesalerService>();

      // UI
      container.RegisterType<AccountController>(new InjectionConstructor());
      container.RegisterType<ManageController>(new InjectionConstructor());

    }
  }
}
