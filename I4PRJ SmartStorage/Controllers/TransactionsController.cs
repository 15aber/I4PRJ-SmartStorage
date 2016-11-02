using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;
using I4PRJ_SmartStorage.ViewModels;

namespace I4PRJ_SmartStorage.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Transactions/
        public ActionResult Index()
        {
            var transactions = db.Transactions.Include(t => t.Product).Include(t => t.FromInventory).Include(t => t.ToInventory);
            return View(transactions.ToList());
        }

        // GET: /Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: /Transactions/Create
        public ActionResult Create()
        {
            //ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            //return View();

            var inventoriesInDb = db.Inventories.ToList();
            var productsInDb = db.Products.ToList();

            var viewModel = new TransactionViewModel
            {
                Transaction = new Transaction(),
                FromInventory = inventoriesInDb,
                ToInventory = inventoriesInDb,
                Products = productsInDb
            };

            return View("TransactionForm", viewModel);
        }

        // POST: /Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionId,FromInventoryId,ToInventoryId,ProductId,Quantity")] Transaction transaction)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Transactions.Add(transaction);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", transaction.ProductId);
            //return View(transaction);

            if (!ModelState.IsValid)
            {
                var inventoriesInDb = db.Inventories.ToList();
                var productsInDb = db.Products.ToList();

                var viewModel = new TransactionViewModel
                {
                    FromInventory = inventoriesInDb,
                    ToInventory = inventoriesInDb,
                    Products = productsInDb,
                    Quantity = transaction.Quantity
                };

                return View("TransactionForm", viewModel);
            }
            /*
            var fromStockInDb =
                db.Stocks.Include(s => s.Inventory).Include(s => s.Product).Where(s => s.InventoryId == transaction.ToInventoryId)
                    .SingleOrDefault(s => s.ProductId == transaction.ProductId);
            fromStockInDb.Quantity -= transaction.Quantity;

            var toStockInDb =
                db.Stocks.Include(s => s.Inventory).Include(s => s.Product).Where(s => s.InventoryId == transaction.FromInventoryId)
                    .SingleOrDefault(s => s.ProductId == transaction.ProductId);
            toStockInDb.Quantity += transaction.Quantity;
            ¨*/

            transaction.DateTime = DateTime.Now;
            transaction.ByUser = User.Identity.Name;

            db.Transactions.Add(transaction);

            db.SaveChanges();

            return RedirectToAction("Index", "Transactions");
        }

        // GET: /Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", transaction.ProductId);
            return View(transaction);
        }

        // POST: /Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionId,FromInventoryId,ToInventoryId,ProductId,Quantity")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", transaction.ProductId);
            return View(transaction);
        }

        // GET: /Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: /Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
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
