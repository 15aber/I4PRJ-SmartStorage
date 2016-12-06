using System.Net;
using System.Web.Mvc;

namespace I4PRJ_SmartStorage.UI.Controllers
{
  public class StocksController : Controller
  {
    public ActionResult Index(int? id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return View("Index");
    }
  }
}