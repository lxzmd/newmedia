using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LogisticsExpress.Web.Startup))]
namespace LogisticsExpress.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
