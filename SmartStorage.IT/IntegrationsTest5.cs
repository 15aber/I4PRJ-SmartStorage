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
  class IntegrationTests5
  {
    // DAL
    private DbSet<Product> _dbSet;
    private ApplicationDbContext _context;

    // BLL

    // UI
    private ProductsController _productsController;

    // Identity
    private HttpContextBase _contextBase;


    [SetUp]
    public void SetUp()
    {
      // DAL
      _dbSet = Substitute.For<DbSet<Product>>();
      _context = Substitute.For<ApplicationDbContext>();
      _context.Set<Product>().Returns(_dbSet);
      UnityConfig.GetConfiguredContainer().RegisterInstance<IApplicationDbContext>(_context);

      // BLL
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      // UI
      _productsController = UnityConfig.GetConfiguredContainer().Resolve<ProductsController>();

      // Identity
      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _productsController.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _productsController);
    }

    [Test]
    public void ProductsController_PostCreateViewModel_DbSetReceivedAddAndContextReceivedSaveChanges()
    {
      var viewModel = new ProductEditModel
      {
        Product = new ProductDto() { Name = "Test", IsDeleted = false }
      };

      _productsController.Create(viewModel);

      _dbSet.Received(1).Add(Arg.Any<Product>());
      _context.Received(1).SaveChanges();
    }

    [Test]
    public void ProductsController_GetEditViewModel_DbSetReceivedFind()
    {
      _productsController.Edit(11);

      _dbSet.Received(1).Find(11);
    }

    [Test]
    public void ProductsController_PostEditViewModel_DbSetReceivedFind()
    {
      var viewModel = new ProductEditModel
      {
        Product = new ProductDto() { Name = "Test", IsDeleted = false }
      };

      _productsController.Edit(viewModel);

      _dbSet.Received(1).Attach(Arg.Any<Product>());
      _context.Received(1).SaveChanges();
    }
  }
}
