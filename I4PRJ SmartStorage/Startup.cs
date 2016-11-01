using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(I4PRJ_SmartStorage.Startup))]
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
