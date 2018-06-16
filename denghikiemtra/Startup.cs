using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(denghikiemtra.Startup))]
namespace denghikiemtra
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
