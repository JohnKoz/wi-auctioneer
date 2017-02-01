using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(surplus_auctioneer_webapp.Startup))]
namespace surplus_auctioneer_webapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
