using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACTMS.Startup))]
namespace ACTMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
