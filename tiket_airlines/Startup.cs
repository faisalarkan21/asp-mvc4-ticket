using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tiket_airlines.Startup))]
namespace tiket_airlines
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
