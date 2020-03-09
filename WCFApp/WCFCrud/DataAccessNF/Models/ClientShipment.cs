using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessNF.Models
{
    public class ClientShipment
    {
        public virtual int IdShipment { get; set; }
        public virtual int QuantityOrders { get; set; }
        public virtual int TotalWeigthOrders { get; set; }
        public virtual IList<ClientOrder> Orders { get; set; }
    }
}
