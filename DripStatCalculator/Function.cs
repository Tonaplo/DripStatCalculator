using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DripStatCalculator
{
    public static class Function
    {
        #region Constants
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
        public static decimal CursorUpgrade7 = 1100000.0m;
        public static decimal BrogrammerUpgrade1 = 300.0m;
        public static decimal BrogrammerUpgrade2 = 1500.0m;
        public static decimal BrogrammerUpgrade3 = 4000.0m;
        public static decimal BrogrammerUpgrade4 = 25000.0m;
        public static decimal BrogrammerUpgrade5 = 300000.0m;
        public static decimal BrogrammerUpgrade6 = 2000000.0m;
        public static decimal GCFailureUpgrade1 = 1000.0m;
        public static decimal GCFailureUpgrade2 = 8000.0m;
        public static decimal GCFailureUpgrade3 = 35000.0m;
        public static decimal GCFailureUpgrade4 = 400000.0m;
        public static decimal GCFailureUpgrade5 = 3000000.0m;
        public static decimal GCFailureUpgrade6 = 12000000.0m;
        public static decimal GCFailureUpgrade7 = 56000000.0m;
        public static decimal GCFailureUpgrade8 = 680000000.0m;
        public static decimal GCFailureUpgrade9 = 5000000000.0m;
        public static decimal MemoryLeakUpgrade1 = 6000.0m;
        public static decimal MemoryLeakUpgrade2 = 80000.0m;
        public static decimal MemoryLeakUpgrade3 = 800000.0m;
        public static decimal MemoryLeakUpgrade4 = 7000000.0m;
        public static decimal MemoryLeakUpgrade5 = 21000000.0m;
        public static decimal MemoryLeakUpgrade6 = 70000000.0m;
        public static decimal MemoryLeakUpgrade7 = 600000000.0m;
        public static decimal MessageQueueUpgrade1 = 60000.0m;
        public static decimal MessageQueueUpgrade2 = 600000.0m;
        public static decimal MessageQueueUpgrade3 = 4000000.0m;
        public static decimal MessageQueueUpgrade4 = 18000000.0m;
        public static decimal MessageQueueUpgrade5 = 82000000.0m;
        public static decimal MessageQueueUpgrade6 = 1000000000.0m;
        public static decimal MessageQueueUpgrade7 = 3000000000.0m;
        public static decimal MessageQueueUpgrade8 = 6000000000.0m;
        public static decimal DatabaseUpgrade1 = 500000.0m;
        public static decimal DatabaseUpgrade2 = 9000000.0m;
        public static decimal DatabaseUpgrade3 = 35000000.0m;
        public static decimal DatabaseUpgrade4 = 98000000.0m;
        public static decimal DatabaseUpgrade5 = 200000000.0m;
        public static decimal DatabaseUpgrade6 = 280000000.0m;
        public static decimal DatabaseUpgrade7 = 360000000.0m;
        public static decimal DatabaseUpgrade8 = 940000000.0m;
        public static decimal DatabaseUpgrade9 = 6200000000.0m;
        public static decimal CacheUpgrade1 = 5000000.0m;
        public static decimal CacheUpgrade2 = 42000000.0m;
        public static decimal CacheUpgrade3 = 122000000.0m;
        public static decimal CacheUpgrade4 = 222000000.0m;
        public static decimal CacheUpgrade5 = 900000000.0m;
        public static decimal CacheUpgrade6 = 1400000000.0m;
        public static decimal CacheUpgrade7 = 4000000000.0m;
        public static decimal CPUUpgrade1 = 25000000.0m;
        public static decimal CPUUpgrade2 = 180000000.0m;
        public static decimal CPUUpgrade3 = 300000000.0m;
        public static decimal CPUUpgrade4 = 392000000.0m;
        public static decimal CPUUpgrade5 = 460000000.0m;
        public static decimal CPUUpgrade6 = 800000000.0m;
        public static decimal CPUUpgrade7 = 1400000000.0m;
        public static decimal CPUUpgrade8 = 2200000000.0m;
        public static decimal CPUUpgrade9 = 3000000000.0m;
        public static decimal CPUUpgrade10 = 7000000000.0m;
        public static decimal GPUUpgrade1 = 150000000.0m;
        public static decimal GPUUpgrade2 = 250000000.0m;
        public static decimal GPUUpgrade3 = 332000000.0m;
        public static decimal GPUUpgrade4 = 422000000.0m;
        public static decimal GPUUpgrade5 = 482000000.0m;
        public static decimal GPUUpgrade6 = 1200000000.0m;
        public static decimal ClusterUpgrade1 = 560000000.0m;
        public static decimal ClusterUpgrade2 = 620000000.0m;
        public static decimal ClusterUpgrade3 = 750000000.0m;
        public static decimal ClusterUpgrade4 = 2000000000.0m;
        public static decimal ClusterUpgrade5 = 8000000000.0m;
        public static decimal ClusterUpgrade6 = 12000000000.0m;
        #endregion

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

        #region Power Cost returning functions

        public static long ReturnPowerUpCostCursor(int PowerUpNumber)
        {
            switch (PowerUpNumber)
            {
                case 1:
                    return (long) CursorUpgrade1;
                case 2:
                    return (long) CursorUpgrade2;
                case 3:
                    return (long) CursorUpgrade3;
                case 4:
                    return (long) CursorUpgrade4;
                case 5:
                    return (long) CursorUpgrade5;
                case 6:
                    return (long) CursorUpgrade6;
                case 7:
                    return (long) CursorUpgrade7;
                default:
                    return 0;
            }
        }

        public static long ReturnPowerUpCostBrogrammer(int PowerUpNumber)
        {
            switch (PowerUpNumber)
            {
                case 1:
                    return (long) BrogrammerUpgrade1;
                case 2:
                    return (long) BrogrammerUpgrade2;
                case 3:
                    return (long) BrogrammerUpgrade3;
                case 4:
                    return (long) BrogrammerUpgrade4;
                case 5:
                    return (long) BrogrammerUpgrade5;
                case 6:
                    return (long) BrogrammerUpgrade6;
                default:
                    return 0;
            }
        }

        public static long ReturnPowerUpCostGCFailure(int PowerUpNumber)
        {
            switch (PowerUpNumber)
            {
                case 1:
                    return (long) GCFailureUpgrade1;
                case 2:
                    return (long) GCFailureUpgrade2;
                case 3:
                    return (long) GCFailureUpgrade3;
                case 4:
                    return (long) GCFailureUpgrade4;
                case 5:
                    return (long) GCFailureUpgrade5;
                case 6:
                    return (long) GCFailureUpgrade6;
                case 7:
                    return (long) GCFailureUpgrade7;
                case 8:
                    return (long) GCFailureUpgrade8;
                case 9:
                    return (long) GCFailureUpgrade9;
                default:
                    return 0;
            }
        }

        public static long ReturnPowerUpCostMemoryLeak(int PowerUpNumber)
        {
            switch (PowerUpNumber)
            {
                case 1:
                    return (long) MemoryLeakUpgrade1;
                case 2:
                    return (long) MemoryLeakUpgrade2;
                case 3:
                    return (long) MemoryLeakUpgrade3;
                case 4:
                    return (long) MemoryLeakUpgrade4;
                case 5:
                    return (long) MemoryLeakUpgrade5;
                case 6:
                    return (long) MemoryLeakUpgrade6;
                case 7:
                    return (long) MemoryLeakUpgrade7;
                default:
                    return 0;
            }
        }

        public static long ReturnPowerUpCostMessageQueue(int PowerUpNumber)
        {
            switch (PowerUpNumber)
            {
                case 1:
                    return (long) MessageQueueUpgrade1;
                case 2:
                    return (long) MessageQueueUpgrade2;
                case 3:
                    return (long) MessageQueueUpgrade3;
                case 4:
                    return (long) MessageQueueUpgrade4;
                case 5:
                    return (long) MessageQueueUpgrade5;
                case 6:
                    return (long) MessageQueueUpgrade6;
                case 7:
                    return (long) MessageQueueUpgrade7;
                case 8:
                    return (long) MessageQueueUpgrade8;
                default:
                    return 0;
            }
        }

        public static long ReturnPowerUpCostDatabase(int PowerUpNumber)
        {
            switch (PowerUpNumber)
            {
                case 1:
                    return (long) DatabaseUpgrade1;
                case 2:
                    return (long) DatabaseUpgrade2;
                case 3:
                    return (long) DatabaseUpgrade3;
                case 4:
                    return (long) DatabaseUpgrade4;
                case 5:
                    return (long) DatabaseUpgrade5;
                case 6:
                    return (long) DatabaseUpgrade6;
                case 7:
                    return (long) DatabaseUpgrade7;
                case 8:
                    return (long) DatabaseUpgrade8;
                case 9:
                    return (long) DatabaseUpgrade9;
                default:
                    return 0;
            }
        }

        public static long ReturnPowerUpCostCache(int PowerUpNumber)
        {
            switch (PowerUpNumber)
            {
                case 1:
                    return (long) CacheUpgrade1;
                case 2:
                    return (long) CacheUpgrade2;
                case 3:
                    return (long) CacheUpgrade3;
                case 4:
                    return (long) CacheUpgrade4;
                case 5:
                    return (long) CacheUpgrade5;
                case 6:
                    return (long) CacheUpgrade6;
                case 7:
                    return (long) CacheUpgrade7;
                default:
                    return 0;
            }
        }

        public static long ReturnPowerUpCostCPU(int PowerUpNumber)
        {
            switch (PowerUpNumber)
            {
                case 1:
                    return (long) CPUUpgrade1;
                case 2:
                    return (long) CPUUpgrade2;
                case 3:
                    return (long) CPUUpgrade3;
                case 4:
                    return (long) CPUUpgrade4;
                case 5:
                    return (long) CPUUpgrade5;
                case 6:
                    return (long) CPUUpgrade6;
                case 7:
                    return (long) CPUUpgrade7;
                case 8:
                    return (long) CPUUpgrade8;
                case 9:
                    return (long) CPUUpgrade9;
                case 10:
                    return (long) CPUUpgrade10;
                default:
                    return 0;
            }
        }

        public static long ReturnPowerUpCostGPU(int PowerUpNumber)
        {
            switch (PowerUpNumber)
            {
                case 1:
                    return (long) GPUUpgrade1;
                case 2:
                    return (long) GPUUpgrade2;
                case 3:
                    return (long) GPUUpgrade3;
                case 4:
                    return (long) GPUUpgrade4;
                case 5:
                    return (long) GPUUpgrade5;
                case 6:
                    return (long) GPUUpgrade6;
                default:
                    return 0;
            }
        }

        public static long ReturnPowerUpCostCluster(int PowerUpNumber)
        {
            switch (PowerUpNumber)
            {
                case 1:
                    return (long) ClusterUpgrade1;
                case 2:
                    return (long) ClusterUpgrade2;
                case 3:
                    return (long) ClusterUpgrade3;
                case 4:
                    return (long) ClusterUpgrade4;
                case 5:
                    return (long) ClusterUpgrade5;
                case 6:
                    return (long) ClusterUpgrade6;
                default:
                    return 0;
            }
        }
        #endregion
    }
}
