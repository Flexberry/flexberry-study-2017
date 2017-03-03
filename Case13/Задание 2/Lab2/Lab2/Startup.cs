using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab2.Startup))]
namespace Lab2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
