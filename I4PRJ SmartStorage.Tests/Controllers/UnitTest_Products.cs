using System.Web;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using SmartStorage.UI.Controllers;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
    class UnitTest_Products
    {
        private IRepository<Product> _repository;
        private IUnitOfWork _unitOfWork;
        private ProductsController _controller;

        [SetUp]
        public void SetUp()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _repository = Substitute.For<IRepository<Product>>();
            //_controller = new ProductsController(_unitOfWork);
        }
        [TestFixture]
        public class ProductControllerTest
        {
            //var result = _controller.Index() as ViewResult;
            //Assert.AreEqual("Index", result.ViewName);            
        }
    }
}