using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BS_MVC.Startup))]
namespace BS_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
