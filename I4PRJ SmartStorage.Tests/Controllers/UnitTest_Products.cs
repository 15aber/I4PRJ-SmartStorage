using System.Web;
using I4PRJ_SmartStorage.Controllers;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
    class UnitTest_Products
    {
        [TestFixture]
        public class ProductControllerTest
        {
            private HttpContextBase _context;
            private HttpContext _httpContext;
            private readonly ProductsController _pro = new ProductsController();

            [SetUp]
            public void SetUp()
            {
                _context = Substitute.For<HttpContextBase>();

            }

            [Test]
            public void ProductsIndex_LoadProductIndex1_ReturnsProductIndexView1()
            {
                var result = _pro.Index(1) as ViewResult;
                Assert.AreEqual("Index", result.ViewName);

            }

            [Test]
            public void ProductCreate_CreateView_ReturnsProductCreateView()
            {

                

            }


        }
    }
}