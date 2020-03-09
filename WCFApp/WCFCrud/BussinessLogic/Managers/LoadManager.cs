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
    public class LoadManager : BaseManager
    {
        private readonly string _truck = "Truck: Tonka 23S Capacity Weigth: 2700, Containers: 5 ";
        private IDataRepository<LoadDB> _loadRepo;
        private IDataRepository<ShipmentDB> _shipmentRepo;
        private StringBuilder stops = new StringBuilder();
        private int _distance = 2500;
        private int _ids = 20;
        private int? _totalCost = 0;

        public LoadManager()
        {
            _shipmentRepo = (IDataRepository<ShipmentDB>)context["ShipmentOperations"];
            _loadRepo = (IDataRepository<LoadDB>)context["LoadOperations"];
        }

        public string Save(LoadDTO order)
        {
            var newOrder = Converters.Converter.Cast(order);
            _loadRepo.Add(newOrder);
            return "added successfully";
        }

        public IList<LoadDTO> GetData()
        {
            return Converters.Converter.Cast(_loadRepo.GetAll());
        }

        public string Delete(int id)
        {
            _loadRepo.Delete(id);
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
                    stops.Append(z.DestinationCity).Append(",");
                    _totalCost += z.CostOrder;
                }));

                var newObj = new LoadDB()
                {
                    IdLoad = _ids++,
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
            }

            _loadRepo.AddList(list);
            return Converters.Converter.Cast(list);
        }
    }
}
