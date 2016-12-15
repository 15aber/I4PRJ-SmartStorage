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

namespace SmartStorage.UT.Controllers
{
  [TestFixture]
  class UnitTest_Wholesaler
  {
    private WholesalersController _wholesalersController;
    private IWholesalerService _wholesalerService;
    private HttpContextBase _contextBase;


    [SetUp]
    public void SetUp()
    {

      _wholesalerService = Substitute.For<IWholesalerService>();
      _wholesalersController = new WholesalersController(_wholesalerService);
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _wholesalersController.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _wholesalersController);

    }

    [Test]
    public void WholesalerIndex_LoadWholesalerIndex_ReturnsWholesalerIndexView()
    {
      var result = _wholesalersController.Index() as ViewResult;
      Assert.AreEqual("Index", result.ViewName);
    }

    [Test]
    public void Wholesaler_WholesalerCreate_ReturnsWholesalersIndexView()
    {
      var viewModel = new WholesalerEditModel()
      {
        Wholesaler = new WholesalerDto() { Name = "Test" }
      };

      var result = _wholesalersController.Create(viewModel) as RedirectToRouteResult;

      Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
    }

    [Test]
    public void Wholesaler_WholesalerCreate_ReturnsWholesalerServiceAdd()
    {
      var viewModel = new WholesalerEditModel()
      {
        Wholesaler = new WholesalerDto() { Name = "Test" }
      };

      var result = _wholesalersController.Create(viewModel) as RedirectToRouteResult;

      _wholesalerService.Received().Add(viewModel.Wholesaler);
    }

    [Test]
    public void Wholesaler_WholesalerEdit_ReturnsWholesalerServiceUpdate()
    {
      var viewModel = new WholesalerEditModel()
      {
        Wholesaler = new WholesalerDto() { Name = "Test" }
      };

      var result = _wholesalersController.Edit(viewModel) as RedirectToRouteResult;

      _wholesalerService.Received().Update(viewModel.Wholesaler);
    }

    [Test]
    public void Wholesaler_WholesalerEdit_ReturnsWholesalerIndexView()
    {
      var viewModel = new WholesalerEditModel()
      {
        Wholesaler = new WholesalerDto() { Name = "Test" }
      };

      var result = _wholesalersController.Edit(viewModel) as RedirectToRouteResult;

      Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
    }
  }
}
