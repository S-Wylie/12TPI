using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class Logins //Creates a public class for the 'Logins' table of the database 
    {
        public string Username { get; set; }
        public string PINHash { get; set; }
        public string AccessLevel { get; set; }

        public Logins() { } //Creates the constructor for the 'Logins' class
        public Logins(string u /* = Username */, string p /* = PINHash */, string l /* = AccessLevel */)
        {
            Username = u;
            PINHash = p;
            AccessLevel = l;
        }
    }
}


