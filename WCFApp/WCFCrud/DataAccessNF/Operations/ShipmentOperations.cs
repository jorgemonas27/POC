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
    public class ShipmentOperations : IDataRepository<ShipmentDB>
    {
        public void Add(ShipmentDB newElement = null)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        ClientShipment ship = new ClientShipment()
                        {
                            Orders = new List<ClientOrder>()
                            {
                               new ClientOrder()
                               {
                                    NameCompany = "lolo",
                                    OriginAddress = "lolo",
                                    OriginCity = "lolo",
                                    OriginState = "lolo",
                                    OriginCountry = "lolo",
                                    DestinationAddress = "lolo",
                                    DestinationCity = "lolo",
                                    DestinationCountry = "lolo",
                                    DestinationState = "lolo",
                                    Description = "lolo",
                                    Status = "lolo",
                               },
                               new ClientOrder()
                               {
                                    NameCompany = "lolo",
                                    OriginAddress = "lolo",
                                    OriginCity = "lolo",
                                    OriginState = "lolo",
                                    OriginCountry = "lolo",
                                    DestinationAddress = "lolo",
                                    DestinationCity = "lolo",
                                    DestinationCountry = "lolo",
                                    DestinationState = "lolo",
                                    Description = "lolo",
                                    Status = "lolo",
                               },
                               new ClientOrder()
                               {
                                    NameCompany = "lolo",
                                    OriginAddress = "lolo",
                                    OriginCity = "lolo",
                                    OriginState = "lolo",
                                    OriginCountry = "lolo",
                                    DestinationAddress = "lolo",
                                    DestinationCity = "lolo",
                                    DestinationCountry = "lolo",
                                    DestinationState = "lolo",
                                    Description = "lolo",
                                    Status = "lolo",
                               }
                            },
                            QuantityOrders = 3
                        };
                        session.Save(ship);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ShipmentDB Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShipmentDB> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ShipmentDB element)
        {
            throw new NotImplementedException();
        }
    }
}
