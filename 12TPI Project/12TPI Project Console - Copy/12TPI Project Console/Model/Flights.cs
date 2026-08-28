using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class Flights //Creates a public class for the 'Flights' table of the database
    {
        public int FlightID { get; set; }
        public int PlaneRegistrationID { get; set; }
        public String FlightNumber { get; set; }
        public String PilotName { get; set; }
        public DateTime DepartingDateTime { get; set; } //Possibly incorrect datatype
        public String DepartingAirport { get; set; }
        public DateTime ArrivingDateTime { get; set; } //Possibly incorrect datatype
        public String ArrivingAirport { get; set; }
        public String Status { get; set; }
        public Flights() { } //Creates the constructor for the 'Flights' class
        public Flights(int fi /* = FlightID */, int pr /* = PlaneRegistrationID */, string fn /* = FlightNumber*/, string p /* = PilotName */, DateTime dt /* = DepartingDateTime */, string da /* = DepartingAirport */, DateTime at /* = ArrivingDateTime */, string aa /* = ArrivingAirport */, string s /* = Status */)
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
