namespace BussinessLogic.Managers
{
    using DataAccessNF.Repositories;
    using ModelsDB;
    using ModelsDTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="LoadManager" />
    /// </summary>
    public class LoadManager : BaseManager, IManager<LoadDTO>
    {
        /// <summary>
        /// Defines the _truck
        /// </summary>
        private readonly string _truck = "Truck: Tonka 23S Capacity Weigth: 2700, Containers: 5 ";

        /// <summary>
        /// Defines the _loadRepo
        /// </summary>
        private IDataRepository<LoadDB> _loadRepo;

        /// <summary>
        /// Defines the _shipmentRepo
        /// </summary>
        private IDataRepository<ShipmentDB> _shipmentRepo;

        /// <summary>
        /// Defines the _orderRepo
        /// </summary>
        private IDataRepository<OrderDB> _orderRepo;

        /// <summary>
        /// Defines the stops
        /// </summary>
        private StringBuilder stops = new StringBuilder();

        /// <summary>
        /// Defines the _distance
        /// </summary>
        private int _distance = 2500;

        /// <summary>
        /// Defines the _ids
        /// </summary>
        private int _ids = 20;

        /// <summary>
        /// Defines the _totalCost
        /// </summary>
        private int? _totalCost = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadManager"/> class.
        /// </summary>
        public LoadManager()
        {
            _shipmentRepo = (IDataRepository<ShipmentDB>)context["ShipmentOperations"];
            _loadRepo = (IDataRepository<LoadDB>)context["LoadOperations"];
            _orderRepo = (IDataRepository<OrderDB>)context["OrderOperations"];
        }

        /// <summary>
        /// The Save method will send a new load resource to be created into the database
        /// </summary>
        /// <param name="order">The order<see cref="LoadDTO"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string Save(LoadDTO order)
        {
            var newOrder = Converters.Converter.Cast(order);
            _loadRepo.Add(newOrder);
            return "added successfully";
        }

        /// <summary>
        /// The GetAll method will retrieve a list of all the loads
        /// </summary>
        /// <returns>The <see cref="IList{LoadDTO}"/></returns>
        public IList<LoadDTO> GetAll()
        {
            return Converters.Converter.Cast(_loadRepo.GetAll());
        }

        /// <summary> 
        /// The Delete method will delete a specific load from the database
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string Delete(int id)
        {
            var list = _shipmentRepo.GetAll().ToList().GroupBy(x => x.IdLoad);
            foreach (var item in list)
            {
                if (item.Key == id)
                {
                    item.ToList().ForEach(x =>
                    {
                        this.Update(x.Orders);
                    });
                }
            }
            _loadRepo.Delete(id);
            return "delete successfully";
        }

        /// <summary>
        /// The Build method will do the logic to group all the orders and retrieve a list of loads 
        /// </summary>
        /// <returns>The <see cref="IList{LoadDTO}"/></returns>
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

        /// <summary>
        /// The Update method will upate a certain shipment that exists into a deleted load
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="shipment">The shipment<see cref="ShipmentDB"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string Update(int id, ShipmentDB shipment)
        {
            _shipmentRepo.Update(id, shipment);
            return "updated succesfully";
        }

        /// <summary>
        /// The Update will update an order that exists into some deleted load
        /// </summary>
        /// <param name="shipment">The shipment<see cref="IList{OrderDB}"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string Update(IList<OrderDB> shipment)
        {
            foreach (var ship in shipment)
            {
                ship.IdLoad = null;
                _orderRepo.Update(ship.IdOrder, ship);
            }
            return "updated succesfully";
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="updateElement">The updateElement<see cref="LoadDTO"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string Update(int id, LoadDTO updateElement)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Consolidate
        /// </summary>
        /// <returns>The <see cref="IList{LoadDTO}"/></returns>
        public IList<LoadDTO> Consolidate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetDetails
        /// </summary>
        /// <returns>The <see cref="IList{object}"/></returns>
        public IList<object> GetDetails()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetDetails
        /// </summary>
        /// <returns>The <see cref="IEnumerable{ShipmentDetailsDTO}"/></returns>
        IEnumerable<ShipmentDetailsDTO> IManager<LoadDTO>.GetDetails()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetLoadDetails will retrieve a list of details of the loads
        /// </summary>
        /// <returns>The <see cref="IEnumerable{LoadDetailsDTO}"/></returns>
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
