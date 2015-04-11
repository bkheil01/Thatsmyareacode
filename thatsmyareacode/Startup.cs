using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(thatsmyareacode.Startup))]
namespace thatsmyareacode
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
