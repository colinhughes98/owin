using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string,object>,System.Threading.Tasks.Task>;
namespace owin_test
{
    public class TeapotMiddleware : OwinMiddleware
    {
        public TeapotMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            context.Response.StatusCode = 418;
            // await this.Next.Invoke(context);
        }
    }

    public class ColMiddleWare
    {
        private readonly AppFunc _next;

        public ColMiddleWare(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            Debug.WriteLine("start col middleware");
            await _next.Invoke(env);
            Debug.WriteLine("end col middleware");
        }
    }

    public static class Extensions
    {
        public static void UseColMiddleWare(this IAppBuilder app)
        {
            app.Use<ColMiddleWare>();
        }
    }
}