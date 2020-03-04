using BussinessLogic.DataMembers;
using DataAccessNF.Models;
using DataAccessNF.Repositories;
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
    public class OrderManager
    {
        private string springFactoriesFile = ConfigurationManager.AppSettings["springFactoriesFile"]; // ConfigurationManager.AppSettings["springFactoriesFile"];
        private string springFactories = ConfigurationManager.AppSettings["springFactories"];
        public string Save(OrderMember order)
        {
            var path = HttpContext.Current.Server.MapPath("").Replace("\\WCFCrud", "");
            var configurationPath = $@"{path}\WCFCrud\BussinessLogic\{springFactoriesFile}";
            IApplicationContext context = new XmlApplicationContext(this.springFactories, configurationPath);
            var orderManager = (IDataRepository<ClientOrder>)context["OrderOperations"];
            ClientOrder newOrder = new ClientOrder() 
            {
                IdOrder = order.IdOrder,
                NameCompany = order.NameCompany,
                OriginAddress = order.OriginAddress,
                OriginCity = order.OriginCity,
                OriginCountry = order.OriginCountry,
                OriginState = order.OriginState,
                Description = order.Description,
                Status = order.Status,
                DestinationAddress = order.DestinationAddress,
                DestinationCity = order.DestinationCity,
                DestinationCountry = order.DestinationCountry,
                DestinationState = order.DestinationState,
                IdLoad = order.IdLoad,
                IdShipment = order.IdShipment
            };
            return "added successfully";
            
        }

    }
}
