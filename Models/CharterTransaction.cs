using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class CharterTransaction
    {
        public Customer customer { get; set; }
        public Aircraft aircraft { get; set; }
    }
}
