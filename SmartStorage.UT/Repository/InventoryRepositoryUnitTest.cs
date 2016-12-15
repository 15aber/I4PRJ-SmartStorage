//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using NSubstitute;
//using NUnit.Framework;
//using SmartStorage.DAL.Context;
//using SmartStorage.DAL.Interfaces.Repositories;
//using SmartStorage.DAL.Models;
//using SmartStorage.DAL.Repositories;

//namespace SmartStorage.UnitTests.Repository
//{
//    [TestFixture]
//    class UnitTest_InventoryRepository
//    {
//        private InventoriesRepository _inventoriesRepository;
//        private ApplicationDbContext _context;
//        private List<Inventory> inventoryList;
//        private IQueryable<Inventory> queryInventories;
//        private DbSet<Inventory> _dbSetInventory;

//        [SetUp]
//        public void SetUp()
//        {
//            _context = Substitute.For<ApplicationDbContext>();
//            _inventoriesRepository = new InventoriesRepository(_context);
//            _dbSetInventory = Substitute.For<DbSet<Inventory>>();

//            inventoryList = new List<Inventory>
//            {
//                new Inventory()
//                {
//                    Name = "Beer",
//                    ByUser = "Admin",
//                    InventoryId = 1,
//                    IsDeleted = false,
//                    Updated = DateTime.Today
//                },

//                new Inventory()
//                {
//                    Name = "Soft drinks",
//                    ByUser = "Admin",
//                    InventoryId = 2,
//                    IsDeleted = true,
//                    Updated = DateTime.Today

//                }
//            };
//        }

//        [Test]
//        public void StatusServiceAdd_UnitOfWorkAddAndComplete_ReturnsUnitOfWorkAddAndComplete()
//        {
//            _inventoriesRepository.GetAllActiveInventories();

//            _context.Set<Inventory>().Where(c => c.IsDeleted == false).ToList().Returns(inventoryList);

//            _context.Set<Inventory>().ReceivedWithAnyArgs(1);
//        }
//    }
//}
