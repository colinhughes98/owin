using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(owin_test.Startup))]

namespace owin_test
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //app.Use<ColMiddleWare>();
            app.UseColMiddleWare();
            app.Use<TeapotMiddleware>();
            
        }
    }
}
