using Microsoft.Practices.Unity;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace SmartStorage.UI.Helpers
{
  [ExcludeFromCodeCoverage]
  public static class HMTLHelperExtensions
  {
    public static string IsSelected(this HtmlHelper html, string controller = null, string action = null,
        string cssClass = null)
    {
      if (String.IsNullOrEmpty(cssClass))
        cssClass = "active";

      string currentAction = (string)html.ViewContext.RouteData.Values["action"];
      string currentController = (string)html.ViewContext.RouteData.Values["controller"];

      if (String.IsNullOrEmpty(controller))
        controller = currentController;

      if (String.IsNullOrEmpty(action))
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

    public static IList<CategoryDto> GetCategories()
    {
      var service = UnityConfig.GetConfiguredContainer().Resolve<ICategoryService>();
      return service.GetAllActive();
    }

    public static IList<InventoryDto> GetInventories()
    {
      var service = UnityConfig.GetConfiguredContainer().Resolve<IInventoryService>();
      return service.GetAllActive();
    }
  }
}