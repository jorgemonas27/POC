using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDB
{
    public class ShipmentDB
    {
        public int IdShipment { get; set; }
        public int Quantity { get; set; }
        public int TotalWeigthOrders { get; set; }
        public int? IdLoad { get; set; }
        public IList<OrderDB> Orders { get; set; }
    }
}
