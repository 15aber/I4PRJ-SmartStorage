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
  class IntegrationsTests1
  {
    // DAL
    private DbSet<Category> _dbSet;
    private ApplicationDbContext _context;

    // BLL

    // UI
    private CategoriesController _categoriesController;

    // Identity
    private HttpContextBase _contextBase;


    [SetUp]
    public void SetUp()
    {
      // DAL
      _dbSet = Substitute.For<DbSet<Category>>();
      _context = Substitute.For<ApplicationDbContext>();
      _context.Set<Category>().Returns(_dbSet);
      UnityConfig.GetConfiguredContainer().RegisterInstance<IApplicationDbContext>(_context);

      // BLL
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      // UI
      _categoriesController = UnityConfig.GetConfiguredContainer().Resolve<CategoriesController>();

      // Identity
      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _categoriesController.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _categoriesController);
    }

    [Test]
    public void CategoriesController_PostCreateViewModel_DbSetReceivedAddAndContextReceivedSaveChanges()
    {
      var viewModel = new CategoryEditModel
      {
        Category = new CategoryDto() { Name = "Test", IsDeleted = false }
      };

      _categoriesController.Create(viewModel);

      _dbSet.Received(1).Add(Arg.Any<Category>());
      _context.Received(1).SaveChanges();
    }

    [Test]
    public void CategoriesController_GetEditViewModel_DbSetReceivedFind()
    {
      _categoriesController.Edit(11);

      _dbSet.Received(1).Find(11);
    }

    [Test]
    public void CategoriesController_PostEditViewModel_DbSetReceivedFind()
    {
      var viewModel = new CategoryEditModel
      {
        Category = new CategoryDto() { Name = "Test", IsDeleted = false }
      };

      _categoriesController.Edit(viewModel);

      _dbSet.Received(1).Attach(Arg.Any<Category>());
      _context.Received(1).SaveChanges();
    }
  }
}
