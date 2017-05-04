using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjaxCorporation.LostFound.Startup))]
namespace AjaxCorporation.LostFound
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
