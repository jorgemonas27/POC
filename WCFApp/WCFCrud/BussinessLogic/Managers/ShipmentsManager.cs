namespace BussinessLogic.Managers
{
    using DataAccessNF.Repositories;
    using ModelsDB;
    using ModelsDTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="ShipmentsManager" />
    /// </summary>
    public class ShipmentsManager : BaseManager, IManager<ShipmentDTO>
    {
        /// <summary>
        /// Defines the _shipmentRepo
        /// </summary>
        private IDataRepository<ShipmentDB> _shipmentRepo;

        /// <summary>
        /// Defines the _orderRepo
        /// </summary>
        private IDataRepository<OrderDB> _orderRepo;

        /// <summary>
        /// Defines the _loadRepo
        /// </summary>
        private IDataRepository<LoadDB> _loadRepo;

        /// <summary>
        /// Defines the totalWeigth
        /// </summary>
        private int totalWeigth = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentsManager"/> class.
        /// </summary>
        public ShipmentsManager()
        {
            _shipmentRepo = (IDataRepository<ShipmentDB>)context["ShipmentOperations"];
            _orderRepo = (IDataRepository<OrderDB>)context["OrderOperations"];
            _loadRepo = (IDataRepository<LoadDB>)context["LoadOperations"];
        }

        /// <summary>
        /// The Save method will send a new shipment resource to be created into the database
        /// </summary>
        /// <param name="shipment">The shipment<see cref="ShipmentDTO"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string Save(ShipmentDTO shipment = null)
        {
            _shipmentRepo.Add(Converters.Converter.Cast(shipment));
            return "added succesfully";
        }

        /// <summary>
        /// The Consolidate method will implemented all the logic to group orders under some criteria for retrieve a list of shipments updated
        /// </summary>
        /// <returns>The <see cref="IList{ShipmentDTO}"/></returns>
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

        /// <summary>
        /// The GetDetails
        /// </summary>
        /// <returns>The <see cref="IList{object}"/></returns>
        public IList<object> GetDetails()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Delete method will delete a specific shipment from the database
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="string"/></returns>
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

        /// <summary>
        /// The Update method will update a certain order that exists into a deleted shipment
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="order">The order<see cref="OrderDB"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string Update(int id, OrderDB order)
        {
            _orderRepo.Update(id, order);
            return "updated succesfully";
        }

        /// <summary>
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="updateElement">The updateElement<see cref="ShipmentDTO"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string Update(int id, ShipmentDTO updateElement)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Build
        /// </summary>
        /// <returns>The <see cref="IList{ShipmentDTO}"/></returns>
        public IList<ShipmentDTO> Build()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetAll method will retrieve a list of all the shipments
        /// </summary>
        /// <returns>The <see cref="IList{ShipmentDTO}"/></returns>
        IList<ShipmentDTO> IManager<ShipmentDTO>.GetAll()
        {
            return Converters.Converter.Cast(_shipmentRepo.GetAll());
        }

        /// <summary>
        /// The GetDetails will retrieve a list of details of the shipments
        /// </summary>
        /// <returns>The <see cref="IEnumerable{ShipmentDetailsDTO}"/></returns>
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

        /// <summary>
        /// The GetLoadDetails
        /// </summary>
        /// <returns>The <see cref="IList{LoadDetailsDTO}"/></returns>
        public IList<LoadDetailsDTO> GetLoadDetails()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetLoadDetails
        /// </summary>
        /// <returns>The <see cref="IEnumerable{LoadDetailsDTO}"/></returns>
        IEnumerable<LoadDetailsDTO> IManager<ShipmentDTO>.GetLoadDetails()
        {
            throw new NotImplementedException();
        }
    }
}
