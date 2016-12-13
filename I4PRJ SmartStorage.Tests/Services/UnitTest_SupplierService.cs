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
  class UnitTest_SupplierService
  {
    private IUnitOfWork _uow;
    private SupplierService _supplierService;
    private List<Supplier> supplierList;

    [SetUp]
    public void SetUp()
    {
      _uow = Substitute.For<IUnitOfWork>();
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());
      _supplierService = new SupplierService(_uow);

      supplierList = new List<Supplier>
      {
          new Supplier()
          {
              ByUser = "Test",
              IsDeleted = false,
              SupplierId = 1,
              Name = "Test",
              Updated = DateTime.Now
          },
           new Supplier()
          {
              ByUser = "Test",
              IsDeleted = true,
              SupplierId = 1,
              Name = "Test",
              Updated = DateTime.Now
          }
      };
    }

    [Test]
    public void SupplierServiceAdd_UnitOfWorkAddAndComplete_ReturnsUnitOfWorkAddAndComplete()
    {
      var supplierDto = new SupplierDto() { Name = "Test" };
      var entity = Mapper.Map<SupplierDto, Supplier>(supplierDto);

      _supplierService.Add(supplierDto);

      _uow.Received().Suppliers.Add(entity);
      _uow.Received().Complete();
    }

    [Test]
    public void SupplierServiceUpdate_UnitOfWorkUpdateAndComplete_ReturnsUnitOfWorkUpdateAndComplete()
    {
      var supplierDto = new SupplierDto() { Name = "Test" };
      var entity = Mapper.Map<SupplierDto, Supplier>(supplierDto);

      _supplierService.Update(supplierDto);

      _uow.Received().Suppliers.Update(entity);
      _uow.Received().Complete();
    }

    [Test]
    public void SuppllierService_GetAll_CountEqualTo2()
    {
        _uow.Suppliers.GetAll().Returns(supplierList);

        Assert.That(_supplierService.GetAll().Count, Is.EqualTo(2));
    }

    [Test]
    public void supplierService_GetAllActive_CountEqualTo1()
    {
        _uow.Suppliers.GetAll(Arg.Any<Expression<Func<Supplier, bool>>>()).Returns(supplierList.Where(e => e.IsDeleted == false).ToList());

        Assert.That(_supplierService.GetAllActive().Count, Is.EqualTo(1));
    }

    [Test]
    public void SupplierService_GetSingle_ReturnsSupplier1()
    {
      var entityDto = Mapper.Map<Supplier, SupplierDto>(supplierList[0]);
      _uow.Suppliers.Get(1).Returns(supplierList[0]);

      Assert.That(_supplierService.GetSingle(1).SupplierId, Is.EqualTo(entityDto.SupplierId));
    }
  }
}
