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
    /// Defines the <see cref="LoadOperations" />
    /// </summary>
    public class LoadOperations : IDataRepository<LoadDB>
    {
        /// <summary>
        /// The Add method will save a new load into the database
        /// </summary>
        /// <param name="newElement">The newElement<see cref="LoadDB"/></param>
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

        /// <summary>
        /// The AddList will add a list of loads into the database
        /// </summary>
        /// <param name="element">The element<see cref="IList{LoadDB}"/></param>
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

        /// <summary>
        /// The Delete method will delete a certain load from the database
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
                        var load = session.Get<ClientLoad>(id);
                        session.Delete(load);
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
        /// The Get method will retrieve a certain load by the id
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="LoadDB"/></returns>
        public LoadDB Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetAll method will retrieve all the loads that exists into the database
        /// </summary>
        /// <returns>The <see cref="IEnumerable{LoadDB}"/></returns>
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

        /// <summary>
        /// The Update method will update a certain load of the database
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="element">The element<see cref="LoadDB"/></param>
        public void Update(int id, LoadDB element)
        {
            throw new NotImplementedException();
        }
    }
}
