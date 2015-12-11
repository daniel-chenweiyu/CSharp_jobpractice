using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticeWork.Startup))]
namespace PracticeWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
