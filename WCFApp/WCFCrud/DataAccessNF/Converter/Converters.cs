using DataAccessNF.Models;
using ModelsDB;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessNF.Converter
{
    public class Converters
    {
        public static ClientOrder CastForDB(OrderDB order)
        {
            var newObject = new ClientOrder()
            {
                IdOrder = order.IdOrder,
                NameCompany = order.NameCompany,
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

            return newObject;
        }

        public static ClientShipment Cast(ShipmentDB order)
        {
            var newObject = new ClientShipment()
            {
               IdShipment = order.IdShipment,
               Orders = CastForBL(order.Orders),
               QuantityOrders = order.Quantity
            };

            return newObject;
        }

        public static IList<OrderDB> CastForBL(IList<ClientOrder> clientOrders)
        {
            var list = new List<OrderDB>();
            foreach (var order in clientOrders)
            {
                var newobj = new OrderDB()
                {
                    IdOrder = order.IdOrder,
                    NameCompany = order.NameCompany,
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
                list.Add(newobj);
            }
            return list;

        }

        public static IList<ClientOrder> CastForBL(IList<OrderDB> orders)
        {
            var list = new List<ClientOrder>();
            foreach (var order in orders)
            {
                var newobj = new ClientOrder()
                {
                    IdOrder = order.IdOrder,
                    NameCompany = order.NameCompany,
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
                list.Add(newobj);
            }
            return list;

        }


    }
}
