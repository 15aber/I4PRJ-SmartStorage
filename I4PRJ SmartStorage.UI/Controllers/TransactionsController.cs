using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.UI.ViewModels;
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

    public ActionResult Add()
    {
      var viewModel = new TransactionViewModel
      {
        Transaction = new TransactionDto(),
        ToInventory = _inventoryService.GetAllActive(),
        Products = _productService.GetAllActive()
      };
      return View("Add", viewModel);
    }

    public ActionResult Create()
    {
      var viewModel = new TransactionViewModel
      {
        Transaction = new TransactionDto(),
        FromInventory = _inventoryService.GetAllActive(),
        ToInventory = _inventoryService.GetAllActive(),
        Products = _productService.GetAllActive()
      };
      return View("Create", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(TransactionDto entityDto)
    {
      if (!ModelState.IsValid) return View(entityDto);

      entityDto.Updated = DateTime.Now;
      entityDto.ByUser = User.Identity.Name;
      _transactionService.Add(entityDto);

      return RedirectToAction("Index");
    }
  }
}