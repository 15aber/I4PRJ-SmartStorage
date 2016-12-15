using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Mapping;
using SmartStorage.DAL.Models;
using SmartStorage.UI.Controllers;

namespace SmartStorage.UT.Controllers
{
    [TestFixture]
    class UnitTest_Status
    {
        private StatusController _controller;
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
            _controller = new StatusController(_statusService, _inventoryService, _productService,_stockService);
            _contextBase = Substitute.For<HttpContextBase>();
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());

            _contextBase.User.Identity.Name.Returns("JohnDoe");
            _contextBase.Request.IsAuthenticated.Returns(true);
            _contextBase.User.IsInRole("Admin").Returns(true);
            _controller.ControllerContext = new ControllerContext(_contextBase, new RouteData(), _controller);

        }

        [Test]
        public void Status_LoadStatusIndex_ReturnsStatusIndexView()
        {
            var result = _controller.Index(null) as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void Status_StartStatus_ReturnsStatusFormView()
        {
            var inventory = new Inventory() {InventoryId = 1};
            var entityDto = Mapper.Map<Inventory, InventoryDto>(inventory);
            _inventoryService.GetSingle(1).Returns(entityDto);
            var result = _controller.StartStatus(1) as ViewResult;

            Assert.AreEqual("StatusForm", result.ViewName);
        }

        [Test]
        public void Status_FinishStatus_ReturnsStatusFormView()
        {
            var inventory = new Inventory() { InventoryId = 1 };
            var entityDto = Mapper.Map<Inventory, InventoryDto>(inventory);
            _inventoryService.GetSingle(1).Returns(entityDto);
            var result = _controller.FinishStatus(1) as ViewResult;

            Assert.AreEqual("StatusForm", result.ViewName);
        }

        [Test]
        public void Status_StatusReports_ReturnsStatusReportsView()
        {
           var result = _controller.StatusReports() as ViewResult;

           Assert.AreEqual("StatusReports", result.ViewName);
        }

        [Test]
        public void Status_StatusReportsDetails_ReturnsStatusReportsDetailsView()
        {
            var result = _controller.StatusReportDetails(1) as ViewResult;

            Assert.AreEqual("StatusReportDetails", result.ViewName);

            // TODO Controller kode er forkert. Ret test senere.
        }
    }
}
