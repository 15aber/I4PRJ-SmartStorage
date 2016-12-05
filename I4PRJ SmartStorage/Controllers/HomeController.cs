using System.Web.Mvc;

namespace I4PRJ_SmartStorage.UI.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return RedirectToAction("Index", "Transactions");
    }
  }
}