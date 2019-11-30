using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(israAppExam.Startup))]
namespace israAppExam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
