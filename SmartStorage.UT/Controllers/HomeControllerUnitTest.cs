using System.Web.Mvc;
using NUnit.Framework;
using SmartStorage.UI.Controllers;

namespace UnitTests.Controllers
{
  [TestFixture]
  class HomeControllerUnitTest
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
