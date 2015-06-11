using System.Web.Http;
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
        }
    }
}
