using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusinessSystemMVC_Admin_page_.Startup))]
namespace BusinessSystemMVC_Admin_page_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
