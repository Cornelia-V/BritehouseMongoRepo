using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BritehouseMongo.Startup))]
namespace BritehouseMongo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
