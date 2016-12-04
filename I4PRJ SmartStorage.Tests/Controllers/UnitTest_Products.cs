using System;
using I4PRJ_SmartStorage.Controllers;
using NSubstitute;
using NUnit.Framework;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
  class UnitTest_Products
  {
    [TestFixture]
    public class ProductControllerTest
    {
      private UsersController _usr;
      private HomeController _uut;

      [SetUp]
      public void SetUp()
      {
        _usr = Substitute.For<UsersController>();
      }

      [Test]
      public void TestIndexView()
      {
        //var userController = new UsersController();
        //_usr.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("SOMEUSER");
        //mock.SetupGet(x => x.HttpContext.Request.IsAuthenticated).Returns(true);
        //userController.ControllerContext = mock.Object;

        //var controller = new ProductsController();
        //var result = controller.Index(1) as ViewResult;
        //Assert.AreEqual("ReadOnlyIndex", result.ViewName);

      }
        
    }
  }
}
