using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class Flights
    {
        public int FlightID { get; set; }
        public int PlaneRegistrationID { get; set; }
        public int FlightNumber { get; set; }
        public String PilotName { get; set; }
        public DateTime DepartingDateTime { get; set; }
        public String DepartingAirport { get; set; }
        public DateTime ArrivingDateTime { get; set; }
        public String ArrivingAirport { get; set; }
        public String Status { get; set; }
        public Flights() { }
        public Flights(int fi, int pr, int fn, string p, DateTime dt, string da, DateTime at, string aa, string s)
        {
            FlightID = fi;
            PlaneRegistrationID = pr;
            FlightNumber = fn;
            PilotName = p;
            DepartingDateTime = dt;
            DepartingAirport = da;
            ArrivingDateTime = at;
            ArrivingAirport = aa;
            Status = s;
        }
    }
}
