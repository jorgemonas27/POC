using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Managers
{
    public interface IManager<T> where T:class 
    {
        IList<T> GetAll();
        string Save(T element);
        string Update(int id, T updateElement);
        string Delete(int id);
        IList<T> Consolidate();
        IList<T> Build();
        IEnumerable<ShipmentDetailsDTO> GetDetails();
        IEnumerable<LoadDetailsDTO> GetLoadDetails();
    }
}
