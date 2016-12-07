using SmartStorage.BLL.Interfaces.Services;
using System.Net;
using System.Web.Mvc;

namespace SmartStorage.UI.Controllers
{
  public class StocksController : Controller
  {
    private readonly IStockService _service;

    public StocksController(IStockService service)
    {
      _service = service;
    }

    public ActionResult Index(int? id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return View("Index");
    }
  }
}