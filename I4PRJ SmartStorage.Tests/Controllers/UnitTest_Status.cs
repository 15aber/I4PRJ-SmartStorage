using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Mapping;
using SmartStorage.UI.Controllers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartStorage.UnitTests.Controllers
{
  [TestFixture]
  class UnitTest_Status
  {
    private StatusController _statusController;
    private IStatusService _statusService;
    private IInventoryService _inventoryService;
    private IProductService _productService;
    private IStockService _stockService;
    private HttpContextBase _contextBase;


    [SetUp]
    public void SetUp()
    {
      _statusService = Substitute.For<IStatusService>();
      _inventoryService = Substitute.For<IInventoryService>();
      _productService = Substitute.For<IProductService>();
      _stockService = Substitute.For<IStockService>();
      _statusController = new StatusController(_statusService, _inventoryService, _productService, _stockService);
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _statusController.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _statusController);

    }

    //[Test]
    //public void Status_LoadStatusIndex_ReturnsStatusIndexView1()
    //{
    //    var result = _statusController.Index(1) as ViewResult;
    //    Assert.AreEqual("Index", result.ViewName);
    //}

    //[Test]
    //public void Status_StatusCreate_ReturnsStatusIndexView()
    //{
    //    var viewModel = new StatusEditModel()
    //    {
    //        Status = new StatusDto() { Name = "Test" }
    //    };

    //    var result = _statusController.Create(viewModel) as RedirectToRouteResult;

    //    Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
    //}

    //[Test]
    //public void Status_StatusCreate_ReturnsStatusServiceAdd()
    //{
    //    var viewModel = new StatusEditModel()
    //    {
    //        Status = new StatusDto() { Name = "Test" }
    //    };

    //    var result = _statusController.Create(viewModel) as RedirectToRouteResult;

    //    _StatusService.Received().Add(viewModel.Status);
    //}

    //[Test]
    //public void Status_StatusEdit_ReturnsStatusServiceUpdate()
    //{
    //    var viewModel = new StatusEditModel()
    //    {
    //        Status = new StatusDto() { Name = "Test" }
    //    };

    //    var result = _statusController.Edit(viewModel) as RedirectToRouteResult;

    //    _StatusService.Received().Update(viewModel.Status);
    //}

    //[Test]
    //public void Status_StatusEdit_ReturnsStatusIndexView()
    //{
    //    var viewModel = new StatusEditModel()
    //    {
    //        Status = new StatusDto() { Name = "Test" }
    //    };

    //    var result = _statusController.Edit(viewModel) as RedirectToRouteResult;

    //    Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
    //}
  }
}
