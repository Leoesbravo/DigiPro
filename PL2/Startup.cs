using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PL2.Startup))]
namespace PL2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
