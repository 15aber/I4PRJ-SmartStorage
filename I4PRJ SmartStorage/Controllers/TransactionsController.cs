using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;
using I4PRJ_SmartStorage.ViewModels;

namespace I4PRJ_SmartStorage.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var viewModel = new TransactionViewModel
            {
                Transactions =
                    db.Transactions.Include(t => t.Product)
                        .Include(t => t.FromInventory)
                        .Include(t => t.ToInventory)
                        .ToList()
            };

            return View(viewModel);
        }

        public ActionResult NewRestock()
        {
            var viewModel = new TransactionViewModel
            {
                ToInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList(),
                Products = db.Products.Where(p => p.IsDeleted == false).ToList()
            };

            return View("RestockForm", viewModel);
        }

        public ActionResult NewTransaction()
        {
            var viewModel = new TransactionViewModel
            {
                FromInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList(),
                ToInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList(),
                Products = db.Products.Where(p => p.IsDeleted == false).ToList()
            };

            return View("TransactionForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveRestock(TransactionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.FromInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList();
                viewModel.ToInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList();
                viewModel.Products = db.Products.Where(p => p.IsDeleted == false).ToList();

                return View("RestockForm", viewModel);
            }

            var transaction = new Transaction
            {
                ToInventoryId = viewModel.ToInventoryId,
                ProductId = viewModel.ProductId,
                Quantity = viewModel.Quantity
            };

            var toStockInDb = db.Stocks.Include(s => s.Inventory)
                    .Include(s => s.Product)
                    .Where(s => s.InventoryId == transaction.ToInventoryId)
                    .SingleOrDefault(s => s.ProductId == transaction.ProductId);

            if (toStockInDb == null)
            {
                var toStock = new Stock
                {
                    InventoryId = transaction.ToInventoryId,
                    ProductId = transaction.ProductId,
                    Quantity = transaction.Quantity
                };

                db.Stocks.Add(toStock);
            }

            else
                toStockInDb.Quantity += transaction.Quantity;

            transaction.Updated = DateTime.Now;
            transaction.ByUser = User.Identity.Name;
            db.Transactions.Add(transaction);

            db.SaveChanges();

            return RedirectToAction("Index", "Transactions");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTransaction(TransactionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.FromInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList();
                viewModel.ToInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList();
                viewModel.Products = db.Products.Where(p => p.IsDeleted == false).ToList();

                return View("TransactionForm", viewModel);
            }

            var quantity = db.Stocks.Single(s => s.InventoryId == viewModel.FromInventoryId && s.ProductId == viewModel.ProductId).Quantity;

            if (viewModel.Quantity > quantity)
            {
                ModelState.AddModelError("", "Quantity exceeds the existing quantity: " + quantity + " in stock.");

                viewModel.FromInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList();
                viewModel.ToInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList();
                viewModel.Products = db.Products.Where(p => p.IsDeleted == false).ToList();

                return View("TransactionForm", viewModel);
            }

            var transaction = new Transaction
            {
                FromInventoryId = viewModel.FromInventoryId,
                ToInventoryId = viewModel.ToInventoryId,
                ProductId = viewModel.ProductId,
                Quantity = viewModel.Quantity
            };

            var fromStockInDb = db.Stocks.Include(i => i.Inventory)
                    .Include(p => p.Product)
                    .Where(i => i.InventoryId == transaction.FromInventoryId)
                    .Single(p => p.ProductId == transaction.ProductId);

            if (fromStockInDb == null)
            {
                viewModel.FromInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList();
                viewModel.ToInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList();
                viewModel.Products = db.Products.Where(p => p.IsDeleted == false).ToList();

                return View("TransactionForm", viewModel);
            }

            else
                fromStockInDb.Quantity -= transaction.Quantity;

            var toStockInDb = db.Stocks.Include(s => s.Inventory)
                .Include(s => s.Product)
                .Where(s => s.InventoryId == transaction.ToInventoryId)
                .SingleOrDefault(s => s.ProductId == transaction.ProductId);

            if (toStockInDb == null)
            {
                var toStock = new Stock
                {
                    InventoryId = transaction.ToInventoryId,
                    ProductId = transaction.ProductId,
                    Quantity = transaction.Quantity
                };

                db.Stocks.Add(toStock);
            }

            else
                toStockInDb.Quantity += transaction.Quantity;

            transaction.Updated = DateTime.Now;
            transaction.ByUser = User.Identity.Name;
            db.Transactions.Add(transaction);

            db.SaveChanges();

            return RedirectToAction("Index", "Transactions");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}