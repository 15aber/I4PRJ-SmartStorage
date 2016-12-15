using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Mapping;
using SmartStorage.BLL.Services;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Models;

namespace SmartStorage.UT.Services
{
    [TestFixture]
    class UnitTest_StockService
    {
        private IUnitOfWork _uow;
        private StockService _stockService;
        private List<Stock> stockList;
        private List<StockDto> stockDtoList;

        [SetUp]
        public void SetUp()
        {
            _uow = Substitute.For<IUnitOfWork>();
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            _stockService = new StockService(_uow);

            stockList = new List<Stock>
            {
                new Stock()
                {
                    InventoryId = 1,
                    ProductId = 1
                },

                new Stock()
                {
                    InventoryId = 2,
                    ProductId = 2
                }
            };
        }

        [Test]
        public void StockServiceAdd_UnitOfWorkAddAndComplete_ReturnsUnitOfWorkAddAndComplete()
        {
            var stockDto = new StockDto();
            var entity = Mapper.Map<StockDto, Stock>(stockDto);

            _stockService.Add(stockDto);

            _uow.Received().Stocks.Add(entity);
            _uow.Received().Complete();
        }

        [Test]
        public void StockServiceUpdate_UnitOfWorkUpdateAndComplete_ReturnsUnitOfWorkUpdateAndComplete()
        {
            var stockDto = new StockDto();
            var entity = Mapper.Map<StockDto, Stock>(stockDto);

            _stockService.Update(stockDto);

            _uow.Received().Stocks.Update(entity);
            _uow.Received().Complete();
        }

        [Test]
        public void StockService_GetAllOfInventories1_CountEqualTo1()
        {
            _uow.Stocks.GetAllOfInventory(1).Returns(stockList.Where(e => e.InventoryId == 1).ToList());

            Assert.That(_stockService.GetAllOfInventory(1).Count, Is.EqualTo(1));
        }

        [Test]
        public void StockService_GetAll_CountEqualTo2()
        {
            _uow.Stocks.GetAll().Returns(stockList);

            Assert.That(_stockService.GetAll().Count, Is.EqualTo(2));
        }

        [Test]
        public void StockService_GetSingle_ReturnsStock1()
        {
            var entityDto = Mapper.Map<Stock, StockDto>(stockList[0]);
            _uow.Stocks.Get(1).Returns(stockList[0]);

            Assert.That(_stockService.GetSingle(1).InventoryId, Is.EqualTo(entityDto.InventoryId));
        }
    }
}
