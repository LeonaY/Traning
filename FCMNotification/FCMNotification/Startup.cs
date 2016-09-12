using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FCMNotification.Startup))]
namespace FCMNotification
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
