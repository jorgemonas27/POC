using DataAccessNF.Models;
using DataAccessNF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFCrudUtililies.Global.Repositories;

namespace WCFCrudUtililies.Global.DataManager
{
    public class OrderManager : IDataRepository<ClientOrder>
    {
        public void Add(ClientOrder newElement)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(newElement);
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

        public ClientOrder Get(int id)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                       var order = session.Get<ClientOrder>(Convert.ToInt32(id));
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

        public IEnumerable<ClientOrder> GetAll()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                var orders = session.Query<ClientOrder>().ToList();
                return orders;
            }
        }

        public void Update(int id, ClientOrder element)
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
                        orderUpdate.IdLoad = element.IdLoad;
                        orderUpdate.IdShipment = element.IdShipment;
                        orderUpdate.Status = element.Status;
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
    }
}
