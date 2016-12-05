using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using I4PRJ_SmartStorage.Controllers;
using NUnit.Framework;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
    [TestFixture]
    class UnitTest_Inventory
    {
        private readonly InventoriesController _inv = new InventoriesController();

        [Test]
        public void InventoryIndex_LoadInventoryIndex_ReturnsInventoryIndexView()
        {
            var result = _inv.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }
    }
}
