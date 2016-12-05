using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using I4PRJ_SmartStorage.UI.Controllers;
using NUnit.Framework;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
    [TestFixture]
    class UnitTestUser
    {
        private readonly UsersController _usr = new UsersController();

        [Test]
        public void UserIndex_LoadUserIndex_ReturnsUserIndexView()
        {
            var result = _usr.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }
    }
}
