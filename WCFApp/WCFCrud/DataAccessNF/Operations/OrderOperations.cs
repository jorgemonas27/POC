namespace DataAccessNF.Operations
{
    using DataAccessNF.Converter;
    using DataAccessNF.Models;
    using DataAccessNF.Repositories;
    using DataAccessNF.Services;
    using ModelsDB;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="OrderOperations" />
    /// </summary>
    public class OrderOperations : IDataRepository<OrderDB>
    {
        /// <summary>
        /// The Add method will save a new order into the database
        /// </summary>
        /// <param name="newElement">The newElement<see cref="OrderDB"/></param>
        public void Add(OrderDB newElement)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(Converters.Cast(newElement));
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// The AddList will add a list of orders into the database
        /// </summary>
        /// <param name="element">The element<see cref="IList{OrderDB}"/></param>
        public void AddList(IList<OrderDB> element)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Delete method will delete a certain order from the database
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public void Delete(int id)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var order = session.Get<ClientOrder>(Convert.ToInt32(id));
                        session.Delete(order);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// The Get method will retrieve a certain order by the id
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="OrderDB"/></returns>
        public OrderDB Get(int id)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var order = session.Get<OrderDB>(Convert.ToInt32(id));
                        return order;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// The Update method will update a certain order of the database
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="element">The element<see cref="OrderDB"/></param>
        public void Update(int id, OrderDB element)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var orderUpdate = session.Get<ClientOrder>(Convert.ToInt32(id));
                        orderUpdate.NameCompany = element.NameCompany;
                        orderUpdate.Description = element.Description;
                        orderUpdate.DestinationAddress = element.DestinationAddress;
                        orderUpdate.DestinationCity = element.DestinationCity;
                        orderUpdate.DestinationCountry = element.DestinationCountry;
                        orderUpdate.DestinationState = element.DestinationState;
                        orderUpdate.OriginAddress = element.OriginAddress;
                        orderUpdate.OriginCity = element.OriginCity;
                        orderUpdate.OriginAddress = element.OriginAddress;
                        orderUpdate.OriginCountry = element.OriginCountry;
                        orderUpdate.OriginState = element.OriginState;
                        orderUpdate.IdLoad = element.IdLoad;
                        orderUpdate.IdShipment = element.IdShipment;
                        orderUpdate.Status = element.Status;
                        orderUpdate.WeigthOrder = element.WeigthOrder;
                        orderUpdate.CostOrder = element.CostOrder;
                        session.Update(orderUpdate);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="OrderDB"/></returns>
        OrderDB IDataRepository<OrderDB>.Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetAll method will retrieve all the orders that exists into the database
        /// </summary>
        /// <returns>The <see cref="IEnumerable{OrderDB}"/></returns>
        IEnumerable<OrderDB> IDataRepository<OrderDB>.GetAll()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var orders = session.Query<ClientOrder>().ToList();
                    return Converters.Cast(orders);
                }
            }
        }
    }
}
