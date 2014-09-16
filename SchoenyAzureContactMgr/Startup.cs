using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoenyAzureContactMgr.Startup))]
namespace SchoenyAzureContactMgr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
