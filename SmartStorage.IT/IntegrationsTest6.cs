using System;
using AutoMapper;
using Microsoft.Practices.Unity;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Mapping;
using SmartStorage.DAL.Context.Application;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Models;
using SmartStorage.UI;
using SmartStorage.UI.Controllers;
using SmartStorage.UI.ViewModels;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IntegrationTests
{
  [TestFixture()]
  class IntegrationTests6
  {
    // DAL
    private DbSet<Transaction> _dbSet;
    private DbSet<Stock> _dbSetStocks;
    private ApplicationDbContext _context;

    // BLL

    // UI
    private TransactionsController _transactionsController;

    // Identity
    private HttpContextBase _contextBase;

    // Dummy data
    private Inventory _inventory;
    private Stock _stock;


    [SetUp]
    public void SetUp()
    {
      // DAL
      _dbSet = Substitute.For<DbSet<Transaction>>();
      _dbSetStocks = Substitute.For<DbSet<Stock>>();
      _context = Substitute.For<ApplicationDbContext>();
      _context.Set<Transaction>().Returns(_dbSet);
      _context.Set<Stock>().Returns(_dbSetStocks);
      UnityConfig.GetConfiguredContainer().RegisterInstance<IApplicationDbContext>(_context);

      // BLL
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      // UI
      _transactionsController = UnityConfig.GetConfiguredContainer().Resolve<TransactionsController>();

      // Identity
      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _transactionsController.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _transactionsController);

      _inventory = new Inventory()
      {
        ByUser = "Test",
        InventoryId = 1,
        IsDeleted = false,
        Name = "Test",
        Updated = DateTime.Now
      };

      _stock = new Stock()
      { Inventory = _inventory,
        InventoryId = 1,
        ProductId = 1
      };
    }

    [Test]
    public void TransactionsController_PostCreateViewModel_DbSetReceivedAddAndContextReceivedSaveChanges()
    {
      var viewModel = new TransactionEditModel
      {
        Transaction = new TransactionDto() { ProductId = 1, FromInventoryId = 1, ToInventoryId = 2, TransactionId = 1, FromInventory = _inventory 
        }
      };

      _transactionsController.Create(viewModel);

      _dbSet.Received(1).Add(Arg.Any<Transaction>());
      _context.Received(1).SaveChanges();
    }
  }
}
