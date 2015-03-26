using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ModelsAndBottles.Startup))]
namespace ModelsAndBottles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
