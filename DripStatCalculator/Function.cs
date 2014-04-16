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
        public static decimal Multiplier = 1.1m;

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
        public static decimal StartingBPSCursor = 1.0m;
        public static decimal StartingBPSBrogrammer = 3.0m;
        public static decimal StartingBPSGCFailure = 5.0m;
        public static decimal StartingBPSMemoryLeak = 8.0m;
        public static decimal StartingBPSMessageQueue = 15.0m;
        public static decimal StartingBPSDatabase = 60.0m;
        public static decimal StartingBPSCache = 200.0m;
        public static decimal StartingBPSCPU = 800.0m;
        public static decimal StartingBPSGPU = 5000.0m;
        public static decimal StartingBPSCluster = 40000.0m;

        //Number of Upgrades
        public static int NumberOfCursorUpgrades = 7;
        public static int NumberOfBrogrammerUpgrades = 6;
        public static int NumberOfGCFailureUpgrades = 9;
        public static int NumberOfMemoryLeakUpgrades = 7;
        public static int NumberOfMessageQueueUpgrades = 8;
        public static int NumberOfDatabaseUpgrades = 9;
        public static int NumberOfCacheUpgrades = 7;
        public static int NumberOfCPUUpgrades = 10;
        public static int NumberOfGPUUpgrades = 6;
        public static int NumberOfClusterUpgrades = 6;

        //Cost of Upgrades
        public static decimal CursorUpgrade1 = 30.0m;
        public static decimal CursorUpgrade2 = 200.0m;
        public static decimal CursorUpgrade3 = 800.0m;
        public static decimal CursorUpgrade4 = 3000.0m;
        public static decimal CursorUpgrade5 = 15000.0m;
        public static decimal CursorUpgrade6 = 120000.0m;
        public static decimal CursorUpgrade7 = 20.0m;
        public static decimal BrogrammerUpgrade1 = 300.0m;
        public static decimal BrogrammerUpgrade2 = 1500.0m;
        public static decimal BrogrammerUpgrade3 = 4000.0m;
        public static decimal BrogrammerUpgrade4 = 25000.0m;
        public static decimal BrogrammerUpgrade5 = 20.0m;
        public static decimal BrogrammerUpgrade6 = 20.0m;
        public static decimal GCFailureUpgrade1 = 1000.0m;
        public static decimal GCFailureUpgrade2 = 8000.0m;
        public static decimal GCFailureUpgrade3 = 35000.0m;
        public static decimal GCFailureUpgrade4 = 20.0m;
        public static decimal GCFailureUpgrade5 = 20.0m;
        public static decimal GCFailureUpgrade6 = 20.0m;
        public static decimal GCFailureUpgrade7 = 20.0m;
        public static decimal GCFailureUpgrade8 = 20.0m;
        public static decimal GCFailureUpgrade9 = 20.0m;
        public static decimal MemoryLeakUpgrade1 = 6000.0m;
        public static decimal MemoryLeakUpgrade2 = 80000.0m;
        public static decimal MemoryLeakUpgrade3 = 20.0m;
        public static decimal MemoryLeakUpgrade4 = 20.0m;
        public static decimal MemoryLeakUpgrade5 = 20.0m;
        public static decimal MemoryLeakUpgrade6 = 20.0m;
        public static decimal MemoryLeakUpgrade7 = 20.0m;
        public static decimal MessageQueueUpgrade1 = 20.0m;
        public static decimal MessageQueueUpgrade2 = 20.0m;
        public static decimal MessageQueueUpgrade3 = 20.0m;
        public static decimal MessageQueueUpgrade4 = 20.0m;
        public static decimal MessageQueueUpgrade5 = 20.0m;
        public static decimal MessageQueueUpgrade6 = 20.0m;
        public static decimal MessageQueueUpgrade7 = 20.0m;
        public static decimal MessageQueueUpgrade8 = 20.0m;
        public static decimal DatabaseUpgrade1 = 20.0m;
        public static decimal DatabaseUpgrade2 = 20.0m;
        public static decimal DatabaseUpgrade3 = 20.0m;
        public static decimal DatabaseUpgrade4 = 20.0m;
        public static decimal DatabaseUpgrade5 = 20.0m;
        public static decimal DatabaseUpgrade6 = 20.0m;
        public static decimal DatabaseUpgrade7 = 20.0m;
        public static decimal DatabaseUpgrade8 = 20.0m;
        public static decimal DatabaseUpgrade9 = 20.0m;
        public static decimal CacheUpgrade1 = 20.0m;
        public static decimal CacheUpgrade2 = 20.0m;
        public static decimal CacheUpgrade3 = 20.0m;
        public static decimal CacheUpgrade4 = 20.0m;
        public static decimal CacheUpgrade5 = 20.0m;
        public static decimal CacheUpgrade6 = 20.0m;
        public static decimal CacheUpgrade7 = 20.0m;
        public static decimal CPUUpgrade1 = 20.0m;
        public static decimal CPUUpgrade2 = 20.0m;
        public static decimal CPUUpgrade3 = 20.0m;
        public static decimal CPUUpgrade4 = 20.0m;
        public static decimal CPUUpgrade5 = 20.0m;
        public static decimal CPUUpgrade6 = 20.0m;
        public static decimal CPUUpgrade7 = 20.0m;
        public static decimal CPUUpgrade8 = 20.0m;
        public static decimal CPUUpgrade9 = 20.0m;
        public static decimal CPUUpgrade10 = 20.0m;
        public static decimal GPUUpgrade1 = 20.0m;
        public static decimal GPUUpgrade2 = 20.0m;
        public static decimal GPUUpgrade3 = 20.0m;
        public static decimal GPUUpgrade4 = 20.0m;
        public static decimal GPUUpgrade5 = 20.0m;
        public static decimal GPUUpgrade6 = 20.0m;
        public static decimal ClusterUpgrade1 = 20.0m;
        public static decimal ClusterUpgrade2 = 20.0m;
        public static decimal ClusterUpgrade3 = 20.0m;
        public static decimal ClusterUpgrade4 = 20.0m;
        public static decimal ClusterUpgrade5 = 20.0m;
        public static decimal ClusterUpgrade6 = 20.0m;

        public static string Beautify(decimal number)
        {
            if (number / 1000000000000 >= 1)
                return decimal.Round(number / 1000000000000, 2).ToString();
            else if (number / 1000000000 >= 1)
                return decimal.Round(number / 1000000000, 2).ToString();
            else if (number / 1000000 >= 1)
                return decimal.Round(number / 1000000, 2).ToString();
            else if (number / 1000 >= 1)
                return decimal.Round(number / 1000, 2).ToString();

            return decimal.Round(number, 2).ToString();
        }

        public static string BeautifyBPS(decimal number)
        {
            if (number / 1000000000000 >= 1)
                return decimal.Round(number / 1000000000000, 2).ToString();
            else if (number / 1000000000 >= 1)
                return decimal.Round(number / 1000000000, 2).ToString();
            else if (number / 1000000 >= 1)
                return decimal.Round(number / 1000000, 2).ToString();
            else if (number / 1000 >= 1)
                return decimal.Round(number / 1000, 2).ToString();

            return decimal.Round(number,2).ToString();
        }
        
        public static decimal BeautifyButKeepLength(decimal number)
        {
            if (number / 1000000000000 > 1)
            {
                number = decimal.Floor(number / 10000000000);
                number = decimal.Round(number / 100,2);
                return number * 1000000000000;
            }
            else if (number / 1000000000 > 1)
            {
                number = decimal.Floor(number / 10000000);
                number = decimal.Round(number / 100, 2);
                return number * 1000000000;
            }
            else if (number / 1000000 > 1)
            {
                number = decimal.Floor(number / 10000);
                number = decimal.Round(number / 100, 2);
                return number * 1000000;
            }
            else if (number / 1000 > 1)
            {
                number = decimal.Floor(number / 10);
                number = decimal.Round(number / 100, 2);
                return number * 1000;
            }

            return decimal.Ceiling(number);
        }

        public static string AppendCorrectAbbreviation(decimal number)
        {
            if (number / 1000000000000 > 1)
                return " Tb";

            else if (number / 1000000000 > 1)
                return " Gb";

            else if (number / 1000000 > 1)
                return " Mb";

            else if (number / 1000 > 1)
                return " kb";

            return " bytes";
        }

        public static string AppendCorrectAbbreviationBPS(decimal number)
        {
            if (number / 1000000000000 > 1)
                return " Tb/s";

            else if (number / 1000000000 > 1)
                return " Gb/s";

            else if (number / 1000000 > 1)
                return " Mb/s";

            else if (number / 1000 > 1)
                return " kb/s";

            return " b/s";
        }

        public static string AppendCorrectAbbreviationCost(decimal number)
        {
            if (number / 1000000000000 > 1)
                return " Tb/bps";

            else if (number / 1000000000 > 1)
                return " Gb/bps";

            else if (number / 1000000 > 1)
                return " Mb/bps";

            else if (number / 1000 > 1)
                return " kb/bps";

            return " b/bps";
        }
    }
}
