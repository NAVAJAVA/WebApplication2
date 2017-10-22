using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviePro.Startup))]
namespace MoviePro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
