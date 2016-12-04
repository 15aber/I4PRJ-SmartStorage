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
    public class WholesalersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Wholesalers/
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Admin))
                return View("Index");

            return View("ReadOnlyIndex");
        }

        // GET: /Wholesalers/Create
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create()
        {
            var viewModel = new WholesalerViewModel()
            {
                Wholesaler = new Wholesaler(),
                Wholesalers = db.Wholesalers.Where(c => c.IsDeleted != true).ToList(),
            };

            return View("Create", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create([Bind(Include = "WholesalerId, Name, Updated, ByUser")] Wholesaler wholesaler)
        {
            if (ModelState.IsValid)
            {
                wholesaler.Updated = DateTime.Now;
                wholesaler.ByUser = User.Identity.Name;

                db.Wholesalers.Add(wholesaler);
                db.SaveChanges();
                return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Wholesalers", action = "Index" }));
            }

            return View(wholesaler);
        }

        public ActionResult CreateNewReport()
        {
            var wholesaler = db.Wholesalers.ToList();

            var viewModel = new WholesalerViewModel()
            {
                Wholesalers = wholesaler
            };

            return View("WholesalersForm",viewModel);
        }

        // GET: /Wholesalers/Edit/5
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new WholesalerViewModel()
            {
                Wholesaler = db.Wholesalers.Find(id)
            };

            if (viewModel.Wholesaler == null)
            {
                return HttpNotFound();
            };

            return View(viewModel);
        }

        // POST: /Wholesalers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit([Bind(Include = "WholesalerId, Name, Updated, ByUser, Version")] Wholesaler wholesaler)
        {
            if (ModelState.IsValid)
            {
                wholesaler.Updated = DateTime.Now;
                wholesaler.ByUser = User.Identity.Name;

                db.Entry(wholesaler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wholesaler);
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
