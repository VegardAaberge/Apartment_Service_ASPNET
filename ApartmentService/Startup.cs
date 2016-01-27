using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApartmentService.Startup))]
namespace ApartmentService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
