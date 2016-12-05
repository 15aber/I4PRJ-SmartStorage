using System.Net;
using System.Web.Mvc;
using I4PRJ_SmartStorage.UI.Identity;

namespace I4PRJ_SmartStorage.UI.Controllers
{
  public class StocksController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult Index()
    {
      var stocks = db.Stocks.Include(s => s.Inventory).Include(s => s.Product);
      return View(stocks.ToList());
    }

    public ActionResult Inventories(int id)
    {
      if(id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      var stockViewModel = new StockViewModel
      {
        Stocks = db.Stocks.Include(s => s.Inventory).Include(s => s.Product).Where(s => s.InventoryId == id).ToList(),
        Inventory = db.Inventories.Single(i => i.InventoryId == id),
        Stock = new Stock()
      };

      if(stockViewModel.Stocks == null)
        return HttpNotFound();

      return View("Index", stockViewModel);
    }

    protected override void Dispose(bool disposing)
    {
      if(disposing)
        db.Dispose();

      base.Dispose(disposing);
    }
  }
}