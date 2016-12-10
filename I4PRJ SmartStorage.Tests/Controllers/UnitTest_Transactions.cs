using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Mapping;
using SmartStorage.BLL.ViewModels;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using SmartStorage.UI.Controllers;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
    [TestFixture]
    class UnitTest_Transactions
    {
        private IInventoryService _inventoryService;
        private IProductService _productService;
        private ITransactionService _transactionService;
        private TransactionsController _controller;

        [SetUp]
        public void SetUp()
        {
            _inventoryService = Substitute.For<IInventoryService>();
            _productService = Substitute.For<IProductService>();
            _transactionService = Substitute.For<ITransactionService>();
            _controller = new TransactionsController(_transactionService,_inventoryService,_productService);
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [Test]
        public void TransactionIndex_LoadTransactionIndex_ReturnsTransactionIndexView()
        {
            var result = _controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void Transaction_TransactionCreate_ReturnsTransactionIndexView()
        {
            var viewModel = new TransactionEditModel()
            {
                Transaction = new TransactionDto() { ProductId = 1, ToInventoryId = 1, Quantity = 2, TransactionId = 1}
            };

            var result = _controller.Create(viewModel) as RedirectToRouteResult;

            Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
        }

        [Test]
        public void Transaction_TransactionCreate_ReturnsTransactionServiceAdd()
        {
            var viewModel = new TransactionEditModel()
            {
                Transaction = new TransactionDto() { ProductId = 1, ToInventoryId = 1, Quantity = 2, TransactionId = 1 }
            };

            var result = _controller.Create(viewModel) as RedirectToRouteResult;

            _transactionService.Received().Add(viewModel.Transaction);
        }
    }
}
