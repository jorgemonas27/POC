using Castle.Facilities.WcfIntegration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WCFCrud;

namespace WebApplication3
{
    public class Global : HttpApplication
    {
        static IWindsorContainer container;
        void Application_Start(object sender, EventArgs e)
        {
            container = new WindsorContainer();
            container.AddFacility<WcfFacility>();
            container.Install(new WindsorInstaller());
        }
    }
}