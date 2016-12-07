using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.ViewModels;
using SmartStorage.BLL.ViewModels.Identity;
using System;
using System.Web.Mvc;

namespace SmartStorage.UI.Controllers
{
  public class SuppliersController : Controller
  {
    private readonly ISupplierService _service;

    public SuppliersController(ISupplierService service)
    {
      _service = service;
    }

    public ActionResult Index()
    {
      return View(User.IsInRole(UserRolesName.Admin) ? "Index" : "ReadOnlyIndex");
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create()
    {
      var viewModel = new SupplierEditModel()
      {
        Supplier = new SupplierDto()
      };

      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create(SupplierEditModel model)
    {
      if (!ModelState.IsValid) return View(model);

      model.Supplier.Updated = DateTime.Now;
      model.Supplier.ByUser = User.Identity.Name;
      _service.Add(model.Supplier);

      return RedirectToAction("Index");
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(int id)
    {
      var modelDto = _service.GetSingle(id);

      if (modelDto == null) return HttpNotFound();

      var viewModel = new SupplierEditModel()
      {
        Supplier = modelDto
      };

      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(SupplierEditModel model)
    {
      if (!ModelState.IsValid) return View(model);

      model.Supplier.Updated = DateTime.Now;
      model.Supplier.ByUser = User.Identity.Name;
      _service.Update(model.Supplier);

      return RedirectToAction("Index");
    }
  }
}
