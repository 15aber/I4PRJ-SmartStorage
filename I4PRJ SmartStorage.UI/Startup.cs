using Microsoft.Owin;
using Owin;
using SmartStorage.UI;

[assembly: OwinStartup("SmartStorage", typeof(Startup))]

namespace SmartStorage.UI
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);
    }
  }
}