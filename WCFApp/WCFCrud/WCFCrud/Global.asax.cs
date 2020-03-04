
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WCFCrud;
using WCFCrud.App_Start;

namespace WebApplication3
{
    public class Global : HttpApplication
    {
        //static IWindsorContainer container;
        void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}