using DataAccessNF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFCrud.Convertes
{
    public static class Converter
    {
        public static ClientOrder GetClientOrderObject(OrdDetails order)
        {
            var newOrder = new ClientOrder()
            {
                IdOrder = order.Id,
                NameCompany = order.NameOrder,
                OriginAddress = order.OriginAddress,
                OriginCity = order.OriginCity,
                OriginState = order.OriginState,
                OriginCountry = order.OriginCountry,
                DestinationAddress = order.DestinationAddress,
                DestinationCity = order.DestinationCity,
                DestinationCountry = order.DestinationCountry,
                DestinationState = order.DestinationState,
                Description = order.Description,
                Status = order.Status,
                IdLoad = order.IdLoad,
                IdShipment = order.IdShipment
            };

            return newOrder;
        }
    }
}
