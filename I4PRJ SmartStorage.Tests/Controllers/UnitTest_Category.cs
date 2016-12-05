using System.Web;
using I4PRJ_SmartStorage.Controllers;
using System.Web.Mvc;
using I4PRJ_SmartStorage.Models.Domain;
using NSubstitute;
using NUnit.Framework;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
    [TestFixture]
    class UnitTest_Category
    {
        private readonly CategoriesController _cat = new CategoriesController();

        [Test]
        public void CategoryIndex_LoadCategoryIndex_ReturnsCategoryIndexView()
        {
            var result = _cat.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }
    }
}
