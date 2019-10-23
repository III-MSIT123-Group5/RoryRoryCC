using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BussinessSystem_MVC.Startup))]
namespace BussinessSystem_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
