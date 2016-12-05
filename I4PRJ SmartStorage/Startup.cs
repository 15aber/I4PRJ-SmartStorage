using I4PRJ_SmartStorage;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace I4PRJ_SmartStorage
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);
    }
  }
}