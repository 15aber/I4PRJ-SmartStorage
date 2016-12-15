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
  class UnitTest_Transactions
  {
    private IInventoryService _inventoryService;
    private IProductService _productService;
    private ITransactionService _transactionService;
    private TransactionsController _controller;
    private HttpContextBase _contextBase;


    [SetUp]
    public void SetUp()
    {
      _inventoryService = Substitute.For<IInventoryService>();
      _productService = Substitute.For<IProductService>();
      _transactionService = Substitute.For<ITransactionService>();
      _controller = new TransactionsController(_transactionService, _inventoryService, _productService);
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());

      _contextBase = Substitute.For<HttpContextBase>();
      _contextBase.User.Identity.Name.Returns("JohnDoe");
      _contextBase.Request.IsAuthenticated.Returns(true);
      _contextBase.User.IsInRole("Admin").Returns(true);
      _controller.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _controller);
    }

    [Test]
    public void TransactionIndex_LoadTransactionIndex_ReturnsTransactionIndexView()
    {
      var result = _controller.Index() as ViewResult;
      Assert.AreEqual("Index", result.ViewName);
    }

    [Test]
    public void Transaction_TransactionCreate_ReturnsTransactionIndexView()
    {
      var viewModel = new TransactionEditModel()
      {
        Transaction = new TransactionDto() { ProductId = 1, ToInventoryId = 1, Quantity = 2, TransactionId = 1 }
      };

      var result = _controller.Create(viewModel) as RedirectToRouteResult;

      Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
    }

    [Test]
    public void Transaction_TransactionCreate_ReturnsTransactionServiceAdd()
    {
      var viewModel = new TransactionEditModel()
      {
        Transaction = new TransactionDto() { ProductId = 1, ToInventoryId = 1, Quantity = 2, TransactionId = 1 }
      };

      var result = _controller.Create(viewModel) as RedirectToRouteResult;

      _transactionService.Received().Add(viewModel.Transaction);
    }
  }
}
