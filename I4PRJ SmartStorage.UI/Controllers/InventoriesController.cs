using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.ViewModels;
using SmartStorage.BLL.ViewModels.Identity;
using System;
using System.Web.Mvc;
using SmartStorage.DAL.Interfaces;

namespace SmartStorage.UI.Controllers
{
  public class InventoriesController : Controller
  {
    private readonly IInventoryService _service;

        public InventoriesController(IInventoryService service)
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
      var viewModel = new InventoryEditModel
      {
        Inventory = new InventoryDto()
      };

      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create(InventoryEditModel model)
    {
      if (!ModelState.IsValid) return View(model);

      model.Inventory.Updated = DateTime.Now;
      model.Inventory.ByUser = User.Identity.Name;
      _service.Add(model.Inventory);

      return RedirectToAction("Index");
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(int id)
    {
      var modelDto = _service.GetSingle(id);

      if (modelDto == null) return HttpNotFound();

      var viewModel = new InventoryEditModel
      {
        Inventory = modelDto
      };

      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(InventoryEditModel model)
    {
      if (!ModelState.IsValid) return View(model);

      model.Inventory.Updated = DateTime.Now;
      model.Inventory.ByUser = User.Identity.Name;
      _service.Update(model.Inventory);

      return RedirectToAction("Index");
    }
  }
}