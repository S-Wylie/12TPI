using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class Passengers //Creates a public class for the 'Passengers' table of the database
    {
        public int CustomerID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MembershipStatus { get; set; }
        public Passengers() { } //Creates the constructor for the 'Passengers' class
        public Passengers(int c /* = CustomerID */, string f /* = FirstName */ , string l /* = LastName */ , string m /* = MembershipStatus */)
        {
            CustomerID = c;
            FirstName = f;
            LastName = l;
            MembershipStatus = m;
        }
    }
}
