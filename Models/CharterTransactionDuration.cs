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
        public DateTime departureDate { get; set; }
        public override void calculateCost()
        {
            totalCost += aircraft.annualCost / 365 * charterDuration;
            if (extraCabin)
            {
                totalCost += cabinCostPerYear / 365 * charterDuration;
            }
            if (extraCaptain)
            {
                totalCost += captainCostPerYear / 365 * charterDuration;
            }
            if (extraOfficer)
            {
                totalCost += officerCostPerYear / 365 * charterDuration;
            }
            totalCost += (2000 / 365 * charterDuration) * aircraft.hourlyCost;
        }

        public override string ToString()
        {
            String returnString = "";
            returnString += "Customer Details: \n";
            returnString += customer.ToString() + "\n\n";
            returnString += "Trip Details: \n";
            returnString += "Charter Duration: " + charterDuration.ToString() + "\n\n";
            returnString += "Departure Date: " + departureDate + "\n";
            returnString += base.ToString();
            returnString += "\n\nAircraft Details: \n";
            returnString += aircraft.ToString() + "";
            return returnString;
        }
    }
}
