﻿using DataAccessNF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFCrudUtililies.Global.Repositories;

namespace WCFCrudUtililies.Global.DataManager
{
    public class ShipmentManager : IDataRepository<ClientShipment>
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
