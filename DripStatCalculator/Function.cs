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
        public static decimal StartingBPSCluster = 1.0m;

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
