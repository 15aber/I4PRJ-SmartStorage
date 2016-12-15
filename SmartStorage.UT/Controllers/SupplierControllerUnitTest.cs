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
  class SupplierControllerUnitTest
  {
    private SuppliersController _suppliersController;
    private ISupplierService _supplierService;
    private HttpContextBase _contextBase;


    [SetUp]
    public void SetUp()
    {
      _supplierService = Substitute.For<ISupplierService>();
      _suppliersController = new SuppliersController(_supplierService);
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _suppliersController.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _suppliersController);

    }

    [Test]
    public void Supplier_LoadSupplierIndex_ReturnsSupplierIndexView()
    {
      var result = _suppliersController.Index() as ViewResult;
      Assert.AreEqual("Index", result.ViewName);
    }

    [Test]
    public void Supplier_SupplierCreate_ReturnsSupplierIndexView()
    {
      var viewModel = new SupplierEditModel()
      {
        Supplier = new SupplierDto() { Name = "Test" }
      };

      var result = _suppliersController.Create(viewModel) as RedirectToRouteResult;

      Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
    }

    [Test]
    public void Supplier_SupplierCreate_ReturnsSupplierServiceAdd()
    {
      var viewModel = new SupplierEditModel()
      {
        Supplier = new SupplierDto() { Name = "Test" }
      };

      var result = _suppliersController.Create(viewModel) as RedirectToRouteResult;

      _supplierService.Received().Add(viewModel.Supplier);
    }

    [Test]
    public void Supplier_SupplierEdit_ReturnsSupplierServiceUpdate()
    {
      var viewModel = new SupplierEditModel()
      {
        Supplier = new SupplierDto() { Name = "Test" }
      };

      var result = _suppliersController.Edit(viewModel) as RedirectToRouteResult;

      _supplierService.Received().Update(viewModel.Supplier);
    }

    [Test]
    public void Supplier_SupplierEdit_ReturnsSupplierIndexView()
    {
      var viewModel = new SupplierEditModel()
      {
        Supplier = new SupplierDto() { Name = "Test" }
      };

      var result = _suppliersController.Edit(viewModel) as RedirectToRouteResult;

      Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
    }

    [Test]
    public void Supplier_SupplierReport_ReturnsSupplierFormView()
    {
      var result = _suppliersController.Report() as ViewResult;

      Assert.AreEqual("SupplierForm", result.ViewName);
    }
  }
}
