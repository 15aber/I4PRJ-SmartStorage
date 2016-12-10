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
    class UnitTest_Inventory
    {
        private InventoriesController _controller;
        private IInventoryService _service;

        [SetUp]
        public void SetUp()
        {
            _service = Substitute.For<IInventoryService>();
            _controller = new InventoriesController(_service);
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [Test]
        public void InventoryIndex_LoadInventoryIndex_ReturnsInventoryIndexView()
        {
            var result = _controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void Inventory_InventoryCreate_ReturnsInventoryIndexView()
        {
            var viewModel = new InventoryEditModel()
            {
                Inventory = new InventoryDto() { ByUser = "no-reply@smartstorage.dk", InventoryId = 1, IsDeleted = false, Name = "Test", Updated = DateTime.Now}
            };

            var result = _controller.Create(viewModel) as RedirectToRouteResult;

            Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
        }
    }
}
