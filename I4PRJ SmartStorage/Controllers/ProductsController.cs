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
    public class ProductsController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult Index()
    {
        var products = db.Products.Include(p => p.Category).Where(p => p.IsDeleted != true);
        return View(products.ToList());
    }

    // GET: /Products/
    public ActionResult Categories(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        var products = db.Products.Include(s => s.Category).Where(s => s.CategoryId == id);

        if (products == null)
            return HttpNotFound();

        return View("Index", products.ToList());
    }

    // GET: /Products/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Product product = db.Products.Find(id);
        if (product == null)
        {
            return HttpNotFound();
        }
        return View(product);
    }

    // GET: /Products/Create
    public ActionResult Create()
    {
        var viewModel = new ProductViewModel
        {
            Product = new Product(),
            Categories = db.Categories.Where(c => c.IsDeleted == false).ToList()
        };

        return View("Create", viewModel);
    }

    // POST: /Products/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ProductId,Name,PurchasePrice,CategoryId,LastUpdated,ByUser")] Product product)
    {
        if (ModelState.IsValid)
        {
            product.Updated = DateTime.Now;
            product.ByUser = User.Identity.Name;

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
        return View(product);
    }

    // GET: /Products/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Product product = db.Products.Find(id);
        if (product == null)
        {
            return HttpNotFound();
        }
        ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
        return View(product);
    }

    // POST: /Products/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "ProductId,Name,PurchasePrice,CategoryId,LastUpdated,ByUser")] Product product)
    {
        if (ModelState.IsValid)
        {
            product.Updated = DateTime.Now;
            product.ByUser = User.Identity.Name;

            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
        return View(product);
    }

    // GET: /Products/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Product product = db.Products.Find(id);
        if (product == null)
        {
            return HttpNotFound();
        }
        return View(product);
    }

    // POST: /Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Product product = db.Products.Find(id);
        product.IsDeleted = true;
        //db.Products.Remove(product);

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