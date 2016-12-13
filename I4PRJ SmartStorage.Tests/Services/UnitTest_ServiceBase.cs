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
    class UnitTest_ServiceBase
    {
        private IUnitOfWork _uow;
        private ServiceBase<TransactionDto> _serviceBase;

        [SetUp]
        public void SetUp()
        {
            const string BAD_INPUT = "bad input";
            _uow = Substitute.For<IUnitOfWork>();
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        //[Test]
        //public void ThrowsExceptionCorrectly()
        //{
        //    _serviceBase.Add(new TransactionDto());
        //    Assert.Fail("No exception was thrown");       
        //}
    }
}
