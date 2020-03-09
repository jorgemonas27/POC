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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BussinessLogic.Managers
{
    public class OrderManager : BaseManager
    {
        private IDataRepository<OrderDB> _orderRepo;
        private IDataRepository<ShipmentDB> _shipmentRepo;
        public OrderManager()
        {
            _orderRepo = (IDataRepository<OrderDB>)context["OrderOperations"];
            _shipmentRepo = (IDataRepository<ShipmentDB>)context["ShipmentOperations"];
        }
        public string Save(OrderDTO order)
        {
            var newOrder = Converter.Cast(order);
            _orderRepo.Add(newOrder);
            return "added successfully";
        }

        public IList<OrderDTO> GetData()
        {
            return Converters.Converter.Cast(_orderRepo.GetAll());
        }

        public string Update(int id, OrderDTO updateOrder)
        {
            OrderDB newOrder = Converter.Cast(updateOrder);
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
