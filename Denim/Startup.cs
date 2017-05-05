using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Denim.Startup))]
namespace Denim
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
