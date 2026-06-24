using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class PassengerTickets //Creates a public class for the 'PassengerTickets' table of the database
    {
        public int TicketID { get; set; }
        public int FlightID { get; set; }
        public int CustomerID { get; set; }
        public String ClassName { get; set; }
        public String MealChoice { get; set; }
        public PassengerTickets() { } //Creates the constructor for the 'PassengerTickets' class
        public PassengerTickets(int t /* = TicketID */, int f /* = Flight ID */, int ci /* = Customer ID */, string cn /* = ClassName */, string m /* = MealChoice */)
        {
            TicketID = t;
            FlightID = f;
            CustomerID = ci;
            ClassName = cn;
            MealChoice = m;
        }
    }
}