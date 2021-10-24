using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Aircraft
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public string manufacturer {  get; set; }
        public string type {  get; set; }
        public int crewFlight { get; set; }
        public int cabin { get; set; }
        public int range {  get; set; }
        public string cruisingSpeed { get; set; }
        public int capacity {  get; set; }
        public int engines {  get; set; }
        public string engineType { get; set; }
        public Double annualCost { get; set; }
        public Double hourlyCost { get; set; }

        public Aircraft() { }

        public Aircraft(int id, int quantity, string manufacturer, string type, int crewFlight,
            int cabin, int range, int capacity, int engines, Double annualCost, Double hourlyCost) {
            this.id = id;
            this.quantity = quantity;
            this.manufacturer = manufacturer;
            this.type = type;
            this.crewFlight = crewFlight;
            this.cabin = cabin;
            this.range = range;
            this.capacity = capacity;
            this.engines = engines;
            this.annualCost = annualCost;
            this.hourlyCost = hourlyCost;
        }

        public override String ToString() {
            String returnString = "";
            returnString += ("ID: " + this.id.ToString() + "\n");
            returnString += ("Quantity: " + this.quantity.ToString() + "\n");
            returnString += ("Manufacturer: " + this.manufacturer + "\n");
            returnString += ("Type: " + this.type + "\n");
            returnString += ("Crew Flight: " + this.crewFlight.ToString() + "\n");
            returnString += ("Cabin: " + this.cabin.ToString() + "\n");
            returnString += ("Range: " + this.range.ToString() + " km" + "\n");
            returnString += ("Capacity: " + this.capacity.ToString() + "\n");
            returnString += ("Cruising Speed: " + this.cruisingSpeed.ToString() + " km/h" + "\n");
            returnString += ("Engines: " + this.engines.ToString() + "\n");
            returnString += ("Engine Type: " + this.engineType + "\n");
            returnString += ("Annual Fixed Cost: " + this.annualCost.ToString("C", CultureInfo.CurrentCulture) + "\n");
            returnString += ("Hourly Cost: " + this.hourlyCost.ToString("C", CultureInfo.CurrentCulture) + "\n\n");
            return returnString;
        }
    }
}
