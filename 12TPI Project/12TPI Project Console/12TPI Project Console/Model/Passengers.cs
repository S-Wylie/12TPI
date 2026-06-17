using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class Passengers
    {
        public int CustomerID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MembershipStatus { get; set; }
        public Passengers() { }
        public Passengers(int c, string f, string l, string m)
        {
            CustomerID = c;
            FirstName = f;
            LastName = l;
            MembershipStatus = m;
        }
    }
}
