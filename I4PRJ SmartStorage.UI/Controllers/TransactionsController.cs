using System;
using System.Web.Mvc;
using I4PRJ_SmartStorage.BLL.Dtos;
using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using I4PRJ_SmartStorage.BLL.Services;
using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.UnitOfWork;
using SmartStorage.UI.ViewModels;

namespace SmartStorage.UI.Controllers
{
  public class TransactionsController : Controller
  {
    private readonly ITransactionService _transactionService;
    private readonly IInventoryService _inventoryService;
    private readonly IProductService _productService;

    public TransactionsController()
      : this(new TransactionService(new UnitOfWork(new ApplicationDbContext())), new InventoryService(new UnitOfWork(new ApplicationDbContext())), new ProductService(new UnitOfWork(new ApplicationDbContext())))
    {
    }

    public TransactionsController(ITransactionService transactionService, IInventoryService inventoryService, IProductService productService)
    {
      _transactionService = transactionService ?? new TransactionService(new UnitOfWork(new ApplicationDbContext()));
      _inventoryService = inventoryService ?? new InventoryService(new UnitOfWork(new ApplicationDbContext()));
      _productService = productService ?? new ProductService(new UnitOfWork(new ApplicationDbContext()));
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