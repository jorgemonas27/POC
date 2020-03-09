using DataAccessNF.Models;
using DataAccessNF.Repositories;
using ModelsDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessNF.Operations
{
    public class TextOperation : IDataRepository<OrderDB>
    {
        public void Add(OrderDB newElement)
        {
            StreamWriter sw = new StreamWriter(@"C:\txt.log", false);
            sw.WriteLine(newElement);
            sw.Close();
        }

        public void AddList(IList<OrderDB> element)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDB Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDB> GetAll()
        {
            StreamReader sr = new StreamReader(@"C:/txt.log");
            string s = sr.ReadToEnd();
            sr.Close();
            return null;
        }

        public void Update(int id, OrderDB element)
        {
            throw new NotImplementedException();
        }
    }
}
