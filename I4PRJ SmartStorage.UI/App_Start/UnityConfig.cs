using Microsoft.Practices.Unity;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Services;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Repositories;
using SmartStorage.DAL.UnitOfWork;
using SmartStorage.UI.Controllers;
using System;
using System.Diagnostics.CodeAnalysis;
using SmartStorage.DAL.Context.Application;

namespace SmartStorage.UI
{
  /// <summary>
  /// Specifies the Unity configuration for the main container.
  /// </summary>
  [ExcludeFromCodeCoverage]
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

      // Register your types here
      // container.RegisterType<IProductRepository, ProductRepository>();

      container.RegisterType<IApplicationDbContext, ApplicationDbContext>();

      container.RegisterType<ICategoriesRepository, CategoriesRepository>();
      container.RegisterType<IInventoriesRepository, InventoriesRepository>();
      container.RegisterType<IProductsRepository, ProductsRepository>();
      container.RegisterType<IStatusesRepository, StatusesRepository>();
      container.RegisterType<IStocksRepository, StocksRepository>();
      container.RegisterType<ISuppliersRepository, SuppliersRepository>();
      container.RegisterType<ITransactionsRepository, TransactionsRepository>();
      container.RegisterType<IWholesalersRepository, WholesalersRepository>();

      container.RegisterType<IUnitOfWork, UnitOfWork>();

      container.RegisterType<ICategoryService, CategoryService>();
      container.RegisterType<IInventoryService, InventoryService>();
      container.RegisterType<IProductService, ProductService>();
      container.RegisterType<IStatusService, StatusService>();
      container.RegisterType<IStockService, StockService>();
      container.RegisterType<ISupplierService, SupplierService>();
      container.RegisterType<ITransactionService, TransactionService>();
      container.RegisterType<IWholesalerService, WholesalerService>();

      container.RegisterType<CategoriesController>();
      container.RegisterType<InventoriesController>();
      container.RegisterType<ProductsController>();
      container.RegisterType<StatusController>();
      container.RegisterType<StocksController>();
      container.RegisterType<SuppliersController>();
      container.RegisterType<TransactionsController>();
      container.RegisterType<WholesalersController>();

      container.RegisterType<ManageController>(new InjectionConstructor());
      container.RegisterType<AccountController>(new InjectionConstructor());
    }
  }
}
