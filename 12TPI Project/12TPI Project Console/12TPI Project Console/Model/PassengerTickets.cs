using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class PassengerTickets
    {
        public int TicketID { get; set; }
        public int FlightID { get; set; }
        public int CustomerID { get; set; }
        public String ClassName { get; set; }
        public String MealChoice { get; set; }
        public PassengerTickets() { }
        public PassengerTickets(int t, int f, int ci, string cn, string m)
        {
            TicketID = t;
            FlightID = f;
            CustomerID = ci;
            ClassName = cn;
            MealChoice = m;
        }
    }
}