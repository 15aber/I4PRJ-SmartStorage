using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
  class UnitTest_StatusService
  {
    private IUnitOfWork _uow;
    private StatusService _statusService;
    private List<Status> statusList;
    private List<Stock> stockList;
    private List<StatusDto> statusDtoList;

    [SetUp]
    public void SetUp()
    {
      _uow = Substitute.For<IUnitOfWork>();
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());
      _statusService = new StatusService(_uow);

      statusList = new List<Status>
            {
                new Status()
                {
                    ByUser = "Admin",
                    StatusId = 1,
                    Updated = DateTime.Today,
                    InventoryId = 1
                },

                new Status()
                {
                    ByUser = "Admin",
                    StatusId = 2,
                    Updated = DateTime.Today,
                    InventoryId = 2
                }
            };
    }

    [Test]
    public void StatusServiceAdd_UnitOfWorkAddAndComplete_ReturnsUnitOfWorkAddAndComplete()
    {
      var statusDto = new StatusDto();
      var entity = Mapper.Map<StatusDto, Status>(statusDto);

      _statusService.Add(statusDto);

      _uow.Received().Statuses.Add(entity);
      _uow.Received().Complete();
    }

    [Test]
    public void StatusServiceUpdate_UnitOfWorkUpdateAndComplete_ReturnsUnitOfWorkUpdateAndComplete()
    {
      var statusDto = new StatusDto();
      var entity = Mapper.Map<StatusDto, Status>(statusDto);

      _statusService.Update(statusDto);

      _uow.Received().Statuses.Update(entity);
      _uow.Received().Complete();
    }

    [Test]
    public void StatusService_GetAll_CountEqualTo2()
    {
      _uow.Statuses.GetAll().Returns(statusList);

      Assert.That(_statusService.GetAll().Count, Is.EqualTo(2));
    }

    [Test]
    public void StatusService_GetSingle_ReturnsStatus1()
    {
      var entityDto = Mapper.Map<Status, StatusDto>(statusList[0]);
      _uow.Statuses.Get(1).Returns(statusList[0]);

      Assert.That(_statusService.GetSingle(1).StatusId, Is.EqualTo(entityDto.StatusId));
    }

    [Test]
    public void StatusService_GetAllOfInventories1_CountEqualTo1()
    {
      _uow.Statuses.GetAll(Arg.Any<Expression<Func<Status, bool>>>()).Returns(statusList.Where(e => e.InventoryId == 1).ToList());

      Assert.That(_statusService.GetAllOfInventory(1).Count, Is.EqualTo(1));
    }

    [Test]
    public void StatusService_GetUpdated_AddsAndReturnsStatusDto()
    {
      stockList = new List<Stock>
      {
        new Stock()
        {InventoryId = 1} 
      };
      _uow.Stocks.GetAllOfInventory(1).Returns(stockList);

      Assert.That(_statusService.GetUpdated(1).Count, Is.EqualTo(1));
    }

    //[Test]
    //public void StatusService_Create_AddsAndReturnsStatusDto()
    //{
    //  statusDtoList = new List<StatusDto>
    //  {
    //    new StatusDto()
    //    {
    //      InventoryId = 1,
    //      Difference = 1,
    //      ProductId = 1,
    //      Updated = DateTime.Now,
    //      ByUser = "Test"
    //    }
    //  };

    //  stockList = new List<Stock>
    //  {
    //      new Stock()
    //      {
    //          InventoryId = 1,
    //          ProductId = 1,
    //      }
    //  };

    //  var stock = _uow.Stocks.GetSingle(Arg.Any<Expression<Func<Stock, bool>>>(), Arg.Any<Expression<Func<Stock, bool>>>()).Returns((stockList.Where(s => s.InventoryId == statusList[0].InventoryId)), 
    //      (stockList.Where(s => s.ProductId == statusList[0].ProductId))).ToList();

    //  _uow.Stocks.Received().Update(stock);

    //  _statusService.Create(statusDtoList);

    //  _uow.Received().Complete();
    //}
  }
}
