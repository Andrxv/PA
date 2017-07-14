using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaELFINAL.Startup))]
namespace PaELFINAL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
