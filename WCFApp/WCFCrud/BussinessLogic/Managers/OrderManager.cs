using BussinessLogic.Converters;
using DataAccessNF.Models;
using DataAccessNF.Repositories;
using ModelsDB;
using ModelsDTO;
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
    public class OrderManager : BaseManager
    {
        private IDataRepository<OrderDB> _orderRepo;
        public OrderManager()
        {
            _orderRepo = (IDataRepository<OrderDB>)context["OrderOperations"];
        }
        public string Save(OrderDTO order)
        {
            OrderDB newOrder = new OrderDB() 
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

            _orderRepo.Add(newOrder);
            return "added successfully";
        }

        public IList<OrderDTO> GetData()
        {
            return Converters.Converter.CastOrigin(_orderRepo.GetAll());
        }

        public string Update(int id, OrderDTO updateOrder)
        {
            OrderDB newOrder = Converter.CastFromDTO(updateOrder);
            _orderRepo.Update(id, newOrder);
            return "update succcessfully";
        }

        public string Delete(int id)
        {
            _orderRepo.Delete(id);
            return "delete successfully";
        }

    }
}
