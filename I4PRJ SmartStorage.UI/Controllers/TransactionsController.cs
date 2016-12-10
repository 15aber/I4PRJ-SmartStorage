using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.ViewModels;
using System;
using System.Web.Mvc;

namespace SmartStorage.UI.Controllers
{
  public class TransactionsController : Controller
  {
    private readonly ITransactionService _transactionService;
    private readonly IInventoryService _inventoryService;
    private readonly IProductService _productService;

    public TransactionsController(ITransactionService transactionService, IInventoryService inventoryService, IProductService productService)
    {
      _transactionService = transactionService;
      _inventoryService = inventoryService;
      _productService = productService;
    }
    public ActionResult Index()
    {
      return View("Index");
    }

   public ActionResult Create()
    {
      var viewModel = new TransactionEditModel
      {
        Transaction = new TransactionDto(),
        Inventories = _inventoryService.GetAllActive(),
        Products = _productService.GetAllActive()
      };
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(TransactionEditModel model)
    {
      if (!ModelState.IsValid) return View("Create", model);

      model.Transaction.Updated = DateTime.Now;
      model.Transaction.ByUser = User.Identity.Name;
      _transactionService.Add(model.Transaction);

      return RedirectToAction("Index");
    }
  }
}