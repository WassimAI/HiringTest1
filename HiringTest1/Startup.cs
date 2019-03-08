using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HiringTest1.Startup))]
namespace HiringTest1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
