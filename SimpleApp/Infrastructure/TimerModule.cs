using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleApp.Infrastructure {
    public class TimerModule : IHttpModule {
        private Stopwatch timer;


        public void Init(HttpApplication app) {
            app.BeginRequest += HandleEvent;
            app.EndRequest += HandleEvent;
        }

        public void HandleEvent(object src, EventArgs args) {
            HttpContext ctx = HttpContext.Current;
            if (ctx.CurrentNotification == RequestNotification.BeginRequest) {
                timer = Stopwatch.StartNew();
            } else {
                ctx.Response.Write(string.Format(
                "<div class='alert alert-success'>Elapsed {0:F5} seconds</div>",
            ((float)timer.ElapsedTicks) / Stopwatch.Frequency));
            }
        }
        public void Dispose() {
            // do nothing - no resources to release
        }
    }
}