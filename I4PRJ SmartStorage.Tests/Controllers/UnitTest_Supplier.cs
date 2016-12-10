using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using NSubstitute;
using NSubstitute.Exceptions;
using NUnit.Framework;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Mapping;
using SmartStorage.BLL.Services;
using SmartStorage.BLL.ViewModels;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using SmartStorage.UI.Controllers;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
    [TestFixture]
    class UnitTest_Supplier
    {
        private SuppliersController _suppliersController;
        private ISupplierService _supplierService;
       
        [SetUp]
        public void SetUp()
        {
            _supplierService = Substitute.For<ISupplierService>();          
            _suppliersController = new SuppliersController(_supplierService);
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());

        }

        [Test]
        public void Supplier_LoadSupplierIndex_ReturnsSupplierIndexView()
        {
            var result = _suppliersController.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void Supplier_SupplierCreate_ReturnsSupplierIndexView()
        {
            var viewModel = new SupplierEditModel()
            {
                Supplier = new SupplierDto() { Name = "Test"}
            };

            var result = _suppliersController.Create(viewModel) as RedirectToRouteResult;

            Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
        }

        [Test]
        public void Supplier_SupplierCreate_ReturnsSupplierServiceAdd()
        {
            var viewModel = new SupplierEditModel()
            {
                Supplier = new SupplierDto() {Name = "Test"}
            };

            var result = _suppliersController.Create(viewModel) as RedirectToRouteResult;

            _supplierService.Received().Add(viewModel.Supplier);
        }

        [Test]
        public void Supplier_SupplierEdit_ReturnsSupplierServiceUpdate()
        {
            var viewModel = new SupplierEditModel()
            {
                Supplier = new SupplierDto() {Name = "Test"}
            };

            var result = _suppliersController.Edit(viewModel) as RedirectToRouteResult;

            _supplierService.Received().Update(viewModel.Supplier);
        }

        [Test]
        public void Supplier_SupplierEdit_ReturnsSupplierIndexView()
        {
            var viewModel = new SupplierEditModel()
            {
                Supplier = new SupplierDto() { Name = "Test" }
            };

            var result = _suppliersController.Edit(viewModel) as RedirectToRouteResult;

            Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
        }
    }
}
