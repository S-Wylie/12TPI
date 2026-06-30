using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class Airports //Creates a public class for the 'Airports' table of the database
    {
        public int IATACode { get; set; }
        public String Name { get; set; }
        public String Coordinates { get; set; }
        public String Country { get; set; }
        public String Timezone { get; set; }
        public Airports() { } //Creates the constructor for the 'Passengers' class
        public Airports(int i /* = IATACode */, string n /* = Name */, string cor /* = Coordinates */, string con /* = Country */ , string t /* Timezone */)
        {
            IATACode = i;
            Name = n;
            Coordinates = cor;
            Country = con;
            Timezone = t;
        }
    }
}
