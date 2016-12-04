using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using I4PRJ_SmartStorage.Controllers;
using System.Web.Mvc;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;
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
                var usr = Substitute.For<AccountController>();
                _context.User.Identity.Name.Returns("victorbusk@gmail.com");
                _context.User.Identity.IsAuthenticated.Returns(true);
                _context.User.IsInRole(RoleName.Admin);

                var result = _pro.Index(1) as ViewResult;
                Assert.AreEqual("Index", result.ViewName);

            }

            [Test]
            public void ProductCreate_CreateView_ReturnsProductCreateView()
            {

                //_context.User.Identity.Name.Returns("victorbusk@gmail.com");
                //_context.User.Identity.IsAuthenticated.Returns(true);
                //_context.User.IsInRole(RoleName.Admin);
                //var result = _pro.Create() as ViewResult;
                //Assert.AreEqual("Create", result.ViewName);

                //var product = new List<Product>
                //{
                //    new Product {ProductId = 1, Answer = "Home", Question = "Where Do you Live?"}
                //};
                //var faqRepository = new Mock<IFaqRepository>();
                //faqRepository.Setup(e => e.GetAll()).Returns(faqs.AsQueryable());
                //var controller = new FaqController(faqRepository.Object);
                //// Act 
                //var result = controller.Index() as ViewResult;
                //var model = result.Model as FaqViewModel;
                //// Assert
                //Assert.IsNotNull(result);
                //Assert.AreEqual(3, model.FAQs.Count());

            }

        }
    }
}
