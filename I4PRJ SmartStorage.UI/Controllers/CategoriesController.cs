using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.ViewModels;
using SmartStorage.BLL.ViewModels.Identity;
using System;
using System.Web.Mvc;
using SmartStorage.DAL.Interfaces;

namespace SmartStorage.UI.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ICategoryService _service;
   
    public CategoriesController(ICategoryService service)
    {
      _service = service;
    }

    public ActionResult Index()
    {
      //return View(User.IsInRole(UserRolesName.Admin) ? "Index" : "ReadOnlyIndex");
        return View("Index");
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create()
    {
      var viewModel = new CategoryEditModel
      {
        Category = new CategoryDto()
      };
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create(CategoryEditModel model)
    {
      if (!ModelState.IsValid) return View(model);

      model.Category.Updated = DateTime.Now;
      model.Category.ByUser = User.Identity.Name;
      _service.Add(model.Category);

      return RedirectToAction("Index");
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(int id)
    {
      var modelDto = _service.GetSingle(id);

      if (modelDto == null) return HttpNotFound();

      var viewModel = new CategoryEditModel
      {
        Category = modelDto
      };

      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(CategoryEditModel model)
    {
      if (!ModelState.IsValid) return View(model);

      model.Category.Updated = DateTime.Now;
      model.Category.ByUser = User.Identity.Name;
      _service.Update(model.Category);

      return RedirectToAction("Index");
    }
  }
}