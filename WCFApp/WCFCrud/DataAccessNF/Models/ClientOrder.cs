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
        public virtual string NameOrderField { get; set; }
        public virtual string DeliveryDateOrderField { get; set; }
    }
}
