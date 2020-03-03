using Autofac;
using DataAccessNF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFCrud;
using WCFCrudUtililies.Global.DataManager;
using WCFCrudUtililies.Global.Repositories;

namespace Host
{
    public class BootStrapper
    {
        public static ContainerBuilder RegisterContainerBuilder()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register(c => new OrderManager()).As<IDataRepository<ClientOrder>>();
            builder.Register(c => new OrderService
                             (c.Resolve<IDataRepository<ClientOrder>>())).As<IOrderService>();
            return builder;
        }
    }
}
