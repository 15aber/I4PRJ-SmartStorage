using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace SmartStorage.UI
{
  [ExcludeFromCodeCoverage]
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
      filters.Add(new RequireHttpsAttribute());
      filters.Add(new AuthorizeAttribute());
    }
  }
}