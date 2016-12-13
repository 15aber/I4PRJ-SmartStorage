using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Mapping;
using SmartStorage.BLL.Services;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SmartStorage.UnitTests.Services
{
  [TestFixture]
  class UnitTest_CategoryService
  {
    private IUnitOfWork _uow;
    private CategoryService _categoryService;
    private List<Category> categoryList;
    private CategoryDto singleCategoryDto;

    [SetUp]
    public void SetUp()
    {
      _uow = Substitute.For<IUnitOfWork>();
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
      var categoryDto = new CategoryDto() { Name = "Test" };
      var entity = Mapper.Map<CategoryDto, Category>(categoryDto);

      _categoryService.Add(categoryDto);

      _uow.Received().Categories.Add(entity);
      _uow.Received().Complete();
    }

    [Test]
    public void CategoryServiceUpdate_UnitOfWorkUpdateAndComplete_ReturnsUnitOfWorkUpdateAndComplete()
    {
      var categoryDto = new CategoryDto() { Name = "Test" };
      var entity = Mapper.Map<CategoryDto, Category>(categoryDto);

      _categoryService.Update(categoryDto);

      _uow.Received().Categories.Update(entity);
      _uow.Received().Complete();
    }

    [Test]
    public void CategoryServiceDelete_UnitOfWorkDeleteAndComplete_ReturnsUnitOfWorkDeleteAndComplete()
    {
      var category = new Category() { Name = "Test" };
      _uow.Categories.Get(1).Returns(category);

      _categoryService.Delete(1);

      _uow.Received().Categories.Update(category);
      _uow.Received().Complete();
      Assert.That(category.IsDeleted, Is.EqualTo(true));
    }

    [Test]
    public void CategoryService_GetAll_CountEqualTo2()
    {
      _uow.Categories.GetAll().Returns(categoryList);

      Assert.That(_categoryService.GetAll().Count, Is.EqualTo(2));
    }

    [Test]
    public void CategoryService_GetAllActive_CountEqualTo1()
    {
      _uow.Categories.GetAll(Arg.Any<Expression<Func<Category, bool>>>()).Returns(categoryList.Where(e => e.IsDeleted == false).ToList());

      Assert.That(_categoryService.GetAllActive().Count, Is.EqualTo(1));
    }

    [Test]
    public void CategoryService_GetSingle_ReturnsCategory1()
    {
      var entityDto = Mapper.Map<Category, CategoryDto>(categoryList[0]);
      _uow.Categories.Get(1).Returns(categoryList[0]);

      Assert.That(_categoryService.GetSingle(1).CategoryId, Is.EqualTo(entityDto.CategoryId));
    }
  }
}
