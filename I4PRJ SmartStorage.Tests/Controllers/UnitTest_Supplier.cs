using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NSubstitute;
using NSubstitute.Exceptions;
using NUnit.Framework;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Services;
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

        [SetUp]
        public void SetUp()
        {
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
        public void Supplier_SupplierCreate_ReturnsSupplierIndexView1()
        {
            var result = _suppliersController.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
