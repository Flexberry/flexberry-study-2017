using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LostFound.Startup))]
namespace LostFound
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
