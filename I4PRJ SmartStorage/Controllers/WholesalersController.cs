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
using I4PRJ_SmartStorage.ViewModel;

namespace I4PRJ_SmartStorage.Controllers
{
    public class WholesalersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Wholesalers/
        public ActionResult Index()
        {
            return View(db.Wholesalers.Where(w=>w.IsDeleted!=true).ToList());
        }

        // GET: /Wholesalers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wholesaler wholesaler = db.Wholesalers.Find(id);
            if (wholesaler == null)
            {
                return HttpNotFound();
            }
            return View(wholesaler);
        }

        // GET: /Wholesalers/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="WholesalerId,Name,Updated,ByUser,IsDeleted")] Wholesaler wholesaler)
        {
            if (ModelState.IsValid)
            {
                wholesaler.Updated = DateTime.Now;
                wholesaler.ByUser = User.Identity.Name;

                db.Wholesalers.Add(wholesaler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wholesaler);
        }

        public ActionResult CreateNewReport()
        {
            var wholesalers = db.Wholesalers.ToList();

            var viewModel = new WholesalerViewModel
            {
                Wholesalers = wholesalers 
            };

            return View("WholesalersForm",viewModel);
        }

        public ActionResult GetListReport()
        {
            //var id = 1;
            //var wholesaler = db.Wholesalers.Find(id);

            //if (wholesaler == null)
            //{
            //    return HttpNotFound();
            //}


            ////var time = DateTime.Today;
            ////var time1 = DateTime.Today;

            //var viewModel = new WholesalerViewModel
            //{
            //    Transaction = db.Transactions.Include(w => w.Product.WholesalerId == id).ToList()
            //};

            return View(/*"WholesalersForm", viewModel*/);
        }

        // GET: /Wholesalers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wholesaler wholesaler = db.Wholesalers.Find(id);
            if (wholesaler == null)
            {
                return HttpNotFound();
            }
            return View(wholesaler);
        }

        // POST: /Wholesalers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="WholesalerId,Name,Updated,ByUser,IsDeleted")] Wholesaler wholesaler)
        {
            if (ModelState.IsValid)
            {
                wholesaler.ByUser = User.Identity.Name;
                wholesaler.Updated = DateTime.Now;

                db.Entry(wholesaler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wholesaler);
        }

        // GET: /Wholesalers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wholesaler wholesaler = db.Wholesalers.Find(id);
            if (wholesaler == null)
            {
                return HttpNotFound();
            }
            return View(wholesaler);
        }

        // POST: /Wholesalers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wholesaler wholesaler = db.Wholesalers.Find(id);
            db.Wholesalers.Remove(wholesaler);
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
