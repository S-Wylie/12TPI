using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class Logins //Creates a public class for the 'Logins' table of the database 
    {
        public String Username { get; set; }
        public int PINHash { get; set; }
        public char AccessLevel { get; set; }

        public Logins() { } //Creates the constructor for the 'Logins' class
        public Logins(string u /* = Username */, int p /* = PINHash */, char l /* = AccessLevel */)
        {
            Username = u;
            PINHash = p;
            AccessLevel = l;
        }
    }
}


