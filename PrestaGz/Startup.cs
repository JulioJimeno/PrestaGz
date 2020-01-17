using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrestaGz.Startup))]
namespace PrestaGz
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
