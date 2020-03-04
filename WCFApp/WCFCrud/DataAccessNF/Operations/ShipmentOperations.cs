using DataAccessNF.Models;
using DataAccessNF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessNF.Operations
{
    public class ShipmentOperations : IDataRepository<ClientShipment>
    {
        public void Add(ClientShipment newElement)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ClientShipment Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientShipment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ClientShipment element)
        {
            throw new NotImplementedException();
        }
    }
}
