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

        public static string Beautify(decimal number)
        {
            if (number / 1000000000000 > 1)
                return decimal.Round(number / 1000000000000, 2).ToString();
            else if (number / 1000000000 > 1)
                return decimal.Round(number / 1000000000, 2).ToString();
            else if (number / 1000000 > 1)
                return decimal.Round(number / 1000000, 2).ToString();
            else if(number / 1000 > 1)
                return decimal.Round(number / 1000, 2).ToString();

            return decimal.Round(number, 2).ToString();
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
    }
}
