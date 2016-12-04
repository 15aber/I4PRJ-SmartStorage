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
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Products/
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.Admin))
                return View("Index");
 
            return View("ReadOnlyIndex");
            
        }

        // GET: /Categories/Create
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create()
        {
            var viewModel = new CategoryViewModel
            {
                Category = new Category(),
                Categories = db.Categories.Where(c => c.IsDeleted != true).ToList(),
            };

            return View("Create", viewModel);
        }

        // POST: /Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Updated = DateTime.Now;
                category.ByUser = User.Identity.Name;

                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "Categories", action = "Index" }));
            }

            return View(category);
        }

        // GET: /Categories/Edit/5
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new CategoryViewModel
            {
                Category = db.Categories.Find(id)
            };

            if (viewModel.Category == null)
            {
                return HttpNotFound();
            };

            return View(viewModel);
        }

        // POST: /Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Category.Updated = DateTime.Now;
                viewModel.Category.ByUser = User.Identity.Name;

                db.Entry(viewModel.Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
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