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
    class UnitTest_Supplier
    {
        private readonly SuppliersController _sup = new SuppliersController();

        [Test]
        public void SupllierIndex_LoadSupplierIndex_ReturnsSupplierIndexView()
        {
            var result = _sup.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }
    }
}
