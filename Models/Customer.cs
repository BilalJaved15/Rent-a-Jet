using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int transactionType { get; set; }

        public Customer() { }

        public override String ToString()
        {
            String returnString = "";
            returnString += "           Name: " + name;
            returnString += "\n          Email: " + email;
            returnString += "\n          Phone: " + phone;
            returnString += "\nTransation Type: ";
            if (transactionType == 1)
            {
                returnString += "Single Flight\n";
            }
            else if (transactionType == 2)
            {
                returnString += "Flight With Stopovers\n";
            }
            else if (transactionType == 3)
            {
                returnString += "Time Charter\n";
            }
            return returnString;
        }
    }
}
