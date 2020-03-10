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
    /// Defines the <see cref="ShipmentOperations" />
    /// </summary>
    public class ShipmentOperations : IDataRepository<ShipmentDB>
    {
        /// <summary>
        /// The Add method will save a new shipment into the database
        /// </summary>
        /// <param name="newElement">The newElement<see cref="ShipmentDB"/></param>
        public void Add(ShipmentDB newElement = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The AddList will add a list of shipments into the database
        /// </summary>
        /// <param name="element">The element<see cref="IList{ShipmentDB}"/></param>
        public void AddList(IList<ShipmentDB> element)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        foreach (var item in element)
                        {
                            session.Save(Converters.Cast(item));
                        }
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
        /// The Delete method will delete a certain shipment from the database
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
                        var shipment = session.Get<ClientShipment>(Convert.ToInt32(id));
                        session.Delete(shipment);
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
        /// The Get method will retrieve a certain shipment by the id
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ShipmentDB"/></returns>
        public ShipmentDB Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetAll method will retrieve all the shipments that exists into the database
        /// </summary>
        /// <returns>The <see cref="IEnumerable{ShipmentDB}"/></returns>
        public IEnumerable<ShipmentDB> GetAll()
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var list = session.Query<ClientShipment>().ToList();
                        return Converters.Cast(list);
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
        /// The Update method will update a certain shipment of the database
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="element">The element<see cref="ShipmentDB"/></param>
        public void Update(int id, ShipmentDB element)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var shipmentUpdate = session.Get<ClientShipment>(id);
                        shipmentUpdate.IdShipment = element.IdShipment;
                        shipmentUpdate.Orders = Converters.Cast(element.Orders);
                        shipmentUpdate.QuantityOrders = element.Quantity;
                        shipmentUpdate.TotalWeigthOrders = element.TotalWeigthOrders;
                        shipmentUpdate.IdLoad = element.IdLoad;
                        session.Update(shipmentUpdate);
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
    }
}
