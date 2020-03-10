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
    public class LoadManager : BaseManager, IManager<LoadDTO>
    {
        private readonly string _truck = "Truck: Tonka 23S Capacity Weigth: 2700, Containers: 5 ";
        private IDataRepository<LoadDB> _loadRepo;
        private IDataRepository<ShipmentDB> _shipmentRepo;
        private IDataRepository<OrderDB> _orderRepo;

        private StringBuilder stops = new StringBuilder();
        private int _distance = 2500;
        private int _ids = 20;
        private int? _totalCost = 0;

        public LoadManager()
        {
            _shipmentRepo = (IDataRepository<ShipmentDB>)context["ShipmentOperations"];
            _loadRepo = (IDataRepository<LoadDB>)context["LoadOperations"];
            _orderRepo = (IDataRepository<OrderDB>)context["OrderOperations"];
        }

        public string Save(LoadDTO order)
        {
            var newOrder = Converters.Converter.Cast(order);
            _loadRepo.Add(newOrder);
            return "added successfully";
        }

        public IList<LoadDTO> GetAll()
        {
            return Converters.Converter.Cast(_loadRepo.GetAll());
        }

        public string Delete(int id)
        {
            _loadRepo.Delete(id);
            var list = _shipmentRepo.GetAll().ToList().GroupBy(x => x.IdShipment).Where(z => z.Key == id);
            foreach (var item in list)
            {
                item.ToList().ForEach(x =>
                {
                    x.IdLoad = null;
                    this.Update(x.IdShipment, x);
                    this.Update(x.Orders);
                });
            }
            return "delete successfully";
        }

        public IList<LoadDTO> Build()
        {
            var shipments = _shipmentRepo.GetAll();
            var group = shipments.GroupBy(x => x.TotalWeigthOrders).Where(s => s.Key <= 2800);
            var list = new List<LoadDB>();
            foreach (var item in group)
            {
                item.ToList().ForEach(x => x.Orders.ToList().ForEach(z =>
                {
                    x.IdLoad = _ids;
                    z.IdLoad = _ids;
                    z.Status = "Loaded";
                    stops.Append(z.DestinationCity).Append(",");
                    _totalCost += z.CostOrder;
                    _orderRepo.Update(z.IdOrder, z);
                    _shipmentRepo.Update(x.IdShipment, x);
                }));

                var newObj = new LoadDB()
                {
                    IdLoad = _ids,
                    TotalDistanceLoad = _distance + 500,
                    StopsLoad = stops.ToString(),
                    TruckLoad = _truck,
                    Shipments = item.ToList(),
                    QuantityShipmentsLoad = item.ToList().Count,
                    TotalCostLoad = _totalCost
                };
                
                list.Add(newObj);
                stops = new StringBuilder();
                _totalCost = 0;
                _ids++;
            }

            _loadRepo.AddList(list);
            return Converters.Converter.Cast(list);
        }

        public string Update(int id, ShipmentDB shipment)
        {
            _shipmentRepo.Update(id, shipment);
            return "updated succesfully";
        }

        public string Update(IList<OrderDB> shipment)
        {
            foreach (var ship in shipment)
            {
                ship.IdLoad = null;
                _orderRepo.Update(ship.IdOrder, ship);
            }
            return "updated succesfully";
        }
        public string Update(int id, LoadDTO updateElement)
        {
            throw new NotImplementedException();
        }

        public IList<LoadDTO> Consolidate()
        {
            throw new NotImplementedException();
        }

        public IList<object> GetDetails()
        {
            throw new NotImplementedException();
        }

        IEnumerable<ShipmentDetailsDTO> IManager<LoadDTO>.GetDetails()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoadDetailsDTO> GetLoadDetails()
        {
            var shipmentRepo = _shipmentRepo.GetAll();
            var orderRepo = _orderRepo.GetAll();
            var loadsRepo = _loadRepo.GetAll();


            var inner = from iten in orderRepo
                        join shipmentitem in shipmentRepo on iten.IdLoad equals shipmentitem.IdLoad
                        join loaditem in loadsRepo on shipmentitem.IdLoad equals loaditem.IdLoad  
                        select new LoadDetailsDTO()
                        {
                            IdLoad = loaditem.IdLoad,
                            IdShipment = shipmentitem.IdShipment,
                            IdOrder = iten.IdOrder,
                            DestinationCity = iten.DestinationCity,
                            DestinationState = iten.DestinationState,
                            Status = iten.Status,
                            NameCompany = iten.NameCompany,
                            NumberOfOrders = shipmentitem.Orders.Count,
                            TotalWeigthOrders = shipmentitem.TotalWeigthOrders,
                            TruckLoad = loaditem.TruckLoad,
                            TotalDistanceLoad = loaditem.TotalDistanceLoad,
                            StopsLoad = loaditem.StopsLoad,
                            QuantityShipmentsLoad = loaditem.QuantityShipmentsLoad,
                            TotalCostLoad = loaditem.TotalCostLoad
                        };

            return inner;
        }
    }
}
