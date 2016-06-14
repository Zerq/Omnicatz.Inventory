using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Conspiratron.Startup))]
namespace Conspiratron
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
