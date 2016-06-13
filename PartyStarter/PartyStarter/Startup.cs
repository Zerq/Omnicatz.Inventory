using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PartyStarter.Startup))]
namespace PartyStarter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
