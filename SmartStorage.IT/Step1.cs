using AutoMapper;
using Microsoft.Practices.Unity;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Mapping;
using SmartStorage.BLL.Services;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Models;
using SmartStorage.DAL.Repositories;
using SmartStorage.UI;
using SmartStorage.UI.Controllers;
using SmartStorage.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartStorage.IT
{
  [TestFixture()]
  class Step1
  {
    private IUnitOfWork _uow;
    private CategoryService _categoryService;
    private List<Category> categoryList;
    private CategoryDto singleCategoryDto;
    private CategoriesController _categoriesController;
    private HttpContextBase _contextBase;
    private ApplicationDbContext _context;
    private Repository<Category> _repository;
    private DbSet<Category> _dbSet;
    protected DbContext _dbContext;


    [SetUp]
    public void SetUp()
    {
      _dbSet = Substitute.For<DbSet<Category>>();
      _context = Substitute.For<ApplicationDbContext>();
      _dbContext = _context;
      _uow = UnityConfig.GetConfiguredContainer().Resolve<IUnitOfWork>(new DependencyOverride<ApplicationDbContext>(_context));
      //_repository = new Repository<Category>(_dbContext);
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());
      _categoryService = new CategoryService(_uow);
      _categoriesController = new CategoriesController(_categoryService);

      _contextBase = Substitute.For<HttpContextBase>();
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _categoriesController.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _categoriesController);

      categoryList = new List<Category>
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

      _repository = new CategoriesRepository(_context);

      var entity = Mapper.Map<CategoryDto, Category>(categoryDto);

      _dbSet.Add(entity).Returns(entity);

      _categoriesController.Create(viewModel);

      _uow.Categories.Add(entity);

      _categoryService.Received().Add(viewModel.Category);

      //Service
      //var entity = Mapper.Map<CategoryDto, Category>(categoryDto);

      //_categoryService.Received().Add(categoryDto);

      //_uow.Received().Categories.Add(entity);
      //_uow.Received().Complete();
    }
  }
}
