using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;
using I4PRJ_SmartStorage.ViewModel;

namespace I4PRJ_SmartStorage.Controllers
{
  public class TransactionsController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult Index()
    {
      var transactions =
          db.Transactions.Include(t => t.Product).Include(t => t.FromInventory).Include(t => t.ToInventory);
      return View(transactions.ToList());
    }

    public ActionResult New()
    {
      var inventoriesInDb = db.Inventories.ToList();
      var productsInDb = db.Products.ToList();

      var viewModel = new TransactionViewModel
      {
        Transaction = new Transaction(),
        FromInventory = inventoriesInDb,
        ToInventory = inventoriesInDb,
        Product = productsInDb
      };

      return View("TransactionsForm", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Transaction transaction)
    {
      if (!ModelState.IsValid)
      {
        var inventoriesInDb = db.Inventories.ToList();
        var productsInDb = db.Products.ToList();

        var viewModel = new TransactionViewModel
        {
          FromInventory = inventoriesInDb,
          ToInventory = inventoriesInDb,
          Product = productsInDb
        };

        return View("TransactionsForm", viewModel);
      }

      var fromStockInDb =
          db.Stocks.Include(s => s.Inventory)
              .Include(s => s.Product)
              .Where(s => s.InventoryId == transaction.FromInventoryId)
              .SingleOrDefault(s => s.ProductId == transaction.ProductId);

      if (fromStockInDb == null)
      {
        var inventoriesInDb = db.Inventories.ToList();
        var productsInDb = db.Products.ToList();

        var viewModel = new TransactionViewModel
        {
          FromInventory = inventoriesInDb,
          ToInventory = inventoriesInDb,
          Product = productsInDb
        };

        return View("TransactionsForm", viewModel);
      }
      else
      {
        fromStockInDb.Quantity -= transaction.Quantity;
      }

      var toStockInDb =
          db.Stocks.Include(s => s.Inventory)
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
      {
        toStockInDb.Quantity += transaction.Quantity;
      }

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