using System.Web.Mvc;

namespace SmartStorage.UI.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return RedirectToAction("Index", "Transactions");
    }
  }
}