using System;
using System.Collections.Generic;
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
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IntegrationTests
{
  [TestFixture()]
  class IntegrationTests6
  {
    // DAL
    private DbSet<Transaction> _dbSetTransactions;
    private DbSet<Stock> _dbSetStocks;
    private ApplicationDbContext _context;

    // BLL

    // UI
    private TransactionsController _transactionsController;

    // Identity
    private HttpContextBase _contextBase;

    // Dummy data
    private Inventory _inventory;
    private IQueryable<Stock> _data;


    [SetUp]
    public void SetUp()
    {
      _data = new List<Stock>
      {
        new Stock
        {
          Inventory = new Inventory
      {
        ByUser = "Test",
        InventoryId = 1,
        IsDeleted = false,
        Name = "Test",
        Updated = DateTime.Now
      },
          InventoryId = 1,
          ProductId = 1,
          Quantity = 1
        }
      }.AsQueryable();

      // DAL
      _dbSetTransactions = Substitute.For<DbSet<Transaction>>();
      _dbSetStocks = Substitute.For<DbSet<Stock>, IQueryable<Stock>>();
      ((IQueryable<Stock>)_dbSetStocks).Provider.Returns(_data.Provider);
      ((IQueryable<Stock>)_dbSetStocks).Expression.Returns(_data.Expression);
      ((IQueryable<Stock>)_dbSetStocks).ElementType.Returns(_data.ElementType);
      ((IQueryable<Stock>)_dbSetStocks).GetEnumerator().Returns(_data.GetEnumerator());
      _context = Substitute.For<ApplicationDbContext>();
      _context.Set<Transaction>().Returns(_dbSetTransactions);
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
    }

    [Test]
    public void TransactionsController_PostCreateViewModel_DbSetReceivedAddAndContextReceivedSaveChanges()
    {
      var viewModel = new TransactionEditModel
      {
        Transaction = new TransactionDto()
        {
          ProductId = 1,
          FromInventoryId = 1,
          ToInventoryId = 2,
          TransactionId = 1,
          FromInventory = _inventory
        }
      };

      _transactionsController.Create(viewModel);

      _context.Received(1).SaveChanges();
    }
  }
}
