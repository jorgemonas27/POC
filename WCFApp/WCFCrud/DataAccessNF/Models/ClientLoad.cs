using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessNF.Models
{
    public class ClientLoad
    {
        public virtual int IdLoad { get; set; }
        public virtual string TruckLoad { get; set; }
        public virtual IList<ClientShipment> Shipments { get; set; }
        public virtual string StopsLoad { get; set; }
        public virtual int TotalDistanceLoad { get; set; }
        public virtual int? TotalCostLoad { get; set; }
        public virtual int QuantityShipmentsLoad { get; set; }
    }
}
