using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;
using I4PRJ_SmartStorage.ViewModels;

namespace I4PRJ_SmartStorage.Controllers
{
    public class StatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Status/
        public ActionResult Index(int? id)
        {
            var viewModel = new StatusViewModel
            {
                Inventories = db.Inventories.Where(i => !i.IsDeleted).ToList(),
                StatusStartedInventories = new List<int>()
            };

            var InventoryIds = new List<int>();

            foreach (var status in db.Statuses.ToList())
                InventoryIds.Add(db.Inventories.Find(status.InventoryId).InventoryId);

            foreach (var inventory in InventoryIds)
            {
                var status = db.Statuses.Where(i => i.InventoryId == inventory)
                        .OrderByDescending(o => o.Updated).FirstOrDefault();
                
                if(status != null && status.IsStarted)
                    viewModel.StatusStartedInventories.Add(status.InventoryId);
            }

            if (id == 1)
                viewModel.ShowNotification = true;

            return View(viewModel);
        }

        public ActionResult StartStatus(int id)
        {
            Inventory inventory = db.Inventories.Find(id);

            if (inventory == null)
            {
                return HttpNotFound();
            }

            var viewModel = new StatusViewModel
            {
                Products = db.Products.Include(p => p.Category).Where(p => p.IsDeleted != true).ToList(),
                Stocks = db.Stocks.Where(s => s.InventoryId == id).ToList(),
                IsStarted = false
            };

            return View("StatusForm", viewModel);
        }

        public ActionResult FinishStatus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }

            var viewModel = new StatusViewModel
            {
                Products = db.Products.Include(p => p.Category).Where(p => p.IsDeleted != true).ToList(),
                Stocks = db.Stocks.Where(s => s.InventoryId == id).ToList(),
                IsStarted = true
            };

            return View("StatusForm", viewModel);
        }

        public ActionResult StatusReports()
        {
            var statuses = new List<Status>();
            foreach (var status in db.Statuses.ToList())
            {
                if (!statuses.Any(o => o.Updated == status.Updated))
                    statuses.Add(status);
            }

            var viewModel = new StatusViewModel()
            {
                Statuses = statuses,
                Status = new Status()
            };

            return View("StatusReports", viewModel);
        }

        public ActionResult StatusReportDetails(int id)
        {
            Status status = db.Statuses.Find(id);

            if (status == null)
            {
                return HttpNotFound();
            }

            var viewModel = new StatusViewModel
            {
                //Products = db.Products.Include(p => p.Category).Where(p => p.IsDeleted != true).ToList(),
                //Stocks = db.Stocks.Where(s => s.InventoryId == id).ToList(),
                Statuses = db.Statuses.ToList()
            };

            return View("StatusReportDetails", viewModel);
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
