namespace DataAccessNF.Operations
{
    using DataAccessNF.Repositories;
    using ModelsDB;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Defines the <see cref="TextOperation" />
    /// </summary>
    public class TextOperation : IDataRepository<OrderDB>
    {
        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="newElement">The newElement<see cref="OrderDB"/></param>
        public void Add(OrderDB newElement)
        {
            StreamWriter sw = new StreamWriter(@"C:\txt.log", false);
            sw.WriteLine(newElement.IdShipment.ToString());
            sw.WriteLine(newElement.NameCompany);
            sw.WriteLine(newElement.Status);
            sw.WriteLine(newElement.OriginAddress);
            sw.WriteLine(newElement.OriginState);
            sw.WriteLine(newElement.OriginCountry);
            sw.WriteLine(newElement.OriginCity);
            sw.WriteLine(newElement.OriginCity);
            sw.WriteLine(newElement.DestinationAddress);
            sw.WriteLine(newElement.DestinationCity);
            sw.WriteLine(newElement.DestinationCountry);
            sw.WriteLine(newElement.DestinationState);
            sw.WriteLine(newElement.Description);
            sw.WriteLine(newElement.CostOrder.ToString());
            sw.WriteLine(newElement.WeigthOrder.ToString());
            sw.Close();
        }

        /// <summary>
        /// The AddList
        /// </summary>
        /// <param name="element">The element<see cref="IList{OrderDB}"/></param>
        public void AddList(IList<OrderDB> element)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="OrderDB"/></returns>
        public OrderDB Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="IEnumerable{OrderDB}"/></returns>
        public IEnumerable<OrderDB> GetAll()
        {
            StreamReader sr = new StreamReader(@"C:/txt.log");
            string s = sr.ReadToEnd();
            sr.Close();
            return null;
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="element">The element<see cref="OrderDB"/></param>
        public void Update(int id, OrderDB element)
        {
            throw new NotImplementedException();
        }
    }
}
