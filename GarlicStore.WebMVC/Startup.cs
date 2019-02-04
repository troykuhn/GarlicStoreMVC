using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GarlicStore.WebMVC.Startup))]
namespace GarlicStore.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
