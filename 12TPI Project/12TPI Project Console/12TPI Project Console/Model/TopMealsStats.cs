using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class TopMealsStats
    {
        public int MealPopularity { get; set; }

        public TopMealsStats() { }
        public TopMealsStats(int m)
        {
            MealPopularity = m;
        }
    }
}
