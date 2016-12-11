using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Mapping;
using SmartStorage.UI.Controllers;


namespace I4PRJ_SmartStorage.UnitTests.Controllers
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
            Assert.That(result.RouteValues["Controller"],Is.EqualTo("Transactions"));
            Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
        }
    }
}
