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

namespace SmartStorage.UnitTests.Services
{
  [TestFixture]
  class UnitTest_InventoryService
  {
    private IUnitOfWork _uow;
    private InventoryService _inventoryService;
    private List<Inventory> inventoryList;

    [SetUp]
    public void SetUp()
    {
      _uow = Substitute.For<IUnitOfWork>();
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());
      _inventoryService = new InventoryService(_uow);

      inventoryList = new List<Inventory>
      {
          new Inventory()
          {
              ByUser = "Test",
              IsDeleted = false,
              InventoryId = 1,
              Name = "Test",
              Updated = DateTime.Now
          },
           new Inventory()
          {
              ByUser = "Test",
              IsDeleted = true,
              InventoryId = 1,
              Name = "Test",
              Updated = DateTime.Now
          }
      };
    }

    [Test]
    public void InventoryServiceAdd_UnitOfWorkAddAndComplete_ReturnsUnitOfWorkAddAndComplete()
    {
      var inventoryDto = new InventoryDto() { Name = "Test" };
      var entity = Mapper.Map<InventoryDto, Inventory>(inventoryDto);

      _inventoryService.Add(inventoryDto);

      _uow.Received().Inventories.Add(entity);
      _uow.Received().Complete();
    }

    [Test]
    public void InventoryServiceUpdate_UnitOfWorkUpdateAndComplete_ReturnsUnitOfWorkUpdateAndComplete()
    {
      var inventoryDto = new InventoryDto() { Name = "Test" };
      var entity = Mapper.Map<InventoryDto, Inventory>(inventoryDto);

      _inventoryService.Update(inventoryDto);

      _uow.Received().Inventories.Update(entity);
      _uow.Received().Complete();
    }

    [Test]
    public void InventoryService_GetAll_CountEqualTo2()
    {
        _uow.Inventories.GetAll().Returns(inventoryList);

        Assert.That(_inventoryService.GetAll().Count, Is.EqualTo(2));
    }

    [Test]
    public void InventoryService_GetAllActive_CountEqualTo1()
    {
      _uow.Inventories.GetAll(Arg.Any<Expression<Func<Inventory, bool>>>()).Returns(inventoryList.Where(e => e.IsDeleted == false).ToList());

      Assert.That(_inventoryService.GetAllActive().Count, Is.EqualTo(1));
    }

    [Test]
    public void InventoryService_GetSingle_ReturnsInventory1()
    {
      var entityDto = Mapper.Map<Inventory, InventoryDto>(inventoryList[0]);
      _uow.Inventories.Get(1).Returns(inventoryList[0]);

      Assert.That(_inventoryService.GetSingle(1).InventoryId, Is.EqualTo(entityDto.InventoryId));
    }
  }
}
