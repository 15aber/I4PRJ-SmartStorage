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
    class UnitTest_TransactionService
    {
        private IUnitOfWork _uow;
        private TransactionService _transactionservice;

        [SetUp]
        public void SetUp()
        {
            _uow = Substitute.For<IUnitOfWork>();
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            _transactionservice = new TransactionService(_uow);
        }

        //[Test]
        //public void transactionserviceAdd_UnitOfWorkAddAndComplete_ReturnsUnitOfWorkAddAndComplete()
        //{
        //    var transactionDto = new TransactionDto() {FromInventoryId = 1, Quantity = 1};
        //    var entity = Mapper.Map<TransactionDto, Transaction> (transactionDto);
        //    _uow.Stocks.GetSingle().Quantity.Returns(1);

        //    _transactionservice.Add(transactionDto);

        //    _uow.Received().Transactions.Add(entity);
        //    _uow.Received().Complete();
        //}

        //[Test]
        //public void transactionserviceUpdate_UnitOfWorkUpdateAndComplete_ReturnsUnitOfWorkUpdateAndComplete()
        //{
        //    var transactionDto = new TransactionDto();
        //    var entity = Mapper.Map<TransactionDto, Transaction>(transactionDto);

        //    _transactionservice.Update(transactionDto);

        //    _uow.Received().Transactions.Update(entity);
        //    _uow.Received().Complete();
        //}
    }
}
