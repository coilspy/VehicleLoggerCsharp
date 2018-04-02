using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcykelLoggerConsole
{
    class Vehicle
    {

        public String Name { get; set; }
        public int Year { get; set; }
        public int Miles;
        public int MilesOfLastService { get; set; }
        public int ServiceInterval { get; set; }
        private int milesOfNextService;
        public int MilesSinceLastService;


        public Vehicle(String name, int year, int miles, int serviceInterval, int milesSinceLastService)
        {
            this.Name = name;
            this.Year = year;
            this.MilesOfLastService = miles;
            this.Miles = miles;
            this.milesOfNextService = miles + serviceInterval;
            this.ServiceInterval = serviceInterval;
            this.MilesSinceLastService = milesSinceLastService;
        }
  /*      public Vehicle(String name, int year, int miles, int serviceInterval, int milesOfLastService)
        {
            this.Name = name;
            this.Year = year;
            this.MilesOfLastService = MilesOfLastService;
            this.Miles = miles;
            this.ServiceInterval = serviceInterval;
        }*/



        public int getMilesSinceLastService()
        {
            return MilesSinceLastService;
        }
        public string getMilesToNextService()
        {
            int milesToNextService = ServiceInterval - getMilesSinceLastService();
            if (milesToNextService < 0)
            {
                return "0, överväg att utföra service så snart som möjligt.";
            }
            else
            {
                return milesToNextService.ToString();
            } 
        }
        
        public void ServiceDoneAtMiles(int miles)
        {
            MilesSinceLastService = 0;
            this.MilesOfLastService = miles;  
            setMiles(miles);
            this.milesOfNextService = miles + ServiceInterval;
        }


        public void setMiles(int miles)
        {
            MilesSinceLastService = (miles - MilesOfLastService);
            milesOfNextService -= (miles - this.Miles);
            this.Miles = miles;
        }


        public override string ToString()
        {
            return (this.Name + " - " + this.Year + "\nMiles: " + this.Miles + "\nMiles to service: " + getMilesToNextService() +  "\nMiles since last service: " + getMilesSinceLastService() +"\n");
        }

        public string ToFileString()
        {
            return (this.Name + " " + this.Year + " " + this.Miles + " " + this.ServiceInterval + " " + this.getMilesSinceLastService().ToString());
        }
    }
}
