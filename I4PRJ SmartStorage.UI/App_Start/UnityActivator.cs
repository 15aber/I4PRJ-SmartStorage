using SmartStorage.UI;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UnityWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(UnityWebActivator), "Shutdown")]

namespace SmartStorage.UI
{
  /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
  [ExcludeFromCodeCoverage]
  public static class UnityWebActivator
  {
    /// <summary>Integrates Unity when the application starts.</summary>
    public static void Start()
    {
      var container = UnityConfig.GetConfiguredContainer();

      FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
      FilterProviders.Providers.Add(new Microsoft.Practices.Unity.Mvc.UnityFilterAttributeFilterProvider(container));

      DependencyResolver.SetResolver(new Microsoft.Practices.Unity.Mvc.UnityDependencyResolver(container));
      GlobalConfiguration.Configuration.DependencyResolver = new Microsoft.Practices.Unity.WebApi.UnityDependencyResolver(UnityConfig.GetConfiguredContainer());

      // Uncomment if you want to use PerRequestLifetimeManager
      // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
    }

    /// <summary>Disposes the Unity container when the application is shut down.</summary>
    public static void Shutdown()
    {
      var container = UnityConfig.GetConfiguredContainer();
      container.Dispose();
    }
  }
}