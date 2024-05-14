using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Hethongnongsan.Startup))]
namespace Hethongnongsan
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Add your OWIN configuration code here
            // For example, you might configure middleware like this:
            // app.Use<YourMiddleware>();

            // Example: Use a simple welcome page
            app.UseWelcomePage("/");
        }
    }
}
