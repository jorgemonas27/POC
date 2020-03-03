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
        public virtual string Destination { get; set; }
    }
}
