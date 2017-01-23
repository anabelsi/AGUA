using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VRRE.Startup))]
namespace VRRE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
