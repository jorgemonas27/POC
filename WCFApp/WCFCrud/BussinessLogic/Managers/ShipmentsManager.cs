using DataAccessNF.Repositories;
using ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Managers
{
    public class ShipmentsManager: BaseManager
    {
        private IDataRepository<ShipmentDB> _orderRepo;
        private IDataRepository<OrderDB> _orderRepo2;
        public ShipmentsManager()
        {
            _orderRepo = (IDataRepository<ShipmentDB>)context["ShipmentOperations"];
            _orderRepo2 = (IDataRepository<OrderDB>)context["OrderOperations"];
        }

        public void Save(ShipmentDB shipment = null)
        {
            _orderRepo.Add(shipment);
        }
    }
}
