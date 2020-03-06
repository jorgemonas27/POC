﻿using DataAccessNF.Converter;
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
            throw new NotImplementedException();
        }

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
                            transaction.Commit();
                        }
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
