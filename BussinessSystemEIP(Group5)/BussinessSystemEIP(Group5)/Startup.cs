using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BussinessSystemEIP_Group5_.Startup))]
namespace BussinessSystemEIP_Group5_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
