using System;
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

        public override void calculateCost()
        {
            totalCost += aircraft.annualCost / 365 * 1;
            if (extraCabin)
            {
                totalCost += cabinCostPerYear / 365 * 1;
            }
            if (extraCaptain)
            {
                totalCost += captainCostPerYear / 365 * 1;
            }
            if (extraOfficer)
            {
                totalCost += officerCostPerYear / 365 * 1;
            }
            totalCost += (2000 / 365 * 1) * aircraft.hourlyCost;
        }

        public override string ToString()
        {
            String returnString = "";
            returnString += "Customer Details: \n";
            returnString += customer.ToString() + "\n\n";
            returnString += "Trip Details: \n";
            returnString += "Departure Place: " + departurePlace + "\n";
            returnString += "Destination Date: " + destinationPlace + "\n";
            returnString += "Departure Date: " + departureDate + "\n";
            returnString += "No. of People: " + travellingAmount + "\n\n";
            returnString += base.ToString();
            returnString += "\n\nAircraft Details: \n";
            returnString += aircraft.ToString() + "";
            return returnString;
        }
    }
}