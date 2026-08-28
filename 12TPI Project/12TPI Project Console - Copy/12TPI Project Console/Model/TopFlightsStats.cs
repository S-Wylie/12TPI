using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class TopFlightsStats
    {
        public int FlightPopularity { get; set; }

        public TopFlightsStats() { }
        public TopFlightsStats(int f)
        {
            FlightPopularity = f;
        }
    }
}
