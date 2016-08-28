using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DigitalLearningExamingSystem.Startup))]
namespace DigitalLearningExamingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
