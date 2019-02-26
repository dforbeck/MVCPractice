using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySampleMVCWebsite.WebMVC.Startup))]
namespace MySampleMVCWebsite.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
