using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Mvc;
using log4net;

namespace ToDoAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static ILog Log = LogManager.GetLogger(typeof (WebApiApplication));

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(HalConfig.Configure);
            Log.Info("READY TO ROCK");

            GlobalConfiguration.Configuration.Services.Add(
                    typeof(IExceptionLogger), 
                    new CustomExceptionLogger());

        }
    }

    public class CustomExceptionLogger : ExceptionLogger
    {
        private static ILog Logger = LogManager.GetLogger(typeof (CustomExceptionLogger));
        public override void Log(ExceptionLoggerContext context)
        {
            Logger.Error(string.Format("Unhandled exception: {0}", context.ExceptionContext.Exception.Message), 
                         context.ExceptionContext.Exception);
            
            base.Log(context);
        }
    }


}
