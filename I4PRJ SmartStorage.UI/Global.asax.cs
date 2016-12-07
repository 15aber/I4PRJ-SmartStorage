using AutoMapper;
using SmartStorage.BLL.Mapping;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SmartStorage.UI
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      UnityWebActivator.Start();
      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      Mapper.Initialize(c => c.AddProfile<MappingProfile>());
    }

  }
}