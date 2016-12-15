using NSubstitute;
using NUnit.Framework;
using SmartStorage.DAL.Context;

namespace UnitTests.UnitOfWork
{
  [TestFixture]
  class UnitOfWorkUnitTest
  {
    private ApplicationDbContext _context;
    private SmartStorage.DAL.UnitOfWork.UnitOfWork _uow;

    [SetUp]
    public void SetUp()
    {
      _context = Substitute.For<ApplicationDbContext>();
      _uow = new SmartStorage.DAL.UnitOfWork.UnitOfWork(_context);
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
