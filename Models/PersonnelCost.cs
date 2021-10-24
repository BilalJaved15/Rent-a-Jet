using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class PersonnelCost
    {
        public int id { get; set; }
        public string role { get; set; }
        public float salary { get; set; }

        public PersonnelCost(int id, string role, float salary) {
            this.id = id;
            this.role = role;
            this.salary = salary;
        }
    }
}
