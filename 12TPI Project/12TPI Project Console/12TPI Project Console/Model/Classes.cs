using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class Classes
    {
        public String ClassCode { get; set; }
        public String Name { get; set; }
        public String ChangesPermitted { get; set; }
        public int BaggageAllowance { get; set; }
        public String MilesAccural { get; set; }
        public Classes() { }
        public Classes(string c, string n, string p, int b, string m)
        {
            ClassCode = c;
            Name = n;
            ChangesPermitted = p;
            BaggageAllowance = b;
            MilesAccural = m;
        }
    }
}