using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class Planes //Creates a public class for the 'Planes' table of the database 
    {
        public int RegistrationID { get; set; }
        public String Manufacturer { get; set; }
        public String Model { get; set; }
        public int PassengerCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public decimal MinimumTakeoff { get; set; }
        public decimal MinimumLanding { get; set; }
        public Planes() { } //Craetes the constructor for the 'Planes' class
        public Planes(int r /* = RegistartionID */, string ma /* = Manufacturer */, string mo /* = Model */, int p /* = PassengerCapcity */, int c /* = CargoCapacity */, decimal t /* = MinimumTakeoff */, decimal l /* = MinimumLanding*/)
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
