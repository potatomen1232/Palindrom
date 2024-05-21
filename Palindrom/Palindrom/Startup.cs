using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Palindrom.Startup))]
namespace Palindrom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
