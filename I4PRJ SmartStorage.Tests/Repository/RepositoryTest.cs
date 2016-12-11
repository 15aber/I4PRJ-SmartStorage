using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.UnitTests.Repository
{
    [TestFixture]
    class RepositoryTest
    {
        private IRepository<Category> _categoryRepository;

        [SetUp]
        public void SetUp()
        {
            _categoryRepository = Substitute.For<IRepository<Category>>();

            _categoryRepository.Get(3).Returns(new Category
            {
                Name = "Vodka",
                ByUser = "Admin",
                CategoryId = 3,
                IsDeleted = false,
                Updated = DateTime.Today
            });

            _categoryRepository.GetAll().Returns(new List<Category>
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
            Assert.That(_categoryRepository.GetAll().Count, Is.EqualTo(2));
        }

        [Test]
        public void GetCertainCategory_Returns_CategoryWithMatchingId()
        {
            Assert.That(_categoryRepository.Get(3).Name, Is.EqualTo("Vodka"));
        }
    }
}
