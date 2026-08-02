using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class TopCountriesStats
    {
        public int CountryPopularity { get; set; }

        public TopCountriesStats() { }
        public TopCountriesStats(int c)
        {
            CountryPopularity = c;
        }
    }
}
