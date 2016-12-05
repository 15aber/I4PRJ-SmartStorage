using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using I4PRJ_SmartStorage.BLL.ViewModels;
using I4PRJ_SmartStorage.Identity;
using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace I4PRJ_SmartStorage.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    public ActionResult Index()
    {
      return View(User.IsInRole(UserRolesName.Admin) ? "Index" : "ReadOnlyIndex");
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create()
    {
      return View("Create");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
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
    [Authorize(Roles = UserRolesName.Admin)]
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
    [Authorize(Roles = UserRolesName.Admin)]
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