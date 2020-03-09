using DataAccessNF.Repositories;
using ModelsDB;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Managers
{
    public class ShipmentsManager: BaseManager
    {
        private IDataRepository<ShipmentDB> _shipmentRepo;
        private IDataRepository<OrderDB> _orderRepo;
        private int totalWeigth = 0;

        public ShipmentsManager()
        {
            _shipmentRepo = (IDataRepository<ShipmentDB>)context["ShipmentOperations"];
            _orderRepo = (IDataRepository<OrderDB>)context["OrderOperations"];
        }

        public void Save(ShipmentDB shipment = null)
        {
            _shipmentRepo.Add(shipment);
        }

        public IList<ShipmentDTO> Consolidate()
        {
            var list = _orderRepo.GetAll();
            var grouped = list.GroupBy(x => x.DestinationState);
            var ids = 10;
            var shipmentList = new List<ShipmentDTO>();
            foreach (var item in grouped)
            {
                item.ToList().ForEach(x =>
                {
                    totalWeigth += x.WeigthOrder;
                });
                var shipment = new ShipmentDTO()
                {
                    IdShipment = ids++,
                    Orders = Converters.Converter.Cast(item.ToList()),
                    Quantity = item.ToList().Count,
                    TotalWeigthOrders = totalWeigth
                };
                shipmentList.Add(shipment);
                totalWeigth = 0;    
            }

            _shipmentRepo.AddList(Converters.Converter.Cast(shipmentList));
            return shipmentList;

        }

        public IList<ShipmentDTO> GetAll()
        {
            return Converters.Converter.Cast(_shipmentRepo.GetAll());
        }

        public string Delete(int id)
        {
            _shipmentRepo.Delete(id);
            return "delete succesfully";
        }
    }
}
