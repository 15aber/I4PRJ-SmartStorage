using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Mapping;
using SmartStorage.BLL.Services;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.UnitTests.Services
{
    [TestFixture]
    class UnitTest_ProductService
    {
        private IUnitOfWork _uow;
        private ProductService _productService;

        [SetUp]
        public void SetUp()
        {
            _uow = Substitute.For<IUnitOfWork>();
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            _productService = new ProductService(_uow);
        }

        [Test]
        public void ProductServiceAdd_UnitOfWorkAddAndComplete_ReturnsUnitOfWorkAddAndComplete()
        {
            var productDto = new ProductDto() { Name = "Test" };
            var entity = Mapper.Map<ProductDto, Product>(productDto);

            _productService.Add(productDto);

            _uow.Received().Products.Add(entity);
            _uow.Received().Complete();
        }

        [Test]
        public void ProductServiceUpdate_UnitOfWorkUpdateAndComplete_ReturnsUnitOfWorkUpdateAndComplete()
        {
            var productDto = new ProductDto() { Name = "Test" };
            var entity = Mapper.Map<ProductDto, Product>(productDto);

            _productService.Update(productDto);

            _uow.Received().Products.Update(entity);
            _uow.Received().Complete();
        }
    }
}
