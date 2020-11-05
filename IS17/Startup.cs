using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IS17.Startup))]
namespace IS17
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
