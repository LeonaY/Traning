using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TraningUpdateGit.Startup))]
namespace TraningUpdateGit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
