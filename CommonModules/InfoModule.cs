using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonModules {
    public class InfoModule : IHttpModule {
        public void Init(HttpApplication app) {
            app.EndRequest += (src, args) => {
                HttpContext ctx = HttpContext.Current;
                ctx.Response.Write(string.Format(
                    "<div class='alert alert-success'>URL: {0} Status: {1}</div>", ctx.Request.RawUrl, ctx.Response.StatusCode));
            };
        }
        public void Dispose() {

        }
    }
}
