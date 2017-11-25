using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(medDatabase.Web.Startup))]
namespace medDatabase.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
