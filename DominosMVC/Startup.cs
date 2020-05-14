using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DominosMVC.Startup))]
namespace DominosMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
