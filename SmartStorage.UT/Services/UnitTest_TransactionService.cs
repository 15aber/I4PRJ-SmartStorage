using System;
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
    class UnitTest_TransactionService
    {
        private IUnitOfWork _uow;
        private TransactionService _transactionService;
        private List<Transaction> transactionList;
        private List<TransactionDto> transactionDtoList;
        private Inventory inventory;

        [SetUp]
        public void SetUp()
        {
            _uow = Substitute.For<IUnitOfWork>();
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            _transactionService = new TransactionService(_uow);
            inventory = new Inventory()
            {
                ByUser = "Test",
                InventoryId = 1,
                IsDeleted = false,
                Name = "Test",
                Updated = DateTime.Now
            };

            transactionList = new List<Transaction>
            {
                new Transaction()
                {
                    ProductId = 1,
                    FromInventoryId = 1,
                    ToInventoryId = 2,
                    TransactionId = 1,
                    FromInventory = inventory
                },

                new Transaction()
                {
                    ProductId = 1,
                    FromInventoryId = null,
                    ToInventoryId = 1,
                    TransactionId = 2,
                }
            };
        }

        [Test]
        public void TransactionServiceAdd_UnitOfWorkAddAndComplete_ReturnsUnitOfWorkAddAndComplete()
        {
            var transactionDto = new TransactionDto();
            var entity = Mapper.Map<TransactionDto, Transaction>(transactionDto);

            _transactionService.Add(transactionDto);

            _uow.Received().Transactions.Add(entity);
            _uow.Received().Complete();
        }

        [Test]
        public void TransactionServiceUpdate_UnitOfWorkUpdateAndComplete_ReturnsUnitOfWorkUpdateAndComplete()
        {
            var TransactionDto = new TransactionDto();
            var entity = Mapper.Map<TransactionDto, Transaction>(TransactionDto);

            _transactionService.Update(TransactionDto);

            _uow.Received().Transactions.Update(entity);
            _uow.Received().Complete();
        }

        [Test]
        public void TransactionService_GetAllRestock_CountEqualTo1()
        {
            _uow.Transactions.GetAllRestock().Returns(transactionList.Where(e => e.FromInventory == null).ToList());

            Assert.That(_transactionService.GetAllRestock().Count, Is.EqualTo(1));
        }

        [Test]
        public void TransactionService_GetAll_CountEqualTo2()
        {
            _uow.Transactions.GetAll().Returns(transactionList);

            Assert.That(_transactionService.GetAll().Count, Is.EqualTo(2));
        }

        [Test]
        public void TransactionService_GetSingle_ReturnsTransaction1()
        {
            var entityDto = Mapper.Map<Transaction, TransactionDto>(transactionList[0]);
            _uow.Transactions.Get(1).Returns(transactionList[0]);

            Assert.That(_transactionService.GetSingle(1).TransactionId, Is.EqualTo(entityDto.TransactionId));
        }
    }
}
