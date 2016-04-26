using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BussinessSite.Startup))]
namespace BussinessSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
