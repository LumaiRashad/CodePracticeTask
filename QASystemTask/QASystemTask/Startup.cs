using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QASystemTask.Startup))]
namespace QASystemTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
