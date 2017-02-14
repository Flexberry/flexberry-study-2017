using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TableTennisTournament.Startup))]
namespace TableTennisTournament
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
