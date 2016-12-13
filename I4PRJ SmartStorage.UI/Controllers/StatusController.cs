using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.UI.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SmartStorage.UI.Controllers
{
  public class StatusController : Controller
  {
    private readonly IStatusService _statusService;
    private readonly IInventoryService _inventoryService;
    private readonly IProductService _productService;
    private readonly IStockService _stockService;

    public StatusController(IStatusService statusService, IInventoryService inventoryService, IProductService productService, IStockService stockService)
    {
      _statusService = statusService;
      _inventoryService = inventoryService;
      _productService = productService;
      _stockService = stockService;
    }

    public ActionResult Index(int? id)
    {
      var viewModel = new StatusViewModel
      {
        Inventories = _inventoryService.GetAllActive(),
        StatusStartedInventories = new List<int>()
      };

      var inventoryIds = new List<int>();

      foreach (var status in _statusService.GetAll())
        inventoryIds.Add(_inventoryService.GetSingle(status.InventoryId).InventoryId);

      foreach (var inventory in inventoryIds)
      {
        var status = _statusService.GetAllOfInventory(inventory)
                .OrderByDescending(o => o.Updated).FirstOrDefault();

        if (status != null && status.IsStarted)
          viewModel.StatusStartedInventories.Add(status.InventoryId);
      }

      if (id == 1)
        viewModel.ShowNotification = true;

      return View(viewModel);
    }

    public ActionResult StartStatus(int id)
    {
      var inventory = _inventoryService.GetSingle(id);

      if (inventory == null)
      {
        return HttpNotFound();
      }

      var viewModel = new StatusApiModel()
      {
        IsStarted = false
      };

      return View("StatusForm", viewModel);
    }

    public ActionResult FinishStatus(int id)
    {
      var inventory = _inventoryService.GetSingle(id);
      if (inventory == null)
      {
        return HttpNotFound();
      }

      var viewModel = new StatusApiModel
      {
        IsStarted = true
      };

      return View("StatusForm", viewModel);
    }

    public ActionResult StatusReports()
    {
      var statuses = new List<StatusDto>();
      foreach (var status in _statusService.GetAll())
      {
        if (statuses.All(o => o.Updated != status.Updated))
          statuses.Add(status);
      }

      var viewModel = new StatusViewModel()
      {
        Statuses = statuses,
        Status = new StatusDto()
      };

      return View("StatusReports", viewModel);
    }

    public ActionResult StatusReportDetails(int id)
    {
      //var status = _statusService.GetSingle(id);

      //if (status == null)
      //{
      //  return HttpNotFound();
      //}

      //var viewModel = new StatusViewModel
      //{
      //  Statuses = _statusService.GetAll()
      //};

      return View("StatusReportDetails");
    }
  }
}
