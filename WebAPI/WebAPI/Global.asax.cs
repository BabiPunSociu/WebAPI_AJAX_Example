using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Http.WebHost;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // Dùng GlobalConfiguration bằng cách install hostting
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}