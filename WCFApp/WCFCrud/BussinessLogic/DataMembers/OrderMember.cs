﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DataMembers
{
    public class OrderMember
    {
        public int IdOrder { get; set; }
        public string NameCompany { get; set; }
        public string OriginCountry { get; set; }
        public string OriginState { get; set; }
        public string OriginCity { get; set; }
        public string OriginAddress { get; set; }
        public string DestinationCountry { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationAddress { get; set; }
        public string DestinationState { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int? IdShipment { get; set; }
        public int? IdLoad { get; set; }
    }
}
