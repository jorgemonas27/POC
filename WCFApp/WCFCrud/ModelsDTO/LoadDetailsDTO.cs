using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDTO
{
    public class LoadDetailsDTO
    {
        public int IdLoad { get; set; }
        public int? IdShipment { get; set; }
        public int? IdOrder { get; set; }
        public string NameCompany { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationState { get; set; }
        public string Status { get; set; }
        public int TotalWeigthOrders { get; set; }
        public int NumberOfOrders { get; set; }
        public string TruckLoad { get; set; }
        public string StopsLoad { get; set; }
        public int TotalDistanceLoad { get; set; }
        public int? TotalCostLoad { get; set; }
        public int QuantityShipmentsLoad { get; set; }
    }
}
