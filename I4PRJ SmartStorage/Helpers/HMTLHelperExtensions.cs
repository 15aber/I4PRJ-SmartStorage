using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.Helpers
{
  public static class HMTLHelperExtensions
  {
    public static string IsSelected(this HtmlHelper html, string controller = null, string action = null,
        string cssClass = null)
    {
      if(String.IsNullOrEmpty(cssClass))
        cssClass = "active";

      string currentAction = (string)html.ViewContext.RouteData.Values["action"];
      string currentController = (string)html.ViewContext.RouteData.Values["controller"];

      if(String.IsNullOrEmpty(controller))
        controller = currentController;

      if(String.IsNullOrEmpty(action))
        action = currentAction;

      return controller == currentController && action == currentAction
          ? cssClass
          : String.Empty;
    }

    public static string PageClass(this HtmlHelper html)
    {
      string currentAction = (string)html.ViewContext.RouteData.Values["action"];
      return currentAction;
    }


    public static List<Inventory> GetInventories()
    {
      using(ApplicationDbContext db = new ApplicationDbContext())
      {
        return db.Inventories.ToList();
      }
    }

    public static List<Category> GetCategories()
    {
      using(ApplicationDbContext db = new ApplicationDbContext())
      {
        return db.Categories.Where(i => i.IsDeleted == true).ToList();
      }
    }
  }
}