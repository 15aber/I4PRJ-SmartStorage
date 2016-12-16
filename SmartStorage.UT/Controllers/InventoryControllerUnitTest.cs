using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Mapping;
using SmartStorage.UI.Controllers;
using SmartStorage.UI.ViewModels;

namespace UnitTests.Controllers
{
  [TestFixture]
  class InventoryControllerUnitTest
  {
    private InventoriesController _controller;
    private IInventoryService _service;
    private HttpContextBase _contextBase;


    [SetUp]
    public void SetUp()
    {
      _service = Substitute.For<IInventoryService>();
      _controller = new InventoriesController(_service);
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());


      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _controller.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _controller);
    }

    [Test]
    public void InventoryIndex_LoadInventoryIndex_ReturnsInventoryIndexView()
    {
      var result = _controller.Index() as ViewResult;
      Assert.AreEqual("Index", result.ViewName);
    }

    [Test]
    public void Inventory_InventoryCreate_ReturnsInventoryIndexView()
    {
      var viewModel = new InventoryEditModel()
      {
        Inventory = new InventoryDto() { Name = "Test" }
      };

      var result = _controller.Create(viewModel) as RedirectToRouteResult;

      Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
    }

    [Test]
    public void Inventory_InventoryCreate_ReturnsInventoryServiceAdd()
    {
      var viewModel = new InventoryEditModel()
      {
        Inventory = new InventoryDto() { Name = "Test" }
      };

      var result = _controller.Create(viewModel) as RedirectToRouteResult;

      _service.Received().Add(viewModel.Inventory);
    }

    [Test]
    public void Inventory_InventoryEdit_ReturnsInventoryServiceUpdate()
    {
      var viewModel = new InventoryEditModel()
      {
        Inventory = new InventoryDto() { Name = "Test" }
      };

      var result = _controller.Edit(viewModel) as RedirectToRouteResult;

      _service.Received().Update(viewModel.Inventory);
    }

    [Test]
    public void Inventory_InventoryEdit_ReturnsInventoryIndexView()
    {
      var viewModel = new InventoryEditModel()
      {
        Inventory = new InventoryDto() { Name = "Test" }
      };

      var result = _controller.Edit(viewModel) as RedirectToRouteResult;

      Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
    }
  }
}
