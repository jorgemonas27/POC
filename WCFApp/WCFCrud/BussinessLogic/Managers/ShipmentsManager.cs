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
    public class ShipmentsManager: BaseManager, IManager<ShipmentDTO>
    {
        private IDataRepository<ShipmentDB> _shipmentRepo;
        private IDataRepository<OrderDB> _orderRepo;
        private IDataRepository<LoadDB> _loadRepo;
        private int totalWeigth = 0;

        public ShipmentsManager()
        {
            _shipmentRepo = (IDataRepository<ShipmentDB>)context["ShipmentOperations"];
            _orderRepo = (IDataRepository<OrderDB>)context["OrderOperations"];
            _loadRepo = (IDataRepository<LoadDB>)context["LoadOperations"];
        }

        public string Save(ShipmentDTO shipment = null)
        {
            _shipmentRepo.Add(Converters.Converter.Cast(shipment));
            return "added succesfully";
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

        public IList<object> GetDetails()
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            _shipmentRepo.Delete(id);
            var list = _orderRepo.GetAll().ToList().GroupBy(x => x.IdShipment).Where(y => y.Key == id);
            foreach (var item in list)
            {
                item.ToList().ForEach(x =>
                {
                    x.IdShipment = null;
                    this.Update(id, x);
                });
            }
            return "delete succesfully";
        }

        public string Update(int id, OrderDB order)
        {
            _orderRepo.Update(id, order);
            return "updated succesfully";
        }

        public string Update(int id, ShipmentDTO updateElement)
        {
            throw new NotImplementedException();
        }

        public IList<ShipmentDTO> Build()
        {
            throw new NotImplementedException();
        }

        IList<ShipmentDTO> IManager<ShipmentDTO>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<ShipmentDetailsDTO> IManager<ShipmentDTO>.GetDetails()
        {
            var list = _orderRepo.GetAll();
            var shipmentRepo = _shipmentRepo.GetAll();
            var inner = from iten in list
                        join shipmentitem in shipmentRepo on iten.IdShipment equals shipmentitem.IdShipment
                        select new ShipmentDetailsDTO()
                        {
                            IdShipment = shipmentitem.IdShipment,
                            IdOrder = iten.IdOrder,
                            DestinationCity = iten.DestinationCity,
                            DestinationState = iten.DestinationState,
                            Status = iten.Status,
                            NameCompany = iten.NameCompany,
                            NumberOfOrders = shipmentitem.Orders.Count,
                            TotalWeigthOrders = shipmentitem.TotalWeigthOrders
                        };

            return inner;
        }

        public IList<LoadDetailsDTO> GetLoadDetails()
        {
            throw new NotImplementedException();
        }

        IEnumerable<LoadDetailsDTO> IManager<ShipmentDTO>.GetLoadDetails()
        {
            throw new NotImplementedException();
        }
    }
}
