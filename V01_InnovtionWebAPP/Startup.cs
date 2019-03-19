using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(V01_InnovtionWebAPP.Startup))]
namespace V01_InnovtionWebAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
