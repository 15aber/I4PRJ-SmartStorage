using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using NSubstitute;
using SmartStorage.BLL.Interfaces.Services;
using NUnit.Framework;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.ViewModels;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using SmartStorage.UI.Controllers;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SmartStorage.BLL.Mapping;
using SmartStorage.UI;

namespace I4PRJ_SmartStorage.UnitTests.Controllers
{
    [TestFixture]
    class UnitTest_Category
    {
        private CategoriesController _controller;
        private ICategoryService _service;

        [SetUp]
        public void SetUp()
        {
            _controller = new CategoriesController(_service);
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [Test]
        public void Category_LoadCategoryIndex_ReturnsCategoryIndexView()
        {
            var result = _controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void Category_CategoryCreate_ReturnsCategoryIndexView()
        {

            var viewModel = new CategoryEditModel
            {
                Category = new CategoryDto() { ByUser = "no-reply@smartstorage.dk", CategoryId = 1,IsDeleted = false, Name = "Test", Updated = DateTime.Now}
            };

            var result = _controller.Create(viewModel) as RedirectToRouteResult;

            Assert.That(result.RouteValues["Action"], Is.EqualTo("Index"));
        }
    }
}
