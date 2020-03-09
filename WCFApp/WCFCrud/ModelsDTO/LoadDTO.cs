using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelsDTO
{
    public class LoadDTO
    {
        [Key]
        public int IdLoad { get; set; }
        public string TruckLoad { get; set; }
        public IList<ShipmentDTO> Shipments { get; set; }
        public string StopsLoad { get; set; }
        public int TotalDistanceLoad { get; set; }
        public int? TotalCostLoad { get; set; }
        public int QuantityShipmentsLoad { get; set; }
    }
}