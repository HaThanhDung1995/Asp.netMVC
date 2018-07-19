using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo.WebApplication.Startup))]
namespace Demo.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
