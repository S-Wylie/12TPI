using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class TopPilotsStats
    {
        public int PilotPopularity { get; set; }

        public TopPilotsStats() { }
        public TopPilotsStats(int p)
        {
            PilotPopularity = p;
        }
    }
}
