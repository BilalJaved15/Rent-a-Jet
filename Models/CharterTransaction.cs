using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class CharterTransaction
    {
        public Customer customer { get; set; }
        public Aircraft aircraft { get; set; }
        public Double totalCost { get; set; }
        public bool extraCaptain { get; set; }
        public bool extraOfficer { get; set; }
        public bool extraCabin { get; set; }
        public static int captainCostPerYear = 10000000;
        public static int officerCostPerYear = 5500000;
        public static int cabinCostPerYear = 3300000;


        public abstract void calculateCost();

        public override String ToString() {
            String returnString = "";
            returnString += "            Total Cost: " + totalCost.ToString("C", CultureInfo.CurrentCulture) + "\n";
            returnString += "     Extra Flight Crew: " + (extraCaptain || extraOfficer ? "Yes\n" : "No\n");
            returnString += "Extra Flight Attendant: " + (extraCabin ? "Yes\n" : "No\n");
            return returnString;
        }
    }
}
