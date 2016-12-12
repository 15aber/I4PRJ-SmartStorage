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

    [SetUp]
    public void SetUp()
    {
      _uow = Substitute.For<IUnitOfWork>();
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());
      _inventoryService = new InventoryService(_uow);
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
  }
}
