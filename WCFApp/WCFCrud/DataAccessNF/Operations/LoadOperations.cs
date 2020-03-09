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
    public class LoadOperations : IDataRepository<LoadDB>
    {
        public void Add(LoadDB newElement)
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

        public void AddList(IList<LoadDB> element)
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

        public void Delete(int id)
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var load = session.Get<LoadDB>(id);
                        session.Save(Converters.Cast(load));
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

        public LoadDB Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoadDB> GetAll()
        {
            try
            {
                using (var session = NHibernateSession.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        return Converters.Cast(session.Query<ClientLoad>().ToList());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(int id, LoadDB element)
        {
            throw new NotImplementedException();
        }
    }
}
