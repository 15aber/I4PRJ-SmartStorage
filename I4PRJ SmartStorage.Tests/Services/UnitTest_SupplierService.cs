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
    class UnitTest_SupplierService
    {
        private IUnitOfWork _uow;
        private SupplierService _supplierService;

        [SetUp]
        public void SetUp()
        {
            _uow = Substitute.For<IUnitOfWork>();
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            _supplierService = new SupplierService(_uow);
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
    }
}
