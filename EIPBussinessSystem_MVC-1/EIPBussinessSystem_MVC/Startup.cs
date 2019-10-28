using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EIPBussinessSystem_MVC.Startup))]
namespace EIPBussinessSystem_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
