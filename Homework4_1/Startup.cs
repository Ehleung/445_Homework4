using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homework4_1.Startup))]
namespace Homework4_1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
