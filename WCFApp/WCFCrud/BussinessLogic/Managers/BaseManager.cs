using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BussinessLogic.Managers
{
    public class BaseManager
    {
        private string springFactoriesFile = ConfigurationManager.AppSettings["springFactoriesFile"]; // ConfigurationManager.AppSettings["springFactoriesFile"];
        private string springFactories = ConfigurationManager.AppSettings["springFactories"];
        protected IApplicationContext context;
        public BaseManager()
        {
            var path = springFactoriesFile.Replace("\\WCFCrud", "");
            //var configurationPath = $@"{path}\WCFCrud\BussinessLogic\{springFactoriesFile}";
            context = new XmlApplicationContext(this.springFactories, this.springFactoriesFile);
        }

    }
}
