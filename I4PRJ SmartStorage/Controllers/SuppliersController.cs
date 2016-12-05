using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;
using I4PRJ_SmartStorage.ViewModels;

namespace I4PRJ_SmartStorage.Controllers
{
    public class SuppliersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Suppliers/
        public ActionResult Index()
        {
            if (User.IsInRole(UserRolesName.Admin))
                return View("Index");

            return View("ReadOnlyIndex");
        }

        // GET: /Suppliers/Create
        [Authorize(Roles = UserRolesName.Admin)]
        public ActionResult Create()
        {
            var viewModel = new SupplierViewModel()
            {
                Supplier = new Supplier(),
                Suppliers = db.Suppliers.Where(c => c.IsDeleted != true).ToList(),
            };

            return View("Create", viewModel);
        }

        // POST: /Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRolesName.Admin)]
        public ActionResult Create([Bind(Include="SupplierId,Name,Updated,ByUser,IsDeleted")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.Updated = DateTime.Now;
                supplier.ByUser = User.Identity.Name;

                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Suppliers", action = "Index" }));
            }

            return View(supplier);
        }


        public ActionResult CreateNewReport()
        {
            var supplier = db.Suppliers.ToList();

            var viewModel = new SupplierViewModel()
            {
                Suppliers = supplier
            };

            return View("SupplierForm", viewModel);
        }

        // GET: /Suppliers/Edit/5
        [Authorize(Roles = UserRolesName.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new SupplierViewModel()
            {
                Supplier = db.Suppliers.Find(id)
            };

            if (viewModel.Supplier == null)
            {
                return HttpNotFound();
            };

            return View(viewModel);
        }

        // POST: /Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRolesName.Admin)]
        public ActionResult Edit([Bind(Include="SupplierId,Name,Updated,ByUser,IsDeleted")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.Updated = DateTime.Now;
                supplier.ByUser = User.Identity.Name;

                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
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
