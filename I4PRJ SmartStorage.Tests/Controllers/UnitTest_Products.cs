using System;
using System.Web;
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
    class UnitTest_Products
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IWholesalerService _wholesalerService;
        private ISupplierService _supplierService;
        private ProductsController _controller;

        [SetUp]
        public void SetUp()
        {
            _productService = Substitute.For<IProductService>();
            _categoryService = Substitute.For<ICategoryService>();
            _wholesalerService = Substitute.For<IWholesalerService>();
            _supplierService = Substitute.For<ISupplierService>();
            _controller = new ProductsController(_productService,_categoryService,_supplierService,_wholesalerService);
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }
        [Test]
        public void Product_LoadProductIndex_ReturnsProductIndexView()
        {
            var result = _controller.Index(1) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);            
        }

        [Test]
        public void Product_ProductCreate_ReturnsProductIndexView()
        {
            var viewModel = new ProductEditModel()
            {
                Product = new ProductDto() {SupplierId = 1, Name = "Test", WholesalerId = 1, PurchasePrice = 9.99, CategoryId = 1}
            };

            var result = _controller.Create(viewModel) as RedirectToRouteResult;

            Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
        }

        [Test]
        public void Product_ProductCreate_ReturnsProductServiceAdd()
        {
            var viewModel = new ProductEditModel()
            {
                Product = new ProductDto() { SupplierId = 1, Name = "Test", WholesalerId = 1, PurchasePrice = 9.99, CategoryId = 1 }
            };

            var result = _controller.Create(viewModel) as RedirectToRouteResult;

            _productService.Received().Add(viewModel.Product);
        }

        [Test]
        public void Product_ProductEdit_ReturnsProductServiceUpdate()
        {
            var viewModel = new ProductEditModel()
            {
                Product = new ProductDto() { SupplierId = 1, Name = "Test", WholesalerId = 1, PurchasePrice = 9.99, CategoryId = 1 }
            };

            var result = _controller.Edit(viewModel) as RedirectToRouteResult;

            _productService.Received().Update(viewModel.Product);
        }

        [Test]
        public void Product_ProductEdit_ReturnsProductIndexView()
        {
            var viewModel = new ProductEditModel()
            {
                Product = new ProductDto() { SupplierId = 1, Name = "Test", WholesalerId = 1, PurchasePrice = 9.99, CategoryId = 1 }
            };

            var result = _controller.Edit(viewModel) as RedirectToRouteResult;

            Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
        }
    }
}