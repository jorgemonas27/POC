using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessNF.Repositories
{
    public interface IDataRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T newElement);
        void Update(int id, T element);
        void Delete(int id);

    }
}
