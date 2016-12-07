using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.ViewModels;
using SmartStorage.BLL.ViewModels.Identity;
using System;
using System.Web.Mvc;

namespace SmartStorage.UI.Controllers
{
  public class WholesalersController : Controller
  {
    private readonly IWholesalerService _service;

    public WholesalersController(IWholesalerService service)
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
      var viewModel = new WholesalerEditModel()
      {
        Wholesaler = new WholesalerDto()
      };

      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create(WholesalerEditModel model)
    {
      if (!ModelState.IsValid) return View(model);

      model.Wholesaler.Updated = DateTime.Now;
      model.Wholesaler.ByUser = User.Identity.Name;
      _service.Add(model.Wholesaler);

      return RedirectToAction("Index");
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(int id)
    {
      var modelDto = _service.GetSingle(id);

      if (modelDto == null) return HttpNotFound();

      var viewModel = new WholesalerEditModel()
      {
        Wholesaler = modelDto
      };

      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(WholesalerEditModel model)
    {
      if (!ModelState.IsValid) return View(model);

      model.Wholesaler.Updated = DateTime.Now;
      model.Wholesaler.ByUser = User.Identity.Name;
      _service.Update(model.Wholesaler);

      return RedirectToAction("Index");
    }
  }
}
