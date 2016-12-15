using Microsoft.Practices.Unity;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces;
using SmartStorage.UI;

namespace UnitTests.UnitOfWork
{
  [TestFixture]
  class UnitOfWorkUnitTest
  {
    private ApplicationDbContext _context;
    private IUnitOfWork _uow;

    [SetUp]
    public void SetUp()
    {
      _context = Substitute.For<ApplicationDbContext>();
      _uow = UnityConfig.GetConfiguredContainer().Resolve<IUnitOfWork>(new DependencyOverride<ApplicationDbContext>(_context));
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
