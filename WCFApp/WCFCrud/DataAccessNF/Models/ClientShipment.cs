﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessNF.Models
{
    public class ClientShipment
    {
        public virtual int IdShipment { get; set; }
        public virtual int? IdLoad { get; set; }
        public virtual int Orders { get; set; }
    }
}
