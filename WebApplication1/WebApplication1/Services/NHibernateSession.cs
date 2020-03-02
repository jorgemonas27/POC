using Microsoft.AspNetCore.Hosting;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class NHibernateSession
    {
        public static ISession OpenSession(IWebHostEnvironment env)
        {
            var configuration = new Configuration();
            var configurationPath = $@"{env.ContentRootPath}\hibernate.cfg.xml"; //HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var employeeConfigurationFile = $@"{env.ContentRootPath}\Mappings\Order.hbm.xml"; //HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\Employee.hbm.xml");
            configuration.AddFile(employeeConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
