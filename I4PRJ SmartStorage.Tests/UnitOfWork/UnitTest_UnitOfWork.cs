using NSubstitute;
using NUnit.Framework;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.UnitOfWork;

namespace SmartStorage.UnitTests.UnitOfWork
{
  [TestFixture]
  class UnitTest_UnitOfWork
  {
    private ApplicationDbContext _context;
    private DAL.UnitOfWork.UnitOfWork _uow;

    [SetUp]
    public void SetUp()
    {
      _context = Substitute.For<ApplicationDbContext>();
      _uow = new DAL.UnitOfWork.UnitOfWork(_context);
    }

    [Test]
    public void UnitOfWork_CompleteCalled_ReceivedSaveChanges()
    {
      _uow.Complete();
      _context.Received().SaveChanges();
    }

    [Test]
    public void UnitOfWork_DisposeCalled_ReceivedDispose()
    {
      _uow.Dispose();
      _context.Received().Dispose();
    }

  }
}
