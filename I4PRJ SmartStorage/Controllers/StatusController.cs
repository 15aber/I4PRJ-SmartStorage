﻿using System;
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
    public class StatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Status/
        public ActionResult Index()
        {
            var statusViewModel = new StatusViewModel
            {
                Inventories = db.Inventories.Where(i => !i.IsDeleted).ToList(),
                StatusStartedInventories = new List<int>()
            };

            var statuses = db.Status.ToList();
            foreach (var status in statuses)
            {
                var id = db.Inventories.Find(status.InventoryId);

                if (id != null && status.IsStarted)
                    statusViewModel.StatusStartedInventories.Add(id.InventoryId);
            }

            return View(statusViewModel);
        }

        public ActionResult Save()
        {
            var statusViewModel = new StatusViewModel
            {
                Inventories = db.Inventories.Where(i => !i.IsDeleted).ToList(),
                StatusStartedInventories = new List<int>()
            };

            var statuses = db.Status.ToList();
            foreach (var status in statuses)
            {
                var id = db.Inventories.Find(status.InventoryId);

                if (id != null && status.IsStarted)
                    statusViewModel.StatusStartedInventories.Add(id.InventoryId);
            }

            return View(statusViewModel);
        }

        public ActionResult StartStatus(int? id)
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

            return View("StatusForm");
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

            return View("StatusForm");
        }

        // GET: /Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // GET: /Status/Create
        public ActionResult Create()
        {
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View();
        }

        // POST: /Status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="StatusId,InventoryId,ProductId,Quantity,Difference,DateTime,IsFinished")] Status status)
        {
            if (ModelState.IsValid)
            {
                db.Status.Add(status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "Name", status.InventoryId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", status.ProductId);
            return View(status);
        }

        // GET: /Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "Name", status.InventoryId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", status.ProductId);
            return View(status);
        }

        // POST: /Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StatusId,InventoryId,ProductId,Quantity,Difference,DateTime,IsFinished")] Status status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InventoryId = new SelectList(db.Inventories, "InventoryId", "Name", status.InventoryId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name", status.ProductId);
            return View(status);
        }

        // GET: /Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // POST: /Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Status status = db.Status.Find(id);
            db.Status.Remove(status);
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
