using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectManagementSystem.Startup))]
namespace ProjectManagementSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
