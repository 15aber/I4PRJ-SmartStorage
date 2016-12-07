using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.ViewModels;
using SmartStorage.BLL.ViewModels.Identity;
using System;
using System.Net;
using System.Web.Mvc;

namespace SmartStorage.UI.Controllers
{
  public class ProductsController : Controller
  {
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly ISupplierService _supplierService;
    private readonly IWholesalerService _wholesalerService;

    public ProductsController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService, IWholesalerService wholesalerService)
    {
      _productService = productService;
      _categoryService = categoryService;
      _supplierService = supplierService;
      _wholesalerService = wholesalerService;
    }

    public ActionResult Index(int? id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return View(User.IsInRole(UserRolesName.Admin) ? "Index" : "ReadOnlyIndex");
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create()
    {
      var viewModel = new ProductEditModel
      {
        Product = new ProductDto(),
        Categories = _categoryService.GetAllActive(),
        Suppliers = _supplierService.GetAllActive(),
        Wholesalers = _wholesalerService.GetAllActive()
      };
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create(ProductEditModel model)
    {
      if (!ModelState.IsValid) return View(model);

      model.Product.Updated = DateTime.Now;
      model.Product.ByUser = User.Identity.Name;
      _productService.Add(model.Product);

      return RedirectToAction("Index", new { id = model.Product.CategoryId });
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(int id)
    {
      var model = _productService.GetSingle(id);

      if (model == null) return HttpNotFound();

      var viewModel = new ProductEditModel
      {
        Product = model,
        Categories = _categoryService.GetAllActive(),
        Suppliers = _supplierService.GetAllActive(),
        Wholesalers = _wholesalerService.GetAllActive()
      };

      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(ProductEditModel model)
    {
      if (!ModelState.IsValid) return View(model);

      model.Product.Updated = DateTime.Now;
      model.Product.ByUser = User.Identity.Name;
      _productService.Update(model.Product);

      return RedirectToAction("Index", new { id = model.Product.CategoryId });
    }
  }
}