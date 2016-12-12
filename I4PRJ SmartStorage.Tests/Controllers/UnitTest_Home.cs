using NUnit.Framework;
using NUnit.Framework.Internal;
using SmartStorage.UI.Controllers;
using System.Web.Mvc;


namespace SmartStorage.UnitTests.Controllers
{
  [TestFixture]
  class UnitTest_Home
  {
    private HomeController _homeController;

    [SetUp]
    public void SetUp()
    {
      _homeController = new HomeController();
    }

    [Test]
    public void Home_LoadHomeIndex_ReturnsHomeIndexView()
    {
      var result = _homeController.Index() as RedirectToRouteResult;
      Assert.That(result.RouteValues["Controller"], Is.EqualTo("Transactions"));
      Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
    }
  }
}
