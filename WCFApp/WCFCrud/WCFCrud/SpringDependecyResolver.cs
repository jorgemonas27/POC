using Spring.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCFCrud
{
    public class SpringDependecyResolver: IDependencyResolver
    {
        private readonly IApplicationContext _context;

        public SpringDependecyResolver(IApplicationContext context)
        {
            _context = context;
        }

        public object GetService(Type serviceType)
        {
            var dictionary = _context.GetObjectsOfType(serviceType).GetEnumerator();

            dictionary.MoveNext();
            try
            {
                return dictionary.Current;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _context.GetObjectsOfType(serviceType).Cast<object>();
        }
    }
}