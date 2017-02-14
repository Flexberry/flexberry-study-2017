using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebClientProject.Startup))]
namespace WebClientProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
