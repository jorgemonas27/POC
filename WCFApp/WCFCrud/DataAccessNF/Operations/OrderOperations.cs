using DataAccessNF.Converter;
using DataAccessNF.Models;
using DataAccessNF.Repositories;
using DataAccessNF.Services;
using ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessNF.Operations
{
    public class OrderOperations : IDataRepository<OrderDB>
    {
        public void Add(OrderDB newElement)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(Converters.CastForDB(newElement));
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
        public void Update(int id, OrderDB element)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var orderUpdate = session.Get<OrderDB>(Convert.ToInt32(id));
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
                        orderUpdate.IdLoad = element.IdLoad;
                        orderUpdate.IdShipment = element.IdShipment;
                        orderUpdate.Status = element.Status;
                        session.Update(Converters.CastForDB(orderUpdate));
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

        OrderDB IDataRepository<OrderDB>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<OrderDB> IDataRepository<OrderDB>.GetAll()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                var orders = session.Query<ClientOrder>().ToList();
                return Converters.CastForBL(orders);
            }
        }
    }
}
