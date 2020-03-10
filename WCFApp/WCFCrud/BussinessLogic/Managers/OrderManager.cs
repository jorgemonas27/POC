namespace BussinessLogic.Managers
{
    using BussinessLogic.Converters;
    using DataAccessNF.Repositories;
    using ModelsDB;
    using ModelsDTO;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="OrderManager" />
    /// </summary>
    public class OrderManager : BaseManager, IManager<OrderDTO>
    {
        /// <summary>
        /// Defines the _orderRepo
        /// </summary>
        private IDataRepository<OrderDB> _orderRepo;

        /// <summary>
        /// Defines the _shipmentRepo
        /// </summary>
        private IDataRepository<ShipmentDB> _shipmentRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderManager"/> class.
        /// </summary>
        public OrderManager()
        {
            _orderRepo = (IDataRepository<OrderDB>)context["OrderOperations"];
            _shipmentRepo = (IDataRepository<ShipmentDB>)context["ShipmentOperations"];
        }

        /// <summary> 
        /// The Save method will send a new order resource to be created into the database
        /// </summary>
        /// <param name="order">The order<see cref="OrderDTO"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string Save(OrderDTO order)
        {
            var newOrder = Converter.Cast(order);
            _orderRepo.Add(newOrder);
            return "added successfully";
        }

        /// <summary>
        /// The GetAll method will retrieve a list of all the orders
        /// </summary>
        /// <returns>The <see cref="IList{OrderDTO}"/></returns>
        public IList<OrderDTO> GetAll()
        {
            return Converters.Converter.Cast(_orderRepo.GetAll());
        }

        /// <summary>
        /// The Update method will update a certain order
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="updateOrder">The updateOrder<see cref="OrderDTO"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string Update(int id, OrderDTO updateOrder)
        {
            OrderDB newOrder = Converter.Cast(updateOrder);
            _orderRepo.Update(id, newOrder);
            return "update succcessfully";
        }

        /// <summary>
        /// The Delete method will delete a specific order from the database
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string Delete(int id)
        {
            _orderRepo.Delete(id);
            return "delete successfully";
        }

        /// <summary>
        /// The Consolidate
        /// </summary>
        /// <returns>The <see cref="IList{OrderDTO}"/></returns>
        public IList<OrderDTO> Consolidate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Build
        /// </summary>
        /// <returns>The <see cref="IList{OrderDTO}"/></returns>
        public IList<OrderDTO> Build()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetLoadDetails
        /// </summary>
        /// <returns>The <see cref="IEnumerable{LoadDetailsDTO}"/></returns>
        IEnumerable<LoadDetailsDTO> IManager<OrderDTO>.GetLoadDetails()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetDetails
        /// </summary>
        /// <returns>The <see cref="IEnumerable{ShipmentDetailsDTO}"/></returns>
        public IEnumerable<ShipmentDetailsDTO> GetDetails()
        {
            throw new NotImplementedException();
        }
    }
}
