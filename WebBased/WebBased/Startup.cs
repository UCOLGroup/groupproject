using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBased.Startup))]
namespace WebBased
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
