using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NomiPro.Startup))]
namespace NomiPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
