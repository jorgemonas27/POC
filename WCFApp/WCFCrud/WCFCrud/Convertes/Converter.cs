using BussinessLogic.DataMembers;
using DataAccessNF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFCrud.ModelsDTO;

namespace WCFCrud.Convertes
{
    public static class Converter
    {
        public static OrderMember GetClientOrderObject(OrderDTO order)
        {
            var newOrder = new OrderMember()
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

            return newOrder;
        }
    }
}
