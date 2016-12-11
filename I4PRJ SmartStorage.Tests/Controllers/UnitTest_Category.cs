using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Mapping;
using SmartStorage.BLL.ViewModels;
using SmartStorage.UI.Controllers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
  [TestFixture]
  class UnitTest_Category
  {
    private CategoriesController _controller;
    private ICategoryService _service;
    private HttpContextBase _contextBase;

    [SetUp]
    public void SetUp()
    {
      _service = Substitute.For<ICategoryService>();
      _controller = new CategoriesController(_service);
      _contextBase = Substitute.For<HttpContextBase>();
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _controller.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _controller);

    }

    [Test]
    public void Category_LoadCategoryIndex_ReturnsCategoryIndexView()
    {

      var result = _controller.Index() as ViewResult;
      Assert.AreEqual("Index", result.ViewName);
    }

    [Test]
    public void Category_CategoryCreate_ReturnsCategoryIndexView()
    {
      var viewModel = new CategoryEditModel
      {
        Category = new CategoryDto() { Name = "Test" }
      };

      var result = _controller.Create(viewModel) as RedirectToRouteResult;


      Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
    }

    [Test]
    public void Category_CategoryCreate_ReturnsCategoryServiceAdd()
    {
      var viewModel = new CategoryEditModel
      {
        Category = new CategoryDto() { Name = "Test" }
      };

      var result = _controller.Create(viewModel) as RedirectToRouteResult;

      _service.Received().Add(viewModel.Category);
    }

    [Test]
    public void Category_CategoryEdit_ReturnsCategoryServiceUpdate()
    {
      var viewModel = new CategoryEditModel
      {
        Category = new CategoryDto() { Name = "Test" }
      };

      var result = _controller.Edit(viewModel) as RedirectToRouteResult;

      _service.Received().Update(viewModel.Category);
    }

    [Test]
    public void Category_CategoryEdit_ReturnsCategoryIndexView()
    {
      var viewModel = new CategoryEditModel
      {
        Category = new CategoryDto() { Name = "Test" }
      };

      var result = _controller.Edit(viewModel) as RedirectToRouteResult;

      Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
    }
  }
}
