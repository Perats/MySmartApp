using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySmartApp.Startup))]
namespace MySmartApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
