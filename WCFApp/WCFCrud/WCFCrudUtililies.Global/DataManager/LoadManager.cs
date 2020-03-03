using DataAccessNF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFCrudUtililies.Global.Repositories;

namespace WCFCrudUtililies.Global.DataManager
{
    public class LoadManager : IDataRepository<ClientLoad>
    {
        public void Add(ClientLoad newElement)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ClientLoad Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientLoad> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ClientLoad element)
        {
            throw new NotImplementedException();
        }
    }
}
