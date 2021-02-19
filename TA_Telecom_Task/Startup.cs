using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TA_Telecom_Task.Startup))]
namespace TA_Telecom_Task
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
