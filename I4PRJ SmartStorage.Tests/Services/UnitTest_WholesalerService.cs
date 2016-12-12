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
  class UnitTest_WholesalerService
  {
    private IUnitOfWork _uow;
    private WholesalerService _wholesalerService;

    [SetUp]
    public void SetUp()
    {
      _uow = Substitute.For<IUnitOfWork>();
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());
      _wholesalerService = new WholesalerService(_uow);
    }

    [Test]
    public void WholesalerServiceAdd_UnitOfWorkAddAndComplete_ReturnsUnitOfWorkAddAndComplete()
    {
      var wholesalerDto = new WholesalerDto() { Name = "Test" };
      var entity = Mapper.Map<WholesalerDto, Wholesaler>(wholesalerDto);

      _wholesalerService.Add(wholesalerDto);

      _uow.Received().Wholesalers.Add(entity);
      _uow.Received().Complete();
    }

    [Test]
    public void WholesalerServiceUpdate_UnitOfWorkUpdateAndComplete_ReturnsUnitOfWorkUpdateAndComplete()
    {
      var wholesalerDto = new WholesalerDto() { Name = "Test" };
      var entity = Mapper.Map<WholesalerDto, Wholesaler>(wholesalerDto);

      _wholesalerService.Update(wholesalerDto);

      _uow.Received().Wholesalers.Update(entity);
      _uow.Received().Complete();
    }
  }
}
