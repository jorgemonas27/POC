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
        private string springOperationsFile = ConfigurationManager.AppSettings["springOperationsFile"];
        private string springOperations = ConfigurationManager.AppSettings["springOperations"];
        protected IApplicationContext context;
        public BaseManager()
        {
            context = new XmlApplicationContext(this.springOperations, this.springOperationsFile);
        }

    }
}
