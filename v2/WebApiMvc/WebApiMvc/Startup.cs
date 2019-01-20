using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApiMvc.Startup))]
namespace WebApiMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
