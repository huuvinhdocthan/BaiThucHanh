using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmallSchool.Startup))]
namespace SmallSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
