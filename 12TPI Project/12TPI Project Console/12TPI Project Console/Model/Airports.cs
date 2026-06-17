using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class Airports
    {
        public int IATACode { get; set; }
        public String Name { get; set; }
        public String Coordinates { get; set; }
        public String Country { get; set; }
        public String Timezone { get; set; }
        public Airports() { }
        public Airports(int i, string n, string cor, string con, string t)
        {
            IATACode = i;
            Name = n;
            Coordinates = cor;
            Country = con;
            Timezone = t;
        }
    }
}
