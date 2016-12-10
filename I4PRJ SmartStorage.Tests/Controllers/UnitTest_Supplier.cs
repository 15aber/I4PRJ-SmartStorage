using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NSubstitute;
using NSubstitute.Exceptions;
using NUnit.Framework;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
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
        private IRepository<Supplier> _repository;
        private IUnitOfWork _unitOfWork;
        private SuppliersController _suppliersController;
        private ISupplierService _supplierService;
        private SupplierEditModel _viewModel;
       

        [SetUp]
        public void SetUp()
        {
            _viewModel = Substitute.For<SupplierEditModel>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _repository = Substitute.For<IRepository<Supplier>>();
            _supplierService = Substitute.For<ISupplierService>();          
            _suppliersController = new SuppliersController(_supplierService);

        }

        [Test]
        public void Supplier_LoadSupplierIndex_ReturnsSupplierIndexView()
        {
            var result = _suppliersController.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void crap()
        {

            var viewModel = new SupplierEditModel
            {
                Supplier = new SupplierDto() { ByUser = "Test", IsDeleted = false, Name = "TestSupplier", SupplierId = 0, Updated = DateTime.Today }
            };

            var result = _suppliersController.Create(viewModel) as ViewResult;

            _supplierService.Add(viewModel.Supplier);

            Assert.AreEqual("Index", result.ViewName);


        }

        //[Test]
        //public void Supplier_SupplierCreate_ReturnsSupplierIndexView1()
        //{
        //    var viewModel = new SupplierEditModel()
        //    {
        //        Supplier = new SupplierDto() { ByUser = "no-reply@smartstorage.dk", SupplierId = 0, IsDeleted = false, Name = "Test", Updated = DateTime.Now }
        //    };
        //    var result = _suppliersController.Create(viewModel) as ViewResult;
        //    Assert.AreEqual("Index", result.ViewName);
        //}
    }
}
