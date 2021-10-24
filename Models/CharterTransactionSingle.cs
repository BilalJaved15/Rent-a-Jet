﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CharterTransactionSingle : CharterTransaction
    {
        public string departurePlace { get; set; }
        public string destinationPlace { get; set; }
        public DateTime departureDate { get; set; }
        public int travellingAmount { get; set; }
    }
}
