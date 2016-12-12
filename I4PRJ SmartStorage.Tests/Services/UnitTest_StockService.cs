//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using NSubstitute;
//using NUnit.Framework;
//using SmartStorage.BLL.Dtos;
//using SmartStorage.BLL.Mapping;
//using SmartStorage.BLL.Services;
//using SmartStorage.DAL.Interfaces;
//using SmartStorage.DAL.Models;

//namespace SmartStorage.UnitTests.Services
//{
//    [TestFixture]
//    class UnitTest_StockService
//    {
//        private IUnitOfWork _uow;
//        private StockService _stockService;

//        [SetUp]
//        public void SetUp()
//        {
//            _uow = Substitute.For<IUnitOfWork>();
//            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
//            _stockService = new StockService(_uow);
//        }

//        [Test]
//        public void StockServiceAdd_UnitOfWorkAddAndComplete_ReturnsUnitOfWorkAddAndComplete()
//        {
//            var stockDto = new StockDto() { };
//            var entity = Mapper.Map<CategoryDto, Category>(categoryDto);

//            _categoryService.Add(categoryDto);

//            _uow.Received().Categories.Add(entity);
//            _uow.Received().Complete();
//        }

//        [Test]
//        public void CategoryServiceUpdate_UnitOfWorkUpdateAndComplete_ReturnsUnitOfWorkUpdateAndComplete()
//        {
//            var categoryDto = new CategoryDto() { Name = "Test" };
//            var entity = Mapper.Map<CategoryDto, Category>(categoryDto);

//            _categoryService.Update(categoryDto);

//            _uow.Received().Categories.Update(entity);
//            _uow.Received().Complete();
//        }
//    }
//}
