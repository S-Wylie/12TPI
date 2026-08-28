using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class Classes //Creates a public class for the 'Classes' table of the database
    {
        public String ClassCode { get; set; }
        public String Name { get; set; }
        public String ChangesPermitted { get; set; }
        public int BaggageAllowance { get; set; }
        public String MilesAccrual { get; set; }
        public Classes() { } //Creates the constructor for the 'Classes' class
        public Classes(string c /* = ClassCode */, string n /* = Name */, string p /* = ChangesPermitted */, int b /* = BaggageAllowance */ , string m /* = MilesAccrual */)
        {
            ClassCode = c;
            Name = n;
            ChangesPermitted = p;
            BaggageAllowance = b;
            MilesAccrual = m;
        }
    }
}