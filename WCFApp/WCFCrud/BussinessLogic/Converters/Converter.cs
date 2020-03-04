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
        //  public static OrderMember GetClientOrderObject(OrderDTO order)
        //  {
        //    var newOrder = new OrderMember()
        //    {
        //        IdOrder = order.IdOrder,
        //        NameCompany = order.NameCompany,
        //        OriginAddress = order.OriginAddress,
        //        OriginCity = order.OriginCity,
        //        OriginState = order.OriginState,
        //        OriginCountry = order.OriginCountry,
        //        DestinationAddress = order.DestinationAddress,
        //        DestinationCity = order.DestinationCity,
        //        DestinationCountry = order.DestinationCountry,
        //        DestinationState = order.DestinationState,
        //        Description = order.Description,
        //        Status = order.Status,
        //        IdLoad = order.IdLoad,
        //        IdShipment = order.IdShipment
        //    };

        //    return newOrder;
        //}

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
