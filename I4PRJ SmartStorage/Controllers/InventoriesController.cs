using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;
using I4PRJ_SmartStorage.ViewModels;

namespace I4PRJ_SmartStorage.Controllers
{
    public class InventoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Inventories/
        public ActionResult Index()
        {
            return View("Index");
        }

        // GET: /Inventories/Create
        public ActionResult Create()
        {
            var viewModel = new InventoryViewModel
            {
                Inventory = new Inventory(),
                Inventories = db.Inventories.Where(c => c.IsDeleted != true).ToList(),
            };

            return View("Create", viewModel);
        }

        // POST: /Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryId, Name, LastUpdated, ByUser")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                inventory.Updated = DateTime.Now;
                inventory.ByUser = User.Identity.Name;

                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Inventories", action = "Index" }));
            }

            return View(inventory);
        }

        // GET: /Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new InventoryViewModel
            {
                Inventory = db.Inventories.Find(id)
            };

            if (viewModel.Inventory == null)
            {
                return HttpNotFound();
            };

            return View(viewModel);
        }

        // POST: /Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryId, Name, LastUpdated, ByUser, Version")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                inventory.Updated = DateTime.Now;
                inventory.ByUser = User.Identity.Name;

                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventory);
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