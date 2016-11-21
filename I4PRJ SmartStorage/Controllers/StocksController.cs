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
    public class StocksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Stocks/
        public ActionResult Index()
        {
            var stocks = db.Stocks.Include(s => s.Inventory).Include(s => s.Product);
            return View(stocks.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Inventories(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var viewModel = new StockViewModel
            {
                Stocks = db.Stocks.Include(s => s.Inventory).Include(s => s.Product).Where(s => s.InventoryId == id).ToList(),
                Inventory = db.Inventories.Single(i => i.InventoryId == id)
            };
            
            if (viewModel.Stocks == null)
                return HttpNotFound();

            return View("Index", viewModel);
        }
    }
}
