using AutoMapper;
using Microsoft.Practices.Unity;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Mapping;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Models;
using SmartStorage.UI;
using SmartStorage.UI.Controllers;
using SmartStorage.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartStorage.IT
{
  [TestFixture()]
  class Step1
  {
    private HttpContextBase _contextBase;
    private IApplicationDbContext _context;
    private CategoriesController _categoriesController;
    private IUnitOfWork _uow;
    private List<Category> _categoryList;
    private ICategoryService _categoryService;



    [SetUp]
    public void SetUp()
    {
      _context = Substitute.For<IApplicationDbContext>();
      _uow = UnityConfig.GetConfiguredContainer().Resolve<IUnitOfWork>(new DependencyOverride<IApplicationDbContext>(_context));

      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      _categoryService = UnityConfig.GetConfiguredContainer().Resolve<ICategoryService>();
      _categoriesController = new CategoriesController(_categoryService);
      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _categoriesController.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _categoriesController);

      _categoryList = new List<Category>
            {
                new Category()
                {
                    Name = "Beer",
                    ByUser = "Admin",
                    CategoryId = 1,
                    IsDeleted = false,
                    Updated = DateTime.Today
                },

                new Category()
                {
                    Name = "Soft drinks",
                    ByUser = "Admin",
                    CategoryId = 2,
                    IsDeleted = true,
                    Updated = DateTime.Today

                }
            };
    }

    [Test]
    public void CategoryServiceAdd_UnitOfWorkAddAndComplete_ReturnsUnitOfWorkAddAndComplete()
    {
      //Controller
      var categoryDto = new CategoryDto() { Name = "Test" };

      var viewModel = new CategoryEditModel
      {
        Category = categoryDto
      };

      _categoriesController.Create(viewModel);

      _context.Received().Categories.Add(Arg.Any<Category>());
    }
  }
}
