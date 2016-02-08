using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sportnet.Startup))]
namespace sportnet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
