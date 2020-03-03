using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataAccessNF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFCrudUtililies.Global.DataManager;
using WCFCrudUtililies.Global.Repositories;

namespace WCFCrud
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDataRepository<ClientOrder>, OrderManager>(),
                Component.For<IOrderService, OrderService>());
        }
    }
}