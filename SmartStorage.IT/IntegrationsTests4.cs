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
  class IntegrationTests4
  {
    // DAL
    private DbSet<Inventory> _dbSet;
    private ApplicationDbContext _context;

    // BLL

    // UI
    private InventoriesController _inventoriesController;

    // Identity
    private HttpContextBase _contextBase;


    [SetUp]
    public void SetUp()
    {
      // DAL
      _dbSet = Substitute.For<DbSet<Inventory>>();
      _context = Substitute.For<ApplicationDbContext>();
      _context.Set<Inventory>().Returns(_dbSet);
      UnityConfig.GetConfiguredContainer().RegisterInstance<IApplicationDbContext>(_context);

      // BLL
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      // UI
      _inventoriesController = UnityConfig.GetConfiguredContainer().Resolve<InventoriesController>();

      // Identity
      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _inventoriesController.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _inventoriesController);
    }

    [Test]
    public void InventoriesController_PostCreateViewModel_DbSetReceivedAddAndContextReceivedSaveChanges()
    {
      var viewModel = new InventoryEditModel
      {
        Inventory = new InventoryDto() { Name = "Test", IsDeleted = false }
      };

      _inventoriesController.Create(viewModel);

      _dbSet.Received(1).Add(Arg.Any<Inventory>());
      _context.Received(1).SaveChanges();
    }

    [Test]
    public void InventoriesController_GetEditViewModel_DbSetReceivedFind()
    {
      _inventoriesController.Edit(11);

      _dbSet.Received(1).Find(11);
    }

    [Test]
    public void InventoriesController_PostEditViewModel_DbSetReceivedFind()
    {
      var viewModel = new InventoryEditModel
      {
        Inventory = new InventoryDto() { Name = "Test", IsDeleted = false }
      };

      _inventoriesController.Edit(viewModel);

      _dbSet.Received(1).Attach(Arg.Any<Inventory>());
      _context.Received(1).SaveChanges();
    }
  }
}
