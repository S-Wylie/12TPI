using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class MealOptions
    {
        public String MealCode { get; set; }
        public String Name { get; set; }
        public String Conditions { get; set; }
        public MealOptions() { }
        public MealOptions(string m, string n, string c)
        {
            MealCode = m;
            Name = n;
            Conditions = c;
        }
    }
}
