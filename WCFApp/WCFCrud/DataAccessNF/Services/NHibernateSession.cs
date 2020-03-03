﻿using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessNF.Services
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var path = HttpContext.Current.Server.MapPath("").Replace("\\WCFCrud","");
            var orderConfigurationFile = $@"{path}\WCFCrud\DataAccessNF\Mappings\Order.hbm.xml";
            var shipmentConfigurationFile = $@"{path}\WCFCrud\DataAccessNF\Mappings\Shipment.hbm.xml";
            var loadConfigurationFile = $@"{path}\WCFCrud\DataAccessNF\Mappings\Load.hbm.xml";
            configuration.AddFile(orderConfigurationFile);
            configuration.AddFile(shipmentConfigurationFile);
            configuration.AddFile(loadConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
