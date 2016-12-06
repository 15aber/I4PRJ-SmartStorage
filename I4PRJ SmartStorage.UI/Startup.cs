using I4PRJ_SmartStorage.UI;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("I4PRJ SmartStorage", typeof(Startup))]

namespace I4PRJ_SmartStorage.UI
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);
    }
  }
}