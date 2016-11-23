using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http.Results;
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

        public ActionResult New(TransactionViewModel viewModel)
        {
            if (viewModel.IsChecked)
            {
                viewModel.Transaction = new Transaction();
                viewModel.ToInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList();
                viewModel.Products = db.Products.Where(p => p.IsDeleted == false).ToList();

                return View("RestockForm", viewModel);
            }
            else
            {
                viewModel.Transaction = new Transaction();
                viewModel.FromInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList();
                viewModel.ToInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList();
                viewModel.Products = db.Products.Where(p => p.IsDeleted == false).ToList();

                return View("TransactionForm", viewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveRestock(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TransactionViewModel
                {
                    ToInventory = db.Inventories.Where(p => p.IsDeleted == false).ToList(),
                    Products = db.Products.Where(p => p.IsDeleted == false).ToList()
                };

                return View("RestockForm", viewModel);
            }

            var toStockInDb = db.Stocks.Include(s => s.Inventory)
                    .Include(s => s.Product)
                    .Where(s => s.InventoryId == transaction.ToInventoryId)
                    .Single(s => s.ProductId == transaction.ProductId);

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

            transaction.DateTime = DateTime.Now;
            transaction.ByUser = User.Identity.Name;
            db.Transactions.Add(transaction);

            db.SaveChanges();

            return RedirectToAction("Index", "Transactions");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                var inventoriesInDb = db.Inventories.Where(p => p.IsDeleted == false).ToList();
                var productsInDb = db.Products.Where(p => p.IsDeleted == false).ToList();

                var viewModel = new TransactionViewModel
                {
                    FromInventory = inventoriesInDb,
                    ToInventory = inventoriesInDb,
                    Products = productsInDb
                };

                return View("TransactionForm", viewModel);
            }

            var fromStockInDb = db.Stocks.Include(i => i.Inventory)
                    .Include(p => p.Product)
                    .Where(i => i.InventoryId == transaction.FromInventoryId)
                    .Single(p => p.ProductId == transaction.ProductId);

            if (fromStockInDb == null)
            {
                var inventoriesInDb = db.Inventories.ToList();
                var productsInDb = db.Products.ToList();

                var viewModel = new TransactionViewModel
                {
                    FromInventory = inventoriesInDb,
                    ToInventory = inventoriesInDb,
                    Products = productsInDb
                };

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

            transaction.DateTime = DateTime.Now;
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