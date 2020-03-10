namespace DataAccessNF.Services
{
    using NHibernate;
    using NHibernate.Cfg;
    using System.Web;

    /// <summary>
    /// Defines the <see cref="NHibernateSession" />
    /// </summary>
    public class NHibernateSession
    {
        /// <summary>
        /// The OpenSession method will initialize the NHibernate connection
        /// </summary>
        /// <returns>The <see cref="ISession"/></returns>
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var path = HttpContext.Current.Server.MapPath("")
                .Replace("odata", "").Replace("\\WCFCrud", "").Replace("Order", "").Replace("Shipment", "").Replace("Load", "");
            var configurationPath = $@"{path}\WCFCrud\DataAccessNF\hibernate.cfg.xml";
            configuration.Configure(configurationPath);
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
