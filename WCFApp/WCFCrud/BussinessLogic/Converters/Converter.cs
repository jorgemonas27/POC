using DataAccessNF.Models;
using ModelsDB;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Converters
{
    public static class Converter
    {
        public static IList<OrderDTO> CastOrigin(IEnumerable<OrderDB> orders)
        {
            var orderList = new List<OrderDTO>();
            foreach (var order in orders)
            {
                var newObject = new OrderDTO()
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
                orderList.Add(newObject);
            }

            return orderList;
        }
        public static IList<OrderDB> CastDestiny(IEnumerable<OrderDTO> orders)
        {
            var orderList = new List<OrderDB>();
            foreach (var order in orders)
            {
                var newObject = new OrderDB()
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
                orderList.Add(newObject);
            }

            return orderList;
        }


        public static IList<ShipmentDB> Cast(IEnumerable<ShipmentDTO> orders)
        {
            var shipmentList = new List<ShipmentDB>();
            foreach (var order in orders)
            {
                var newObject = new ShipmentDB()
                {
                   IdShipment = order.IdShipment,
                   Orders = CastDestiny(order.Orders),
                   Quantity = order.Quantity
                };
                shipmentList.Add(newObject);
            }

            return shipmentList;
        }

        public static OrderDB CastFromDTO(OrderDTO order)
        {
            var newObject = new OrderDB()
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
    }
}
