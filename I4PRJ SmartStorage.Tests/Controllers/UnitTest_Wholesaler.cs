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
using SmartStorage.UI.Controllers;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
    [TestFixture]
    class UnitTest_Wholesaler
    {
        private WholesalersController _wholesalersController;
        private IWholesalerService _wholesalerService;

        [SetUp]
        public void SetUp()
        {
            _wholesalerService = Substitute.For<IWholesalerService>();
            _wholesalersController = new WholesalersController(_wholesalerService);
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [Test]
        public void WholesalerIndex_LoadWholesalerIndex_ReturnsWholesalerIndexView()
        {
            var result = _wholesalersController.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void Supplier_SupplierCreate_ReturnsSupplierIndexView()
        {
            var viewModel = new WholesalerEditModel()
            {
                Wholesaler = new WholesalerDto() { ByUser = "no-reply@smartstorage.dk", WholesalerId = 1, IsDeleted = false, Name = "Test", Updated = DateTime.Now }
            };

            var result = _wholesalersController.Create(viewModel) as RedirectToRouteResult;

            Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
        }
    }
}
