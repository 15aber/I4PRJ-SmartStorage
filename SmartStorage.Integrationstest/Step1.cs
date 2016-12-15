using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using NSubstitute;
using NUnit.Framework.Internal;
using NUnit.Framework;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Mapping;
using SmartStorage.BLL.Services;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Models;
using SmartStorage.DAL.UnitOfWork;
using SmartStorage.UI.Controllers;
using SmartStorage.UI.ViewModels;

namespace SmartStorage.Integrationstest
{
  [TestFixture()]
  class Step1
  {
    private UnitOfWork _uow;
    private CategoryService _categoryService;
    private List<Category> categoryList;
    private CategoryDto singleCategoryDto;
    private CategoriesController _categoriesController;
    private ApplicationDbContext _dbContext;

    [SetUp]
    public void SetUp()
    {
      _dbContext = Substitute.For<ApplicationDbContext>();
      _uow = new UnitOfWork(_dbContext);
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());
      _categoryService = new CategoryService(_uow);

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

      _categoriesController.Create(viewModel);

      _categoryService.Received().Add(viewModel.Category);

      //Service
      //var entity = Mapper.Map<CategoryDto, Category>(categoryDto);

      //_categoryService.Received().Add(categoryDto);

      //_uow.Received().Categories.Add(entity);
      //_uow.Received().Complete();
    }
  }
}
