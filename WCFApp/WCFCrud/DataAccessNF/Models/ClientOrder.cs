using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessNF.Models
{
    public class ClientOrder
    {
        public virtual int IdOrder { get; set; }
        public virtual string NameCompany { get; set; }
        public virtual string OriginCountry { get; set; }
        public virtual string OriginState { get; set; }
        public virtual string OriginCity { get; set; }
        public virtual string OriginAddress { get; set; }
        public virtual string DestinationCountry { get; set; }
        public virtual string DestinationCity { get; set; }
        public virtual string DestinationAddress { get; set; }
        public virtual string DestinationState { get; set; }
        public virtual string Status { get; set; }
        public virtual string Description { get; set; }
        public virtual int? IdShipment { get; set; } //nel
        public virtual int? IdLoad { get; set; } //nel
    }
}
