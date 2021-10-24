using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CharterTransactionStops : CharterTransaction
    {
        public string departurePlace { get; set; }
        public string destinationPlace { get; set; }
        public DateTime departureDate { get; set; }
        public List<String> stopovers { get; set; }
        public int lengthOfStay { get; set; }
        public int travellingAmount { get; set; }

        public override void calculateCost()
        {
            int origStay = lengthOfStay;
            lengthOfStay = lengthOfStay * 1440;
            lengthOfStay += (45 * stopovers.Count) / 1440;
            totalCost += (aircraft.annualCost / 365) / 1440 * lengthOfStay;
            if (extraCabin)
            {
                totalCost += (cabinCostPerYear / 365) / 1440 * lengthOfStay;
            }
            if (extraCaptain)
            {
                totalCost += (captainCostPerYear / 365) / 1440 * lengthOfStay;
            }
            if (extraOfficer)
            {
                totalCost += (officerCostPerYear / 365) / 1440 * lengthOfStay;
            }
            totalCost += ((2000 / 365) * (lengthOfStay / 1440)) * aircraft.hourlyCost;
            lengthOfStay = origStay;
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
            returnString += "No. of Stops: " + stopovers.Count + "\n";
            int index = 1;
            foreach (String stopover in stopovers)
            {
                returnString += "Stop " + index + ": " + stopover + "\n";
                index++;
            }
            returnString += "Length of Stay: " + lengthOfStay + "\n";
            returnString += "No. of People: " + travellingAmount + "\n";
            returnString += base.ToString();
            returnString += "\n\nAircraft Details: \n";
            returnString += aircraft.ToString() + "";
            return returnString;
        }

    }
}
