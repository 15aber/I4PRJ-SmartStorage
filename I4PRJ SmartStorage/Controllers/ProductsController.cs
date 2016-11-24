using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;
using I4PRJ_SmartStorage.ViewModel;

namespace I4PRJ_SmartStorage.Controllers
{
  public class ProductsController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: /Products/
    public ActionResult Index()
    {
      var products = db.Products.Include(p => p.Category).Where(p => p.IsDeleted != true);
      return View(products.ToList());
    }

    public ActionResult Categories(int id)
    {
      if(id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var products = db.Products.Include(p => p.Category).Where(p => p.CategoryId == id);

      if(products == null)
      {
        return HttpNotFound();
      }
      return View("Index", products.ToList());
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
    public ActionResult Create(
        [Bind(Include = "ProductId,Name,PurchasePrice,Package,CategoryId,SupplierId,WholesalerId,Updated,ByUser")] Product product)
    {
      if(ModelState.IsValid)
      {
        product.Updated = DateTime.Now;
        product.ByUser = User.Identity.Name;

        db.Products.Add(product);
        db.SaveChanges();
        return RedirectToAction("Categories", Convert.ToInt32(product.CategoryId));
      }
      return View();
    }

    protected override void Dispose(bool disposing)
    {
      if(disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}