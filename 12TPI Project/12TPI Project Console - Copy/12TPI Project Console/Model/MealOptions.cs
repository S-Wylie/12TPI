using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class MealOptions //Creates a public class for the 'MealOptions' table of the database
    {
        public String MealCode { get; set; }
        public String Name { get; set; }
        public String Conditions { get; set; }
        public MealOptions() { } //Creates the constructor for the 'MealOptions' class
        public MealOptions(string m /* = MealCode */, string n /* = Name */, string c /* = Conditions*/)
        {
            MealCode = m;
            Name = n;
            Conditions = c;
        }
    }
}
