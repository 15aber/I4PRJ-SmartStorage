using System.Net;
using System.Web;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.UI.Controllers;

namespace SmartStorage.UT.Controllers
{
    [TestFixture]
    class UnitTest_Stocks
    {
        private StocksController _controller;
        private IStockService _stockService;

        [SetUp]
        public void SetUp()
        {
            _stockService = Substitute.For<IStockService>();
            _controller = new StocksController(_stockService);
        }

        [Test]
        public void Stock_StockIndex1_ReturnsStockIndexView()
        {
            var result = _controller.Index(1) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void Stock_StockIndexNull_ReturnsHttpBadRequest()
        {
            try
            {
                var result = _controller.Index(null) as ViewResult;
            }
            catch (HttpException ex)
            { 
                Assert.AreEqual(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
