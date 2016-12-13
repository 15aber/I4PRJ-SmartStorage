using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.UnitOfWork;
using SmartStorage.DAL.Interfaces;

namespace SmartStorage.UnitTests.UnitOfWork
{
    [TestFixture]
    class UnitTest_UnitOfWork
    {
        private ApplicationDbContext _context;
        private DAL.UnitOfWork.UnitOfWork _unitOfWork;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<ApplicationDbContext>();
            _unitOfWork = new DAL.UnitOfWork.UnitOfWork(_context);
        }

        [Test]
        public void stuff()
        {
            _unitOfWork.Complete().Returns(_context.SaveChanges());
        }

    }
}
