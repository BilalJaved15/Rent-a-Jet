using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CharterTransactionDuration : CharterTransaction
    {
        public int charterDuration { get; set; }

        public override void calculateCost()
        {
        }

        public override string ToString()
        {
            String returnString = "";
            returnString += "Customer Details: \n";
            returnString += customer.ToString() + "\n\n";
            returnString += "Trip Details: \n";
            returnString += "Charter Duration: " + charterDuration.ToString() + "\n\n";
            returnString += base.ToString();
            returnString += "\n\nAircraft Details: \n";
            returnString += aircraft.ToString() + "";
            return returnString;
        }
    }
}
