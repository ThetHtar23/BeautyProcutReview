using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeautyProcutReview.Startup))]
namespace BeautyProcutReview
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
