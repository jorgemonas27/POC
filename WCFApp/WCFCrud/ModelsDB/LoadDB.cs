using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDB
{
    public class LoadDB
    {
        public int IdLoad { get; set; }
        public string TruckLoad { get; set; }
        public IList<ShipmentDB> Shipments { get; set; }
        public string StopsLoad { get; set; }
        public virtual int TotalDistanceLoad { get; set; }
        public int? TotalCostLoad { get; set; }
        public int QuantityShipmentsLoad { get; set; }
    }
}
