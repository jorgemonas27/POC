using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelsDTO
{
    public class ShipmentDTO
    {
        [Key]
        public int IdShipment { get; set; }
        public int Quantity { get; set; }
        public IList<OrderDTO> Orders { get; set; }
    }
}