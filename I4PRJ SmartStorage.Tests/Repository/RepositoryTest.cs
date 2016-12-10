using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using SmartStorage.DAL.Repositories;

namespace I4PRJ_SmartStorage.UnitTests.Repository
{
    [TestFixture]
    class RepositoryTest
    {
        private IRepository<Category> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<IRepository<Category>>();
            _repository.GetAll().Returns(new List<Category>
            {
                new Category()
                {
                    Name = "Beer",
                    ByUser = "Admin",
                    CategoryId = 1,
                    IsDeleted = false,
                    Updated = DateTime.Today
                },

                new Category()
                {
                    Name = "Soft drinks",
                    ByUser = "Admin",
                    CategoryId = 2,
                    IsDeleted = false,
                    Updated = DateTime.Today
                }
            });
        }

        [Test]
        public void GetAll_Returns_TwoCategories()
        {
            Assert.That(_repository.GetAll().Count, Is.EqualTo(2));
        }
    }
}
