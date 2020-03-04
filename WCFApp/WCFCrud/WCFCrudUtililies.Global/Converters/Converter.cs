using BussinessLogic.DataMembers;
using ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFCrudUtililies.Global.Converters
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

        //public static IEnumerable<OrderMember> CastOrigin(IEnumerable<ClientOrder> orders)
        //{
        //    var orderList = new List<OrderMember>();
        //    foreach (var order in orders)
        //    {
        //        var newObject = new OrderMember()
        //        {
        //            IdOrder = order.IdOrder,
        //            NameCompany = order.NameCompany,
        //            OriginAddress = order.OriginAddress,
        //            OriginCity = order.OriginCity,
        //            OriginState = order.OriginState,
        //            OriginCountry = order.OriginCountry,
        //            DestinationAddress = order.DestinationAddress,
        //            DestinationCity = order.DestinationCity,
        //            DestinationCountry = order.DestinationCountry,
        //            DestinationState = order.DestinationState,
        //            Description = order.Description,
        //            Status = order.Status,
        //            IdLoad = order.IdLoad,
        //            IdShipment = order.IdShipment
        //        };
        //        orderList.Add(newObject);
        //    }

        //    return orderList;
        //}

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
    }
}
