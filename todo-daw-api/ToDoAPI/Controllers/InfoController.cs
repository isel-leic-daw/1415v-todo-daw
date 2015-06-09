using System.Configuration;
using System.Web.Http;

namespace ToDoAPI.Controllers
{
    public class InfoController : ApiController
    {
        /// <summary>
        /// Use this operation to get "ThothDB" connection string details.
        /// </summary>
        /// <returns>A connection string settings</returns>
        [Route("api/info/db")]
        public ConnectionStringSettings GetDbInfo()
        {
            var conStr = ConfigurationManager.ConnectionStrings["ThothDB"];
            return conStr;
        }

        /// <summary>
        /// Use this operation to check the API result upon exception.
        /// </summary>
        [Route("api/info/exception")]
        public void GetException()
        {
            SomeMethod();
        }

        private void SomeMethod()
        {
            throw new System.NotImplementedException("This is the message text...");
        }


    }
}
