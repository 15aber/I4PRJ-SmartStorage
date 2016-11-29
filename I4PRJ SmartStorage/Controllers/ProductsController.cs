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
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Products/
        public ActionResult Index(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View("Index");
        }

        // GET: /Products/Create
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                Product = new Product(),
                Categories = db.Categories.Where(c => c.IsDeleted != true).ToList(),
                Suppliers = db.Suppliers.Where(s => s.IsDeleted != true).ToList(),
                Wholesalers = db.Wholesalers.Where(w => w.IsDeleted != true).ToList()
            };

            return View("Create", viewModel);
        }

        // POST: /Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId, Name, PurchasePrice, CategoryId, SupplierId, WholesalerId, LastUpdated, ByUser")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Updated = DateTime.Now;
                product.ByUser = User.Identity.Name;

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Products", action = "Index", Id = product.CategoryId }));
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.IsDeleted != true), "CategoryId", "Name", product.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Suppliers.Where(c => c.IsDeleted != true), "SupplierId", "Name", product.SupplierId);
            ViewBag.WholesalerId = new SelectList(db.Wholesalers.Where(c => c.IsDeleted != true), "WholesalerId", "Name", product.WholesalerId);

            return View(product);
        }

        // GET: /Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new ProductViewModel
            {
                Product = db.Products.Find(id)
            };

            if (viewModel.Product == null)
            {
                return HttpNotFound();
            };
            
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.IsDeleted != true), "CategoryId", "Name", viewModel.Product.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Suppliers.Where(c => c.IsDeleted != true), "SupplierId", "Name", viewModel.Product.SupplierId);
            ViewBag.WholesalerId = new SelectList(db.Wholesalers.Where(c => c.IsDeleted != true), "WholesalerId", "Name", viewModel.Product.WholesalerId);

            return View(viewModel);
        }

        // POST: /Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId, Name, PurchasePrice, CategoryId, SupplierId, WholesalerId, LastUpdated, ByUser")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Updated = DateTime.Now;
                product.ByUser = User.Identity.Name;

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Products", action = "Index", Id = product.CategoryId }));
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.IsDeleted != true), "CategoryId", "Name", product.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Suppliers.Where(c => c.IsDeleted != true), "SupplierId", "Name", product.SupplierId);
            ViewBag.WholesalerId = new SelectList(db.Wholesalers.Where(c => c.IsDeleted != true), "WholesalerId", "Name", product.WholesalerId);

            return View(product);
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