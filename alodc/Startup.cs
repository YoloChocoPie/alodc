using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(alodc.Startup))]
namespace alodc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
