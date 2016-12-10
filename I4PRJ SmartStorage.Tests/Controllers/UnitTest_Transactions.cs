using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using SmartStorage.UI.Controllers;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
    [TestFixture]
    class UnitTest_Transactions
    {
        private IRepository<Product> _repository;
        private IUnitOfWork _unitOfWork;
        private ProductsController _controller;
        private IProductService _service;

        [SetUp]
        public void SetUp()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _repository = Substitute.For<IRepository<Product>>();
            //_controller = new ProductsController(_service);
        }

        [Test]
        public void TransactionIndex_LoadTransactionIndex_ReturnsTransactionIndexView()
        {
            //var result = _tran.Index() as ViewResult;
            //Assert.AreEqual("Index", result.ViewName);

        }
    }
}
