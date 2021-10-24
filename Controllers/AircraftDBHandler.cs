using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;

namespace Controllers
{
    public static class AircraftDBHandler
    {
        public static Aircraft GetAircraftById(int id)
        {
            Aircraft aircraft = new Aircraft();
            string constr = "Data Source=DESKTOP-LPV1QVS;Initial Catalog=EAD_JET;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "select * from AIRCRAFTS id = " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    aircraft.id = Convert.ToInt32(reader[0]);
                    aircraft.quantity = Convert.ToInt32(reader[1]);
                    aircraft.manufacturer = Convert.ToString(reader[2]);
                    aircraft.type = Convert.ToString(reader[3]);
                    aircraft.crewFlight = Convert.ToInt32(reader[4]);
                    aircraft.cabin = Convert.ToInt32(reader[5]);
                    aircraft.range = Convert.ToInt32(reader[6]);
                    aircraft.capacity = Convert.ToInt32(reader[7]);
                    aircraft.cruisingSpeed = Convert.ToString(reader[8]);
                    aircraft.engines = Convert.ToInt32(reader[9]);
                    aircraft.engineType = Convert.ToString(reader[10]);
                    aircraft.annualCost = Convert.ToDouble(reader[11]);
                    aircraft.hourlyCost = Convert.ToDouble(reader[12]);
                }
            }
            return aircraft;
        }

        public static List<Aircraft> getAllAircrafts()
        {
            List<Aircraft> aircrafts = new List<Aircraft>();
            string constr = "Data Source=DESKTOP-LPV1QVS;Initial Catalog=EAD_JET;Integrated Security=True";
            int index = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "select * from AIRCRAFTS where quantity > 0";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aircrafts.Add(new Aircraft());
                    aircrafts[index].id = Convert.ToInt32(reader[0]);
                    aircrafts[index].quantity = Convert.ToInt32(reader[1]);
                    aircrafts[index].manufacturer = aircrafts[index].manufacturer = Convert.ToString(reader[2]).Trim();
                    aircrafts[index].type = aircrafts[index].type = Convert.ToString(reader[3]).Trim();
                    aircrafts[index].crewFlight = Convert.ToInt32(reader[4]);
                    aircrafts[index].cabin = Convert.ToInt32(reader[5]);
                    aircrafts[index].range = Convert.ToInt32(reader[6]);
                    aircrafts[index].capacity = Convert.ToInt32(reader[7]);
                    aircrafts[index].cruisingSpeed = Convert.ToString(reader[8]);
                    aircrafts[index].engines = Convert.ToInt32(reader[9]);
                    aircrafts[index].engineType = Convert.ToString(reader[10]);
                    aircrafts[index].annualCost = Convert.ToDouble(reader[11]);
                    aircrafts[index].hourlyCost = Convert.ToDouble(reader[12]);
                    aircrafts[index].type = aircrafts[index].type.Replace('\n', ' ');
                    aircrafts[index].type = aircrafts[index].type.Replace('\r', ' ');
                    aircrafts[index].type = aircrafts[index].type.Replace("  ", "");
                    index++;
                }
            }
            return aircrafts;
        }

        public static List<Aircraft> getAircraftsByCapacity(int lowerBound)
        {
            List<Aircraft> aircrafts = new List<Aircraft>();
            string constr = "Data Source=DESKTOP-LPV1QVS;Initial Catalog=EAD_JET;Integrated Security=True";
            int index = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string query = "select * from AIRCRAFTS where quantity > 0 and CAPACITY >= " + lowerBound;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aircrafts.Add(new Aircraft());
                    aircrafts[index].id = Convert.ToInt32(reader[0]);
                    aircrafts[index].quantity = Convert.ToInt32(reader[1]);
                    aircrafts[index].manufacturer = aircrafts[index].manufacturer = Convert.ToString(reader[2]).Trim();
                    aircrafts[index].type = aircrafts[index].type = Convert.ToString(reader[3]).Trim();
                    aircrafts[index].crewFlight = Convert.ToInt32(reader[4]);
                    aircrafts[index].cabin = Convert.ToInt32(reader[5]);
                    aircrafts[index].range = Convert.ToInt32(reader[6]);
                    aircrafts[index].capacity = Convert.ToInt32(reader[7]);
                    aircrafts[index].cruisingSpeed = Convert.ToString(reader[8]);
                    aircrafts[index].engines = Convert.ToInt32(reader[9]);
                    aircrafts[index].engineType = Convert.ToString(reader[10]);
                    aircrafts[index].annualCost = Convert.ToDouble(reader[11]);
                    aircrafts[index].hourlyCost = Convert.ToDouble(reader[12]);
                    aircrafts[index].type = aircrafts[index].type.Replace('\n', ' ');
                    aircrafts[index].type = aircrafts[index].type.Replace('\r', ' ');
                    aircrafts[index].type = aircrafts[index].type.Replace("  ", "");
                    index++;
                }
            }
            return aircrafts;
        }
    }
}
