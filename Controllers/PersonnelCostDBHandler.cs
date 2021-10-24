using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public static class PersonnelCostDBHandler
    {
        public static PersonnelCost GetPersonnelById(int id)
        {
            PersonnelCost personnel = new PersonnelCost();
            string constr = "Data Source=DESKTOP-LPV1QVS;Initial Catalog=EAD_JET;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "select * from [PERSONNEL-COST] where id = " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    personnel.id = Convert.ToInt32(reader[0]);
                    personnel.role = Convert.ToString(reader[1]);
                    personnel.salary = Convert.ToDouble(reader[2]);
                }
            }
            return personnel;
        }

        public static List<PersonnelCost> GetAllPersonnels()
        {
            List<PersonnelCost> personnels = new List<PersonnelCost>();
            string constr = "Data Source=DESKTOP-LPV1QVS;Initial Catalog=EAD_JET;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "select * from [PERSONNEL-COST]";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int index = 0;
                while (reader.Read())
                {
                    personnels[index].id = Convert.ToInt32(reader[0]);
                    personnels[index].role = Convert.ToString(reader[1]);
                    personnels[index].salary = Convert.ToDouble(reader[2]);
                    index++;
                }
            }
            return personnels;
        }

        public static PersonnelCost GetPersonnelByRole(string role)
        {
            PersonnelCost personnel = new PersonnelCost();
            string constr = "Data Source=DESKTOP-LPV1QVS;Initial Catalog=EAD_JET;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "select * from [PERSONNEL-COST] where role = " + role;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    personnel.id = Convert.ToInt32(reader[0]);
                    personnel.role = Convert.ToString(reader[1]);
                    personnel.salary = Convert.ToDouble(reader[2]);
                }
            }
            return personnel;
        }

    }
}
