using System;
using System.Collections.Generic;
using System.Text;

namespace _12TPI_Project_Console.Model
{
    public class AvgPlaneCapStats
    {

        public int PassengerCapAvg { get; set; }
        public int CargoCapAvg { get; set; }

        public AvgPlaneCapStats() { }
        public AvgPlaneCapStats(int p, int c)
        {
            PassengerCapAvg = p;
            CargoCapAvg = c;
        }

    }
}
