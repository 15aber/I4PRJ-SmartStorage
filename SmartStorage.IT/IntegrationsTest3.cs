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
  class IntegrationTests3
  {
    // DAL
    private DbSet<Supplier> _dbSet;
    private ApplicationDbContext _context;

    // BLL

    // UI
    private SuppliersController _suppliersController;

    // Identity
    private HttpContextBase _contextBase;


    [SetUp]
    public void SetUp()
    {
      // DAL
      _dbSet = Substitute.For<DbSet<Supplier>>();
      _context = Substitute.For<ApplicationDbContext>();
      _context.Set<Supplier>().Returns(_dbSet);
      UnityConfig.GetConfiguredContainer().RegisterInstance<IApplicationDbContext>(_context);

      // BLL
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      // UI
      _suppliersController = UnityConfig.GetConfiguredContainer().Resolve<SuppliersController>();

      // Identity
      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _suppliersController.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _suppliersController);
    }

    [Test]
    public void SuppliersController_PostCreateViewModel_DbSetReceivedAddAndContextReceivedSaveChanges()
    {
      var viewModel = new SupplierEditModel
      {
        Supplier = new SupplierDto() { Name = "Test", IsDeleted = false }
      };

      _suppliersController.Create(viewModel);

      _dbSet.Received(1).Add(Arg.Any<Supplier>());
      _context.Received(1).SaveChanges();
    }

    [Test]
    public void SuppliersController_GetEditViewModel_DbSetReceivedFind()
    {
      _suppliersController.Edit(11);

      _dbSet.Received(1).Find(11);
    }

    [Test]
    public void SuppliersController_PostEditViewModel_DbSetReceivedFind()
    {
      var viewModel = new SupplierEditModel
      {
        Supplier = new SupplierDto() { Name = "Test", IsDeleted = false }
      };

      _suppliersController.Edit(viewModel);

      _dbSet.Received(1).Attach(Arg.Any<Supplier>());
      _context.Received(1).SaveChanges();
    }
  }
}
