using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class Planes
    {
        public int RegistrationID { get; set; }
        public String Manufacturer { get; set; }
        public String Model { get; set; }
        public int PassengerCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public decimal MinimumTakeoff { get; set; }
        public decimal MinimumLanding { get; set; }
        public Planes() { }
        public Planes(int r, string ma, string mo, int p, int c, decimal t, decimal l)
        {
            RegistrationID = r;
            Manufacturer = ma;
            Model = mo;
            PassengerCapacity = p;
            CargoCapacity = c;
            MinimumTakeoff = t;
            MinimumLanding = l;
        }
    }
}
