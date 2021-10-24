using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PersonnelCost
    {
        public int id { get; set; }
        public string role { get; set; }
        public Double salary { get; set; }

        public PersonnelCost()
        {
        }

        public PersonnelCost(int id, string role, Double salary)
        {
            this.id = id;
            this.role = role;
            this.salary = salary;
        }

        public override string ToString()
        {
            String returnString = "";
            returnString += ("  Role: " + this.role + "\n");
            returnString += ("Salary: " + this.salary.ToString("C", CultureInfo.CurrentCulture) + "\n");
            return returnString;
        }
    }
}
