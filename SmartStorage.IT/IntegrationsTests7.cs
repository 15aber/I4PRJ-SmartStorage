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
    private ApplicationDbContext _context;

    // BLL

    // UI
    private StatusController _StatusesController;

    // Identity
    private HttpContextBase _contextBase;

    // Dummy data
    private IQueryable<Status> _data;

    [SetUp]
    public void SetUp()
    {
      _data = new List<Status>
      {
        new Status(){StatusId = 1, InventoryId = 1, ProductId = 1, ByUser = "Hest", CurQuantity = 6, Difference = 6, ExpQuantity = 0, IsStarted = true, Updated = DateTime.Now}
      }.AsQueryable();

      // DAL
      _dbSetInventory = Substitute.For<DbSet<Inventory>>();
      _dbSetStatus = Substitute.For<DbSet<Status>, IQueryable<Status>>();
      ((IQueryable<Status>)_dbSetStatus).Provider.Returns(_data.Provider);
      ((IQueryable<Status>)_dbSetStatus).Expression.Returns(_data.Expression);
      ((IQueryable<Status>)_dbSetStatus).ElementType.Returns(_data.ElementType);
      ((IQueryable<Status>)_dbSetStatus).GetEnumerator().Returns(_data.GetEnumerator());

      _context = Substitute.For<ApplicationDbContext>();
      _context.Set<Status>().Returns(_dbSetStatus);
      _context.Set<Inventory>().Returns(_dbSetInventory);
      UnityConfig.GetConfiguredContainer().RegisterInstance<IApplicationDbContext>(_context);

      // BLL
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      // UI
      _StatusesController = UnityConfig.GetConfiguredContainer().Resolve<StatusController>();

      // Identity
      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _StatusesController.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _StatusesController);
    }

    [Test]
    public void StatusesController_StartStatusInventorySearchDB_DbSetReceivedFindWithId()
    {

      _StatusesController.StartStatus(1);

      _dbSetInventory.Received(1).Find(1);
    }

    [Test]
    public void StatusesController_FinishStatusInventorySearchDB_DbSetReceivedFindWithId()
    {

      _StatusesController.FinishStatus(1);

      _dbSetInventory.Received(1).Find(1);
    }

    [Test]
    public void StatusesController_StatusReportsGetAll_DbSetReceivedFindWithId()
    {

      _StatusesController.StatusReports();

      _dbSetStatus.Received().ToList();
    }

  }
}
