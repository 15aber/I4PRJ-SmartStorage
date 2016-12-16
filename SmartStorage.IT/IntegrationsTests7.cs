using AutoMapper;
using Microsoft.Practices.Unity;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.BLL.Mapping;
using SmartStorage.DAL.Context.Application;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Models;
using SmartStorage.UI;
using SmartStorage.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IntegrationTests
{
  [TestFixture()]
  class IntegrationTests7
  {
    // DAL
    private DbSet<Status> _dbSetStatus;
    private DbSet<Inventory> _dbSetInventory;
    private DbSet<Product> _dbSetProduct;
    private ApplicationDbContext _context;

    // BLL

    // UI
    private StatusController _statusesController;

    // Identity
    private HttpContextBase _contextBase;

    // Dummy data
    private IQueryable<Status> _dataStatuses;
    private IQueryable<Inventory> _dataInventories;
    private IQueryable<Product> _dataProducts;

    [SetUp]
    public void SetUp()
    {
      _dataStatuses = new List<Status>
      {
        new Status(){StatusId = 1, InventoryId = 1, ProductId = 1, ByUser = "Hest", CurQuantity = 6, Difference = 6, ExpQuantity = 0, IsStarted = true, Updated = DateTime.Now, Inventory = new Inventory() {InventoryId = 1, Name = "Hest", ByUser = "Hest", Updated = DateTime.Now, IsDeleted = false}, Product = new Product()
        {
          ProductId = 1,
          CategoryId = 1,
          WholesalerId = 1,
          SupplierId = 1,
          Name = "Hest",
          ByUser = "Hest",
          Updated = DateTime.Now,
          IsDeleted = false,
          PurchasePrice = 123
        }}
      }.AsQueryable();

      _dataInventories = new List<Inventory>
      {
        new Inventory() {InventoryId = 1, Name = "Hest", ByUser = "Hest", Updated = DateTime.Now, IsDeleted = false}
      }.AsQueryable();

      _dataProducts = new List<Product>()
      {
        new Product()
        {
          ProductId = 1,
          CategoryId = 1,
          WholesalerId = 1,
          SupplierId = 1,
          Name = "Hest",
          ByUser = "Hest",
          Updated = DateTime.Now,
          IsDeleted = false,
          PurchasePrice = 123
        }
      }.AsQueryable();

      // DAL

      _dbSetStatus = Substitute.For<DbSet<Status>, IQueryable<Status>>();
      ((IQueryable<Status>)_dbSetStatus).Provider.Returns(_dataStatuses.Provider);
      ((IQueryable<Status>)_dbSetStatus).Expression.Returns(_dataStatuses.Expression);
      ((IQueryable<Status>)_dbSetStatus).ElementType.Returns(_dataStatuses.ElementType);
      ((IQueryable<Status>)_dbSetStatus).GetEnumerator().Returns(_dataStatuses.GetEnumerator());

      _dbSetInventory = Substitute.For<DbSet<Inventory>, IQueryable<Inventory>>();
      ((IQueryable<Inventory>)_dbSetInventory).Provider.Returns(_dataInventories.Provider);
      ((IQueryable<Inventory>)_dbSetInventory).Expression.Returns(_dataInventories.Expression);
      ((IQueryable<Inventory>)_dbSetInventory).ElementType.Returns(_dataInventories.ElementType);
      ((IQueryable<Inventory>)_dbSetInventory).GetEnumerator().Returns(_dataInventories.GetEnumerator());

      _dbSetProduct = Substitute.For<DbSet<Product>, IQueryable<Product>>();
      ((IQueryable<Product>)_dbSetProduct).Provider.Returns(_dataProducts.Provider);
      ((IQueryable<Product>)_dbSetProduct).Expression.Returns(_dataProducts.Expression);
      ((IQueryable<Product>)_dbSetProduct).ElementType.Returns(_dataProducts.ElementType);
      ((IQueryable<Product>)_dbSetProduct).GetEnumerator().Returns(_dataProducts.GetEnumerator());

      _context = Substitute.For<ApplicationDbContext>();
      _context.Statuses = _dbSetStatus;
      _context.Set<Status>().Returns(_dbSetStatus);
      _context.Inventories = _dbSetInventory;
      _context.Set<Inventory>().Returns(_dbSetInventory);
      _context.Products = _dbSetProduct;
      _context.Set<Product>().Returns(_dbSetProduct);
      UnityConfig.GetConfiguredContainer().RegisterInstance<IApplicationDbContext>(_context);

      // BLL
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      // UI
      _statusesController = UnityConfig.GetConfiguredContainer().Resolve<StatusController>();

      // Identity
      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _statusesController.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _statusesController);
    }

    [Test]
    public void StatusesController_StartStatusInventorySearchDB_DbSetReceivedFindWithId()
    {

      _statusesController.StartStatus(1);

      _dbSetInventory.Received(1).Find(1);
    }

    [Test]
    public void StatusesController_FinishStatusInventorySearchDB_DbSetReceivedFindWithId()
    {

      _statusesController.FinishStatus(1);

      _dbSetInventory.Received(1).Find(1);
    }

    [Test]
    public void StatusesController_StatusReportsGetAll_DbSetReceivedFindWithId()
    {
      //_statusesController.StatusReports();

      //_dbSetStatus.Received(1);
    }

  }
}
