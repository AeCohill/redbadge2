using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobsForYou.WebMVC.Startup))]
namespace JobsForYou.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
