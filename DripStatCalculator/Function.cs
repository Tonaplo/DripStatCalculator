using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DripStatCalculator
{
    public static class Function
    {
        //Multiplier
        public static double Multiplier = 1.1d;

        //Starting Prices in bytes
        public static int StartingPriceCursor = 20;
        public static int StartingPriceBrogrammer = 100;
        public static int StartingPriceGCFailure = 500;
        public static int StartingPriceMemoryLeak = 2000;
        public static int StartingPriceMessageQueue = 10000;
        public static int StartingPriceDatabase = 100000;
        public static int StartingPriceCache = 1000000;
        public static int StartingPriceCPU = 10000000;
        public static int StartingPriceGPU = 50000000;
        public static int StartingPriceCluster = 500000000;

        //Starting bytes per second
        public static int StartingBPSCursor = 1;
        public static int StartingBPSBrogrammer = 3;
        public static int StartingBPSGCFailure = 5;
        public static int StartingBPSMemoryLeak = 8;
        public static int StartingBPSMessageQueue = 15;
        public static int StartingBPSDatabase = 60;
        public static int StartingBPSCache = 200;
        public static int StartingBPSCPU = 0;
        public static int StartingBPSGPU = 0;
        public static int StartingBPSCluster = 0;
    }
}
