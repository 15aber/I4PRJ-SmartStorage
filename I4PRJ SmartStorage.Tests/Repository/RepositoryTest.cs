using NSubstitute;
using NUnit.Framework;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using SmartStorage.DAL.Repositories;

namespace SmartStorage.UnitTests.Repository
{
  [TestFixture]
  class RepositoryTest
  {

    private Repository<CategoriesRepository> repository;
    private DbSet<CategoriesRepository> _dbSet;
    private DbContext _context;
            
    [SetUp]
    public void SetUp()
    {
      repository = new Repository<CategoriesRepository>(_context);
      _dbSet = _context.Set<CategoriesRepository>();
    }

    //[Test]
    //public void Get_Returns_TwoCategories()
    //{
    //    repository.Get(1);
    //    _dbSet.ReceivedWithAnyArgs().Find(1);
    //}
  }
}
