using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DripStatCalculator;

namespace DripStatCalculator
{
    public partial class DripStatCalculator : Form
    {
        #region All the variables
        int cursorUnitCount, brogrammerUnitCount, gcfailureUnitCount, memoryleakUnitCount, messagequeueUnitCount, databaseUnitCount, cacheUnitCount, cpuUnitCount, gpuUnitCount, clusterUnitCount, springFrameworkUnitCount;
        int cursorPowerUpCount, brogrammerPowerUpCount, gcfailurePowerUpCount, memoryleakPowerUpCount, messagequeuePowerUpCount, databasePowerUpCount, cachePowerUpCount, cpuPowerUpCount, gpuPowerUpCount, clusterPowerUpCount, springFrameworkPowerUpCount;
        decimal cursorCurrentRealPrice, brogrammerCurrentRealPrice, gcfailureCurrentRealPrice, memoryleakCurrentRealPrice, messagequeueCurrentRealPrice, databaseCurrentRealPrice, cacheCurrentRealPrice, cpuCurrentRealPrice, gpuCurrentRealPrice, clusterCurrentRealPrice, springFrameworkCurrentRealPrice;
        string cursorCurrentPrettyPrice, brogrammerCurrentPrettyPrice, gcfailureCurrentPrettyPrice, memoryleakCurrentPrettyPrice, messagequeueCurrentPrettyPrice, databaseCurrentPrettyPrice, cacheCurrentPrettyPrice, cpuCurrentPrettyPrice, gpuCurrentPrettyPrice, clusterCurrentPrettyPrice, springFrameworkCurrentPrettyPrice;
        decimal cursorOutputPerUnit, brogrammerOutputPerUnit, gcfailureOutputPerUnit, memoryleakOutputPerUnit, messagequeueOutputPerUnit, databaseOutputPerUnit, cacheOutputPerUnit, cpuOutputPerUnit, gpuOutputPerUnit, clusterOutputPerUnit, springFrameworkOutputPerUnit;
        decimal currentLowest, totalPower;
        int noClicksPerSecond;
        long bytesSpent, priceOfNext, capacity;

        #endregion

        #region GUI Functions

        public void UpdateAll()
        {
            UpdateUnitCount();
            UpdatePowerUpCount();
            UpdateUnitPrice();
            UpdatePowerPerUnit();
            UpdatePowerUpEffect();
            UpdateUnitCost();
            UpdateRecommendation();
            UpdateTotalBPS();
            UpdateAllPowerUpCosts();
            UpdateTime();
            UpdateSpendings();
        }

        private void UpdateUnitCount()
        {
            labelCursorCount.Text = cursorUnitCount.ToString();
            labelBrogrammerCount.Text = brogrammerUnitCount.ToString();
            labelGCFailureCount.Text = gcfailureUnitCount.ToString();
            labelMemoryLeakCount.Text = memoryleakUnitCount.ToString();
            labelMessageQueueCount.Text = messagequeueUnitCount.ToString();
            labelDatabaseCount.Text = databaseUnitCount.ToString();
            labelCacheCount.Text = cacheUnitCount.ToString();
            labelCPUCount.Text = cpuUnitCount.ToString();
            labelGPUCount.Text = gpuUnitCount.ToString();
            labelClusterCount.Text = clusterUnitCount.ToString();
            labelSpringFrameworkCount.Text = springFrameworkUnitCount.ToString();
        }

        private void UpdateUnitPrice()
        {
            labelCursorPriceOfOne.Text = cursorCurrentPrettyPrice;
            labelBrogrammerPriceOfOne.Text = brogrammerCurrentPrettyPrice;
            labelGCFailurePriceOfOne.Text = gcfailureCurrentPrettyPrice;
            labelMemoryLeakPriceOfOne.Text = memoryleakCurrentPrettyPrice;
            labelMessageQueuePriceOfOne.Text = messagequeueCurrentPrettyPrice;
            labelDatabasePriceOfOne.Text = databaseCurrentPrettyPrice;
            labelCachePriceOfOne.Text = cacheCurrentPrettyPrice;
            labelCPUPriceOfOne.Text = cpuCurrentPrettyPrice;
            labelGPUPriceOfOne.Text = gpuCurrentPrettyPrice;
            labelClusterPriceOfOne.Text = clusterCurrentPrettyPrice;
            labelSpringFrameworkPriceOfOne.Text = springFrameworkCurrentPrettyPrice;
        }

        private void UpdatePowerUpCount()
        {
            labelCursorPowerUp.Text = cursorPowerUpCount.ToString();
            labelBrogrammerPowerUp.Text = brogrammerPowerUpCount.ToString();
            labelGCFailurePowerUp.Text = gcfailurePowerUpCount.ToString();
            labelMemoryLeakPowerUp.Text = memoryleakPowerUpCount.ToString();
            labelMessageQueuePowerUp.Text = messagequeuePowerUpCount.ToString();
            labelDatabasePowerUp.Text = databasePowerUpCount.ToString();
            labelCachePowerUp.Text = cachePowerUpCount.ToString();
            labelCPUPowerUp.Text = cpuPowerUpCount.ToString();
            labelGPUPowerUp.Text = gpuPowerUpCount.ToString();
            labelClusterPowerUp.Text = clusterPowerUpCount.ToString();
            labelSpringFrameworkPowerUp.Text = springFrameworkPowerUpCount.ToString();
        }

        private void UpdatePowerUpEffect()
        {
            UpdatePowerPerUnit();
            UpdatePowerTotal();
        }

        #region PowerUp Effects functions
        private void UpdatePowerPerUnit()
        {
            labelCursorOutputPerUnit.Text = Function.Beautify(cursorOutputPerUnit ) + Function.AppendCorrectAbbreviationBPS(cursorOutputPerUnit );
            labelBrogrammerOutputPerUnit.Text = Function.Beautify(brogrammerOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(brogrammerOutputPerUnit);
            labelGCFailureOutputPerUnit.Text = Function.Beautify(gcfailureOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(gcfailureOutputPerUnit);
            labelMemoryLeakOutputPerUnit.Text = Function.Beautify(memoryleakOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(memoryleakOutputPerUnit);
            labelMessageQueueOutputPerUnit.Text = Function.Beautify(messagequeueOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(messagequeueOutputPerUnit);
            labelDatabaseOutputPerUnit.Text = Function.Beautify(databaseOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(databaseOutputPerUnit);
            labelCacheOutputPerUnit.Text = Function.Beautify(cacheOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(cacheOutputPerUnit);
            labelCPUOutputPerUnit.Text = Function.Beautify(cpuOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(cpuOutputPerUnit);
            labelGPUOutputPerUnit.Text = Function.Beautify(gpuOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(gpuOutputPerUnit);
            labelClusterOutputPerUnit.Text = Function.Beautify(clusterOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(clusterOutputPerUnit);
            labelSpringFrameworkOutputPerUnit.Text = Function.Beautify(springFrameworkOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(springFrameworkOutputPerUnit);
        }

        private void UpdatePowerTotal()
        {
            labelCursorOutputTotal.Text = Function.Beautify(cursorOutputPerUnit * cursorUnitCount) + Function.AppendCorrectAbbreviationBPS(cursorOutputPerUnit * cursorUnitCount);
            labelBrogrammerOutputTotal.Text = Function.Beautify(brogrammerOutputPerUnit * brogrammerUnitCount) + Function.AppendCorrectAbbreviationBPS(brogrammerOutputPerUnit * brogrammerUnitCount);
            labelGCFailureOutputTotal.Text = Function.Beautify(gcfailureOutputPerUnit * gcfailureUnitCount) + Function.AppendCorrectAbbreviationBPS(gcfailureOutputPerUnit * gcfailureUnitCount);
            labelMemoryLeakOutputTotal.Text = Function.Beautify(memoryleakOutputPerUnit * memoryleakUnitCount) + Function.AppendCorrectAbbreviationBPS(memoryleakOutputPerUnit * memoryleakUnitCount);
            labelMessageQueueOutputTotal.Text = Function.Beautify(messagequeueOutputPerUnit * messagequeueUnitCount) + Function.AppendCorrectAbbreviationBPS(messagequeueOutputPerUnit * messagequeueUnitCount);
            labelDatabaseOutputTotal.Text = Function.Beautify(databaseOutputPerUnit * databaseUnitCount) + Function.AppendCorrectAbbreviationBPS(databaseOutputPerUnit * databaseUnitCount);
            labelCacheOutputTotal.Text = Function.Beautify(cacheOutputPerUnit * cacheUnitCount) + Function.AppendCorrectAbbreviationBPS(cacheOutputPerUnit * cacheUnitCount);
            labelCPUOutputTotal.Text = Function.Beautify(cpuOutputPerUnit * cpuUnitCount) + Function.AppendCorrectAbbreviationBPS(cpuOutputPerUnit * cpuUnitCount);
            labelGPUOutputTotal.Text = Function.Beautify(gpuOutputPerUnit * gpuUnitCount) + Function.AppendCorrectAbbreviationBPS(gpuOutputPerUnit * gpuUnitCount);
            labelClusterOutputTotal.Text = Function.Beautify(clusterOutputPerUnit * clusterUnitCount) + Function.AppendCorrectAbbreviationBPS(clusterOutputPerUnit * clusterUnitCount);
            labelSpringFrameworkOutputTotal.Text = Function.Beautify(springFrameworkOutputPerUnit * springFrameworkUnitCount) + Function.AppendCorrectAbbreviationBPS(springFrameworkOutputPerUnit * springFrameworkUnitCount);
        }

        #endregion

        private void UpdateUnitCost()
        {
            labelCursorUnitCost.Text = Function.Beautify(cursorCurrentRealPrice / cursorOutputPerUnit) + Function.AppendCorrectAbbreviationCost(cursorCurrentRealPrice / cursorOutputPerUnit);
            labelBrogrammerUnitCost.Text = Function.Beautify(brogrammerCurrentRealPrice / brogrammerOutputPerUnit) + Function.AppendCorrectAbbreviationCost(brogrammerCurrentRealPrice / brogrammerOutputPerUnit);
            labelGCFailureUnitCost.Text = Function.Beautify(gcfailureCurrentRealPrice / gcfailureOutputPerUnit) + Function.AppendCorrectAbbreviationCost(gcfailureCurrentRealPrice / gcfailureOutputPerUnit);
            labelMemoryLeakUnitCost.Text = Function.Beautify(memoryleakCurrentRealPrice / memoryleakOutputPerUnit) + Function.AppendCorrectAbbreviationCost(memoryleakCurrentRealPrice / memoryleakOutputPerUnit);
            labelMessageQueueUnitCost.Text = Function.Beautify(messagequeueCurrentRealPrice / messagequeueOutputPerUnit) + Function.AppendCorrectAbbreviationCost(messagequeueCurrentRealPrice / messagequeueOutputPerUnit);
            labelDatabaseUnitCost.Text = Function.Beautify(databaseCurrentRealPrice / databaseOutputPerUnit) + Function.AppendCorrectAbbreviationCost(databaseCurrentRealPrice / databaseOutputPerUnit);
            labelCacheUnitCost.Text = Function.Beautify(cacheCurrentRealPrice / cacheOutputPerUnit) + Function.AppendCorrectAbbreviationCost(cacheCurrentRealPrice / cacheOutputPerUnit);
            labelCPUUnitCost.Text = Function.Beautify(cpuCurrentRealPrice / cpuOutputPerUnit) + Function.AppendCorrectAbbreviationCost(cpuCurrentRealPrice / cpuOutputPerUnit);
            labelGPUUnitCost.Text = Function.Beautify(gpuCurrentRealPrice / gpuOutputPerUnit) + Function.AppendCorrectAbbreviationCost(gpuCurrentRealPrice / gpuOutputPerUnit);
            labelClusterUnitCost.Text = Function.Beautify(clusterCurrentRealPrice / clusterOutputPerUnit) + Function.AppendCorrectAbbreviationCost(clusterCurrentRealPrice / clusterOutputPerUnit);
            labelSpringFrameworkUnitCost.Text = Function.Beautify(springFrameworkCurrentRealPrice / springFrameworkOutputPerUnit) + Function.AppendCorrectAbbreviationCost(springFrameworkCurrentRealPrice / springFrameworkOutputPerUnit);
        }

        private void UpdateRecommendation()
        {

            currentLowest = cursorCurrentRealPrice / cursorOutputPerUnit;
            priceOfNext = (long)cursorCurrentRealPrice;
            labelRecommendation.Text = "You should now buy a Cursor for optimal BPS increase.";

            if (currentLowest > brogrammerCurrentRealPrice / brogrammerOutputPerUnit) 
            {
                currentLowest = brogrammerCurrentRealPrice / brogrammerOutputPerUnit;
                labelRecommendation.Text = "You should now buy a Brogrammer for optimal BPS increase.";
                priceOfNext = (long)brogrammerCurrentRealPrice;
            }
            if (currentLowest > gcfailureCurrentRealPrice / gcfailureOutputPerUnit) 
                {
                    currentLowest = gcfailureCurrentRealPrice / gcfailureOutputPerUnit;
                labelRecommendation.Text = "You should now buy a GC Failure for optimal BPS increase.";
                priceOfNext = (long)gcfailureCurrentRealPrice;
            }
            if (currentLowest > memoryleakCurrentRealPrice / memoryleakOutputPerUnit) 
                {
                    currentLowest = memoryleakCurrentRealPrice / memoryleakOutputPerUnit;
                    labelRecommendation.Text = "You should now buy a Memory Leak for optimal BPS increase.";
                    priceOfNext = (long)memoryleakCurrentRealPrice;
            }
            if (currentLowest > messagequeueCurrentRealPrice / messagequeueOutputPerUnit) 
                {
                    currentLowest = messagequeueCurrentRealPrice / messagequeueOutputPerUnit;
                    labelRecommendation.Text = "You should now buy a Message Queue for optimal BPS increase.";
                    priceOfNext = (long)messagequeueCurrentRealPrice;
            }
            if (currentLowest > databaseCurrentRealPrice / databaseOutputPerUnit) 
                {
                    currentLowest = databaseCurrentRealPrice / databaseOutputPerUnit;
                    labelRecommendation.Text = "You should now buy a Database for optimal BPS increase.";
                    priceOfNext = (long)databaseCurrentRealPrice;
            }
            if (currentLowest > cacheCurrentRealPrice / cacheOutputPerUnit) 
                {
                    currentLowest = cacheCurrentRealPrice / cacheOutputPerUnit;
                    labelRecommendation.Text = "You should now buy a Cache for optimal BPS increase.";
                    priceOfNext = (long)cacheCurrentRealPrice;
            }
            if (currentLowest > cpuCurrentRealPrice / cpuOutputPerUnit) 
                {
                    currentLowest = cpuCurrentRealPrice / cpuOutputPerUnit;
                    labelRecommendation.Text = "You should now buy a CPU for optimal BPS increase.";
                    priceOfNext = (long)cpuCurrentRealPrice;
            }
            if (currentLowest > gpuCurrentRealPrice / gpuOutputPerUnit) 
                {
                    currentLowest = gpuCurrentRealPrice / gpuOutputPerUnit;
                    labelRecommendation.Text = "You should now buy a GPU for optimal BPS increase.";
                    priceOfNext = (long)gpuCurrentRealPrice;
            }
            if (currentLowest > clusterCurrentRealPrice / clusterOutputPerUnit)
            {
                currentLowest = clusterCurrentRealPrice / clusterOutputPerUnit;
                labelRecommendation.Text = "You should now buy a Cluster for optimal BPS increase.";
                priceOfNext = (long)clusterCurrentRealPrice;
            }
            if (currentLowest > springFrameworkCurrentRealPrice / springFrameworkOutputPerUnit)
            {
                currentLowest = springFrameworkCurrentRealPrice / springFrameworkOutputPerUnit;
                labelRecommendation.Text = "You should now buy a Spring Framework for optimal BPS increase.";
                priceOfNext = (long)springFrameworkCurrentRealPrice;
            }
        }

        private void UpdateTotalBPS()
        {
            totalPower = 0.0m;
            totalPower += (cursorOutputPerUnit * cursorUnitCount);
            totalPower += (brogrammerOutputPerUnit * brogrammerUnitCount);
            totalPower += (gcfailureOutputPerUnit * gcfailureUnitCount);
            totalPower += (memoryleakOutputPerUnit * memoryleakUnitCount);
            totalPower += (messagequeueOutputPerUnit * messagequeueUnitCount);
            totalPower += (databaseOutputPerUnit * databaseUnitCount);
            totalPower += (cacheOutputPerUnit * cacheUnitCount);
            totalPower += (cpuOutputPerUnit * cpuUnitCount);
            totalPower += (gpuOutputPerUnit * gpuUnitCount);
            totalPower += (clusterOutputPerUnit * clusterUnitCount);
            totalPower += (springFrameworkOutputPerUnit * springFrameworkUnitCount);

            labelBPSFromClicks.Text = Function.BeautifyBPS(totalPower * (0.1m * cursorPowerUpCount)+1) + Function.AppendCorrectAbbreviationBPS(totalPower * (0.1m * cursorPowerUpCount)+1);
            labelBPSFromItems.Text = Function.BeautifyBPS(totalPower) + Function.AppendCorrectAbbreviationBPS(totalPower);

            totalPower += (totalPower * (0.1m * cursorPowerUpCount) + 1) * noClicksPerSecond;

            labelTotalBPS.Text = Function.BeautifyBPS(totalPower) + Function.AppendCorrectAbbreviationBPS(totalPower);
        }

        private void UpdateSpendings()
        {
            
            labelSpendingNumber.Text = Function.Beautify((decimal)bytesSpent) + Function.AppendCorrectAbbreviation((decimal)bytesSpent);
            labelFutureSpendingNumber.Text = Function.Beautify((decimal)bytesSpent + priceOfNext) + Function.AppendCorrectAbbreviation((decimal)bytesSpent + priceOfNext);
            if (totalPower != 0)
            {
                int totalSecondsToMax = (int)(priceOfNext / totalPower);
                int secondsToMax = totalSecondsToMax % 60;
                int minutesToMax = (totalSecondsToMax / 60) % 60;
                int hoursToMax = (totalSecondsToMax / (60 * 60)) % 60;
                labelSpendingTime.Text = hoursToMax + " Hours, " + minutesToMax + " Minutes and " + secondsToMax + " Seconds.";
            }
            else
            {
                labelSpendingTime.Text = "No Power!";
            }

        }

        #region Power Up Costs Functions

        private void UpdateAllPowerUpCosts()
        {
            UpdateCursorPowerUpCosts();
            UpdateBrogrammerPowerUpCosts();
            UpdateGCFailurePowerUpCosts();
            UpdateMemoryLeakPowerUpCosts();
            UpdateMessageQueuePowerUpCosts();
            UpdateDatabasePowerUpCosts();
            UpdateCachePowerUpCosts();
            UpdateCPUPowerUpCosts();
            UpdateGPUPowerUpCosts();
            UpdateClusterPowerUpCosts();
            UpdateSpringFrameworkPowerUpCosts();
        }

        private void UpdateCursorPowerUpCosts()
        {
            if (cursorUnitCount != 0)
            {
                if (cursorPowerUpCount == 0)
                {
                    labelCursorUpgradeCost.Text = Function.Beautify((Function.CursorUpgrade1) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m))) + Function.AppendCorrectAbbreviationCost((Function.CursorUpgrade1) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)));
                    labelCursorPriceOfPowerUp.Text = Function.Beautify(Function.CursorUpgrade1) + Function.AppendCorrectAbbreviation(Function.CursorUpgrade1);
                    if (currentLowest > (Function.CursorUpgrade1) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)))
                    {
                        labelRecommendation.Text = "You should now buy a Cursor Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CursorUpgrade1;
                        currentLowest = ((Function.CursorUpgrade1) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)));
                    }
                }
                else if (cursorPowerUpCount == 1)
                {
                    labelCursorUpgradeCost.Text = Function.Beautify((Function.CursorUpgrade2) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m))) + Function.AppendCorrectAbbreviationCost((Function.CursorUpgrade2) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)));
                    labelCursorPriceOfPowerUp.Text = Function.Beautify(Function.CursorUpgrade2) + Function.AppendCorrectAbbreviation(Function.CursorUpgrade2);
                    if (currentLowest > ((Function.CursorUpgrade2) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m))))
                    {
                        labelRecommendation.Text = "You should now buy a Cursor Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CursorUpgrade2;
                        currentLowest = ((Function.CursorUpgrade1) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)));
                    }
                }
                else if (cursorPowerUpCount == 2)
                {
                    labelCursorUpgradeCost.Text = Function.Beautify((Function.CursorUpgrade3) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m))) + Function.AppendCorrectAbbreviationCost((Function.CursorUpgrade3) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)));
                    labelCursorPriceOfPowerUp.Text = Function.Beautify(Function.CursorUpgrade3) + Function.AppendCorrectAbbreviation(Function.CursorUpgrade3);
                    if (currentLowest > ((Function.CursorUpgrade3) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m))))
                    {
                        labelRecommendation.Text = "You should now buy a Cursor Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CursorUpgrade3;
                        currentLowest = (Function.CursorUpgrade3) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m));
                    }
                }
                else if (cursorPowerUpCount == 3)
                {
                    labelCursorUpgradeCost.Text = Function.Beautify((Function.CursorUpgrade4) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m))) + Function.AppendCorrectAbbreviationCost((Function.CursorUpgrade4) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)));
                    labelCursorPriceOfPowerUp.Text = Function.Beautify(Function.CursorUpgrade4) + Function.AppendCorrectAbbreviation(Function.CursorUpgrade4);
                    if (currentLowest > (Function.CursorUpgrade4) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)))
                    {
                        labelRecommendation.Text = "You should now buy a Cursor Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CursorUpgrade4;
                        currentLowest = ((Function.CursorUpgrade4) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)));
                    }
                }
                else if (cursorPowerUpCount == 4)
                {
                    labelCursorUpgradeCost.Text = Function.Beautify((Function.CursorUpgrade5) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m))) + Function.AppendCorrectAbbreviationCost((Function.CursorUpgrade5) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)));
                    labelCursorPriceOfPowerUp.Text = Function.Beautify(Function.CursorUpgrade5) + Function.AppendCorrectAbbreviation(Function.CursorUpgrade5);
                    if (currentLowest > (Function.CursorUpgrade5) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)))
                    {
                        labelRecommendation.Text = "You should now buy a Cursor Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CursorUpgrade5;
                        currentLowest = (Function.CursorUpgrade5) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m));
                    }
                }
                else if (cursorPowerUpCount == 5)
                {
                    labelCursorUpgradeCost.Text = Function.Beautify((Function.CursorUpgrade6) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m))) + Function.AppendCorrectAbbreviationCost((Function.CursorUpgrade6) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)));
                    labelCursorPriceOfPowerUp.Text = Function.Beautify(Function.CursorUpgrade6) + Function.AppendCorrectAbbreviation(Function.CursorUpgrade6);
                    if (currentLowest > (Function.CursorUpgrade6) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)))
                    {
                        labelRecommendation.Text = "You should now buy a Cursor Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CursorUpgrade6;
                        currentLowest = (Function.CursorUpgrade6) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m));
                    }
                }
                else if (cursorPowerUpCount == 6)
                {
                    labelCursorUpgradeCost.Text = Function.Beautify((Function.CursorUpgrade7) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m))) + Function.AppendCorrectAbbreviationCost((Function.CursorUpgrade7) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)));
                    labelCursorPriceOfPowerUp.Text = Function.Beautify(Function.CursorUpgrade7) + Function.AppendCorrectAbbreviation(Function.CursorUpgrade7);
                    if (currentLowest > (Function.CursorUpgrade7) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m)))
                    {
                        labelRecommendation.Text = "You should now buy a Cursor Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CursorUpgrade7;
                        currentLowest = (Function.CursorUpgrade7) / (cursorOutputPerUnit * cursorUnitCount * 0.1m + (totalPower * noClicksPerSecond * 0.1m));
                    }
                }
            }
        }

        private void UpdateBrogrammerPowerUpCosts()
        {
            if (brogrammerUnitCount != 0)
            {
                if (brogrammerPowerUpCount == 0)
                {
                    labelBrogrammerUpgradeCost.Text = Function.Beautify(Function.BrogrammerUpgrade1 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.BrogrammerUpgrade1 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m));
                    labelBrogrammerPriceOfPowerUp.Text = Function.Beautify(Function.BrogrammerUpgrade1) + Function.AppendCorrectAbbreviation(Function.BrogrammerUpgrade1);
                    if (currentLowest > Function.BrogrammerUpgrade1 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Brogrammer Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.BrogrammerUpgrade1;
                        currentLowest = Function.BrogrammerUpgrade1 / (brogrammerOutputPerUnit * brogrammerUnitCount);
                    }
                }
                else if (brogrammerPowerUpCount == 1)
                {
                    labelBrogrammerUpgradeCost.Text = Function.Beautify(Function.BrogrammerUpgrade2 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.BrogrammerUpgrade2 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m));
                    labelBrogrammerPriceOfPowerUp.Text = Function.Beautify(Function.BrogrammerUpgrade2) + Function.AppendCorrectAbbreviation(Function.BrogrammerUpgrade2);
                    if (currentLowest > Function.BrogrammerUpgrade2 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Brogrammer Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.BrogrammerUpgrade2;
                        currentLowest = Function.BrogrammerUpgrade1 / (brogrammerOutputPerUnit * brogrammerUnitCount);
                    }
                }
                else if (brogrammerPowerUpCount == 2)
                {
                    labelBrogrammerUpgradeCost.Text = Function.Beautify(Function.BrogrammerUpgrade3 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.BrogrammerUpgrade3 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m));
                    labelBrogrammerPriceOfPowerUp.Text = Function.Beautify(Function.BrogrammerUpgrade3) + Function.AppendCorrectAbbreviation(Function.BrogrammerUpgrade3);
                    if (currentLowest > Function.BrogrammerUpgrade3 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Brogrammer Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.BrogrammerUpgrade3;
                        currentLowest = Function.BrogrammerUpgrade3 / (brogrammerOutputPerUnit * brogrammerUnitCount);
                    }
                }
                else if (brogrammerPowerUpCount == 3)
                {
                    labelBrogrammerUpgradeCost.Text = Function.Beautify(Function.BrogrammerUpgrade4 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.BrogrammerUpgrade4 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m));
                    labelBrogrammerPriceOfPowerUp.Text = Function.Beautify(Function.BrogrammerUpgrade4) + Function.AppendCorrectAbbreviation(Function.BrogrammerUpgrade4);
                    if (currentLowest > Function.BrogrammerUpgrade4 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Brogrammer Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.BrogrammerUpgrade4;
                        currentLowest = Function.BrogrammerUpgrade4 / (brogrammerOutputPerUnit * brogrammerUnitCount);
                    }
                }
                else if (brogrammerPowerUpCount == 4)
                {
                    labelBrogrammerUpgradeCost.Text = Function.Beautify(Function.BrogrammerUpgrade5 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.BrogrammerUpgrade5 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m));
                    labelBrogrammerPriceOfPowerUp.Text = Function.Beautify(Function.BrogrammerUpgrade5) + Function.AppendCorrectAbbreviation(Function.BrogrammerUpgrade5);
                    if (currentLowest > Function.BrogrammerUpgrade5 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Brogrammer Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.BrogrammerUpgrade5;
                        currentLowest = Function.BrogrammerUpgrade5 / (brogrammerOutputPerUnit * brogrammerUnitCount);
                    }
                }
                else if (brogrammerPowerUpCount == 5)
                {
                    labelBrogrammerUpgradeCost.Text = Function.Beautify(Function.BrogrammerUpgrade6 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.BrogrammerUpgrade6 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m));
                    labelBrogrammerPriceOfPowerUp.Text = Function.Beautify(Function.BrogrammerUpgrade6) + Function.AppendCorrectAbbreviation(Function.BrogrammerUpgrade6);
                    if (currentLowest > Function.BrogrammerUpgrade6 / (brogrammerOutputPerUnit * brogrammerUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Brogrammer Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.BrogrammerUpgrade6;
                        currentLowest = Function.BrogrammerUpgrade6 / (brogrammerOutputPerUnit * brogrammerUnitCount);
                    }
                }
            }
        }

        private void UpdateGCFailurePowerUpCosts()
        {
            if (gcfailureUnitCount != 0)
            {
                if (gcfailurePowerUpCount == 0)
                {
                    labelGCFailureUpgradeCost.Text = Function.Beautify(Function.GCFailureUpgrade1 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GCFailureUpgrade1 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m));
                    labelGCFailurePriceOfPowerUp.Text = Function.Beautify(Function.GCFailureUpgrade1) + Function.AppendCorrectAbbreviation(Function.GCFailureUpgrade1);
                    if (currentLowest > Function.GCFailureUpgrade1 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GC Failure Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GCFailureUpgrade1;
                        currentLowest = Function.GCFailureUpgrade1 / (gcfailureOutputPerUnit * gcfailureUnitCount);
                    }
                }
                else if (gcfailurePowerUpCount == 1)
                {
                    labelGCFailureUpgradeCost.Text = Function.Beautify(Function.GCFailureUpgrade2 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GCFailureUpgrade2 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m));
                    labelGCFailurePriceOfPowerUp.Text = Function.Beautify(Function.GCFailureUpgrade2) + Function.AppendCorrectAbbreviation(Function.GCFailureUpgrade2);
                    if (currentLowest > Function.GCFailureUpgrade2 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GC Failure Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GCFailureUpgrade2;
                        currentLowest = Function.GCFailureUpgrade2 / (gcfailureOutputPerUnit * gcfailureUnitCount);
                    }
                }
                else if (gcfailurePowerUpCount == 2)
                {
                    labelGCFailureUpgradeCost.Text = Function.Beautify(Function.GCFailureUpgrade3 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GCFailureUpgrade3 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m));
                    labelGCFailurePriceOfPowerUp.Text = Function.Beautify(Function.GCFailureUpgrade3) + Function.AppendCorrectAbbreviation(Function.GCFailureUpgrade3);
                    if (currentLowest > Function.GCFailureUpgrade3 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GC Failure Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GCFailureUpgrade3;
                        currentLowest = Function.GCFailureUpgrade3 / (gcfailureOutputPerUnit * gcfailureUnitCount);
                    }
                }
                else if (gcfailurePowerUpCount == 3)
                {
                    labelGCFailureUpgradeCost.Text = Function.Beautify(Function.GCFailureUpgrade4 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GCFailureUpgrade4 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m));
                    labelGCFailurePriceOfPowerUp.Text = Function.Beautify(Function.GCFailureUpgrade4) + Function.AppendCorrectAbbreviation(Function.GCFailureUpgrade4);
                    if (currentLowest > Function.GCFailureUpgrade4 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GC Failure Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GCFailureUpgrade4;
                        currentLowest = Function.GCFailureUpgrade4 / (gcfailureOutputPerUnit * gcfailureUnitCount);
                    }
                }
                else if (gcfailurePowerUpCount == 4)
                {
                    labelGCFailureUpgradeCost.Text = Function.Beautify(Function.GCFailureUpgrade5 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GCFailureUpgrade5 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m));
                    labelGCFailurePriceOfPowerUp.Text = Function.Beautify(Function.GCFailureUpgrade5) + Function.AppendCorrectAbbreviation(Function.GCFailureUpgrade5);
                    if (currentLowest > Function.GCFailureUpgrade5 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GC Failure Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GCFailureUpgrade5;
                        currentLowest = Function.GCFailureUpgrade5 / (gcfailureOutputPerUnit * gcfailureUnitCount);
                    }
                }
                else if (gcfailurePowerUpCount == 5)
                {
                    labelGCFailureUpgradeCost.Text = Function.Beautify(Function.GCFailureUpgrade6 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GCFailureUpgrade6 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m));
                    labelGCFailurePriceOfPowerUp.Text = Function.Beautify(Function.GCFailureUpgrade6) + Function.AppendCorrectAbbreviation(Function.GCFailureUpgrade6);
                    if (currentLowest > Function.GCFailureUpgrade6 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GC Failure Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GCFailureUpgrade6;
                        currentLowest = Function.GCFailureUpgrade6 / (gcfailureOutputPerUnit * gcfailureUnitCount);
                    }
                }
                else if (gcfailurePowerUpCount == 6)
                {
                    labelGCFailureUpgradeCost.Text = Function.Beautify(Function.GCFailureUpgrade7 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GCFailureUpgrade7 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m));
                    labelGCFailurePriceOfPowerUp.Text = Function.Beautify(Function.GCFailureUpgrade7) + Function.AppendCorrectAbbreviation(Function.GCFailureUpgrade7);
                    if (currentLowest > Function.GCFailureUpgrade7 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GC Failure Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GCFailureUpgrade7;
                        currentLowest = Function.GCFailureUpgrade7 / (gcfailureOutputPerUnit * gcfailureUnitCount);
                    }
                }
                else if (gcfailurePowerUpCount == 7)
                {
                    labelGCFailureUpgradeCost.Text = Function.Beautify(Function.GCFailureUpgrade8 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GCFailureUpgrade8 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m));
                    labelGCFailurePriceOfPowerUp.Text = Function.Beautify(Function.GCFailureUpgrade8) + Function.AppendCorrectAbbreviation(Function.GCFailureUpgrade8);
                    if (currentLowest > Function.GCFailureUpgrade8 / (gcfailureOutputPerUnit * gcfailureUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GC Failure Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GCFailureUpgrade8;
                        currentLowest = Function.GCFailureUpgrade8 / (gcfailureOutputPerUnit * gcfailureUnitCount);
                    }
                }
                else if (gcfailurePowerUpCount == 8)
                {
                    labelGCFailureUpgradeCost.Text = Function.Beautify(Function.GCFailureUpgrade9 / (gcfailureOutputPerUnit * gcfailureUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GCFailureUpgrade9 / (gcfailureOutputPerUnit * gcfailureUnitCount * 0.1m));
                    labelGCFailurePriceOfPowerUp.Text = Function.Beautify(Function.GCFailureUpgrade9) + Function.AppendCorrectAbbreviation(Function.GCFailureUpgrade9);
                    if (currentLowest > Function.GCFailureUpgrade9 / (gcfailureOutputPerUnit * gcfailureUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GC Failure Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GCFailureUpgrade9;
                        currentLowest = Function.GCFailureUpgrade9 / (gcfailureOutputPerUnit * gcfailureUnitCount);
                    }
                }
            }
        }

        private void UpdateMemoryLeakPowerUpCosts()
        {
            if (memoryleakUnitCount != 0)
            {
                if (memoryleakPowerUpCount == 0)
                {
                    labelMemoryLeakUpgradeCost.Text = Function.Beautify(Function.MemoryLeakUpgrade1 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MemoryLeakUpgrade1 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m));
                    labelMemoryLeakPriceOfPowerUp.Text = Function.Beautify(Function.MemoryLeakUpgrade1) + Function.AppendCorrectAbbreviation(Function.MemoryLeakUpgrade1);
                    if (currentLowest > Function.MemoryLeakUpgrade1 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Memory Leak Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MemoryLeakUpgrade1;
                        currentLowest = Function.MemoryLeakUpgrade1 / (memoryleakOutputPerUnit * memoryleakUnitCount);
                    }
                }
                else if (memoryleakPowerUpCount == 1)
                {
                    labelMemoryLeakUpgradeCost.Text = Function.Beautify(Function.MemoryLeakUpgrade2 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MemoryLeakUpgrade2 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m));
                    labelMemoryLeakPriceOfPowerUp.Text = Function.Beautify(Function.MemoryLeakUpgrade2) + Function.AppendCorrectAbbreviation(Function.MemoryLeakUpgrade2);
                    if (currentLowest > Function.MemoryLeakUpgrade2 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Memory Leak Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MemoryLeakUpgrade2;
                        currentLowest = Function.MemoryLeakUpgrade1 / (memoryleakOutputPerUnit * memoryleakUnitCount);
                    }
                }
                else if (memoryleakPowerUpCount == 2)
                {
                    labelMemoryLeakUpgradeCost.Text = Function.Beautify(Function.MemoryLeakUpgrade3 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MemoryLeakUpgrade3 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m));
                    labelMemoryLeakPriceOfPowerUp.Text = Function.Beautify(Function.MemoryLeakUpgrade3) + Function.AppendCorrectAbbreviation(Function.MemoryLeakUpgrade3);
                    if (currentLowest > Function.MemoryLeakUpgrade3 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Memory Leak Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MemoryLeakUpgrade3;
                        currentLowest = Function.MemoryLeakUpgrade3 / (memoryleakOutputPerUnit * memoryleakUnitCount);
                    }
                }
                else if (memoryleakPowerUpCount == 3)
                {
                    labelMemoryLeakUpgradeCost.Text = Function.Beautify(Function.MemoryLeakUpgrade4 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MemoryLeakUpgrade4 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m));
                    labelMemoryLeakPriceOfPowerUp.Text = Function.Beautify(Function.MemoryLeakUpgrade4) + Function.AppendCorrectAbbreviation(Function.MemoryLeakUpgrade4);
                    if (currentLowest > Function.MemoryLeakUpgrade4 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Memory Leak Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MemoryLeakUpgrade4;
                        currentLowest = Function.MemoryLeakUpgrade4 / (memoryleakOutputPerUnit * memoryleakUnitCount);
                    }
                }
                else if (memoryleakPowerUpCount == 4)
                {
                    labelMemoryLeakUpgradeCost.Text = Function.Beautify(Function.MemoryLeakUpgrade5 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MemoryLeakUpgrade5 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m));
                    labelMemoryLeakPriceOfPowerUp.Text = Function.Beautify(Function.MemoryLeakUpgrade5) + Function.AppendCorrectAbbreviation(Function.MemoryLeakUpgrade5);
                    if (currentLowest > Function.MemoryLeakUpgrade5 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Memory Leak Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MemoryLeakUpgrade5;
                        currentLowest = Function.MemoryLeakUpgrade5 / (memoryleakOutputPerUnit * memoryleakUnitCount);
                    }
                }
                else if (memoryleakPowerUpCount == 5)
                {
                    labelMemoryLeakUpgradeCost.Text = Function.Beautify(Function.MemoryLeakUpgrade6 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MemoryLeakUpgrade6 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m));
                    labelMemoryLeakPriceOfPowerUp.Text = Function.Beautify(Function.MemoryLeakUpgrade6) + Function.AppendCorrectAbbreviation(Function.MemoryLeakUpgrade6);
                    if (currentLowest > Function.MemoryLeakUpgrade6 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Memory Leak Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MemoryLeakUpgrade6;
                        currentLowest = Function.MemoryLeakUpgrade6 / (memoryleakOutputPerUnit * memoryleakUnitCount);
                    }
                }
                else if (memoryleakPowerUpCount == 6)
                {
                    labelMemoryLeakUpgradeCost.Text = Function.Beautify(Function.MemoryLeakUpgrade7 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MemoryLeakUpgrade7 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m));
                    labelMemoryLeakPriceOfPowerUp.Text = Function.Beautify(Function.MemoryLeakUpgrade7) + Function.AppendCorrectAbbreviation(Function.MemoryLeakUpgrade7);
                    if (currentLowest > Function.MemoryLeakUpgrade7 / (memoryleakOutputPerUnit * memoryleakUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Memory Leak Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MemoryLeakUpgrade7;
                        currentLowest = Function.MemoryLeakUpgrade7 / (memoryleakOutputPerUnit * memoryleakUnitCount);
                    }
                }
            }
        }

        private void UpdateMessageQueuePowerUpCosts()
        {
            if (messagequeueUnitCount != 0)
            {
                if (messagequeuePowerUpCount == 0)
                {
                    labelMessageQueueUpgradeCost.Text = Function.Beautify(Function.MessageQueueUpgrade1 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MessageQueueUpgrade1 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m));
                    labelMessageQueuePriceOfPowerUp.Text = Function.Beautify(Function.MessageQueueUpgrade1) + Function.AppendCorrectAbbreviation(Function.MessageQueueUpgrade1);
                    if (currentLowest > Function.MessageQueueUpgrade1 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Message Queue Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MessageQueueUpgrade1;
                        currentLowest = Function.MessageQueueUpgrade1 / (messagequeueOutputPerUnit * messagequeueUnitCount);
                    }
                }
                else if (messagequeuePowerUpCount == 1)
                {
                    labelMessageQueueUpgradeCost.Text = Function.Beautify(Function.MessageQueueUpgrade2 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MessageQueueUpgrade2 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m));
                    labelMessageQueuePriceOfPowerUp.Text = Function.Beautify(Function.MessageQueueUpgrade2) + Function.AppendCorrectAbbreviation(Function.MessageQueueUpgrade2);
                    if (currentLowest > Function.MessageQueueUpgrade2 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Message Queue Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MessageQueueUpgrade2;
                        currentLowest = Function.MessageQueueUpgrade1 / (messagequeueOutputPerUnit * messagequeueUnitCount);
                    }
                }
                else if (messagequeuePowerUpCount == 2)
                {
                    labelMessageQueueUpgradeCost.Text = Function.Beautify(Function.MessageQueueUpgrade3 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MessageQueueUpgrade3 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m));
                    labelMessageQueuePriceOfPowerUp.Text = Function.Beautify(Function.MessageQueueUpgrade3) + Function.AppendCorrectAbbreviation(Function.MessageQueueUpgrade3);
                    if (currentLowest > Function.MessageQueueUpgrade3 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Message Queue Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MessageQueueUpgrade3;
                        currentLowest = Function.MessageQueueUpgrade3 / (messagequeueOutputPerUnit * messagequeueUnitCount);
                    }
                }
                else if (messagequeuePowerUpCount == 3)
                {
                    labelMessageQueueUpgradeCost.Text = Function.Beautify(Function.MessageQueueUpgrade4 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MessageQueueUpgrade4 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m));
                    labelMessageQueuePriceOfPowerUp.Text = Function.Beautify(Function.MessageQueueUpgrade4) + Function.AppendCorrectAbbreviation(Function.MessageQueueUpgrade4);
                    if (currentLowest > Function.MessageQueueUpgrade4 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Message Queue Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MessageQueueUpgrade4;
                        currentLowest = Function.MessageQueueUpgrade4 / (messagequeueOutputPerUnit * messagequeueUnitCount);
                    }
                }
                else if (messagequeuePowerUpCount == 4)
                {
                    labelMessageQueueUpgradeCost.Text = Function.Beautify(Function.MessageQueueUpgrade5 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MessageQueueUpgrade5 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m));
                    labelMessageQueuePriceOfPowerUp.Text = Function.Beautify(Function.MessageQueueUpgrade5) + Function.AppendCorrectAbbreviation(Function.MessageQueueUpgrade5);
                    if (currentLowest > Function.MessageQueueUpgrade5 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Message Queue Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MessageQueueUpgrade5;
                        currentLowest = Function.MessageQueueUpgrade5 / (messagequeueOutputPerUnit * messagequeueUnitCount);
                    }
                }
                else if (messagequeuePowerUpCount == 5)
                {
                    labelMessageQueueUpgradeCost.Text = Function.Beautify(Function.MessageQueueUpgrade6 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MessageQueueUpgrade6 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m));
                    labelMessageQueuePriceOfPowerUp.Text = Function.Beautify(Function.MessageQueueUpgrade6) + Function.AppendCorrectAbbreviation(Function.MessageQueueUpgrade6);
                    if (currentLowest > Function.MessageQueueUpgrade6 / (messagequeueOutputPerUnit * messagequeueUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Message Queue Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MessageQueueUpgrade6;
                        currentLowest = Function.MessageQueueUpgrade6 / (messagequeueOutputPerUnit * messagequeueUnitCount);
                    }
                }
                else if (messagequeuePowerUpCount == 6)
                {
                    labelMessageQueueUpgradeCost.Text = Function.Beautify(Function.MessageQueueUpgrade7 / (messagequeueOutputPerUnit * messagequeueUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MessageQueueUpgrade7 / (messagequeueOutputPerUnit * messagequeueUnitCount * 0.1m));
                    labelMessageQueuePriceOfPowerUp.Text = Function.Beautify(Function.MessageQueueUpgrade7) + Function.AppendCorrectAbbreviation(Function.MessageQueueUpgrade7);
                    if (currentLowest > Function.MessageQueueUpgrade7 / (messagequeueOutputPerUnit * messagequeueUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Message Queue Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MessageQueueUpgrade7;
                        currentLowest = Function.MessageQueueUpgrade7 / (messagequeueOutputPerUnit * messagequeueUnitCount);
                    }
                }
                else if (messagequeuePowerUpCount == 7)
                {
                    labelMessageQueueUpgradeCost.Text = Function.Beautify(Function.MessageQueueUpgrade8 / (messagequeueOutputPerUnit * messagequeueUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.MessageQueueUpgrade8 / (messagequeueOutputPerUnit * messagequeueUnitCount * 0.1m));
                    labelMessageQueuePriceOfPowerUp.Text = Function.Beautify(Function.MessageQueueUpgrade8) + Function.AppendCorrectAbbreviation(Function.MessageQueueUpgrade8);
                    if (currentLowest > Function.MessageQueueUpgrade8 / (messagequeueOutputPerUnit * messagequeueUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Message Queue Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.MessageQueueUpgrade8;
                        currentLowest = Function.MessageQueueUpgrade8 / (messagequeueOutputPerUnit * messagequeueUnitCount);
                    }
                }
            }
        }

        private void UpdateDatabasePowerUpCosts()
        {
            if (databaseUnitCount != 0)
            {
                if (databasePowerUpCount == 0)
                {
                    labelDatabaseUpgradeCost.Text = Function.Beautify(Function.DatabaseUpgrade1 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.DatabaseUpgrade1 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m));
                    labelDatabasePriceOfPowerUp.Text = Function.Beautify(Function.DatabaseUpgrade1) + Function.AppendCorrectAbbreviation(Function.DatabaseUpgrade1);
                    if (currentLowest > Function.DatabaseUpgrade1 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Database Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.DatabaseUpgrade1;
                        currentLowest = Function.DatabaseUpgrade1 / (databaseOutputPerUnit * databaseUnitCount);
                    }
                }
                else if (databasePowerUpCount == 1)
                {
                    labelDatabaseUpgradeCost.Text = Function.Beautify(Function.DatabaseUpgrade2 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.DatabaseUpgrade2 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m));
                    labelDatabasePriceOfPowerUp.Text = Function.Beautify(Function.DatabaseUpgrade2) + Function.AppendCorrectAbbreviation(Function.DatabaseUpgrade2);
                    if (currentLowest > Function.DatabaseUpgrade2 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Database Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.DatabaseUpgrade2;
                        currentLowest = Function.DatabaseUpgrade2 / (databaseOutputPerUnit * databaseUnitCount);
                    }
                }
                else if (databasePowerUpCount == 2)
                {
                    labelDatabaseUpgradeCost.Text = Function.Beautify(Function.DatabaseUpgrade3 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.DatabaseUpgrade3 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m));
                    labelDatabasePriceOfPowerUp.Text = Function.Beautify(Function.DatabaseUpgrade3) + Function.AppendCorrectAbbreviation(Function.DatabaseUpgrade3);
                    if (currentLowest > Function.DatabaseUpgrade3 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Database Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.DatabaseUpgrade3;
                        currentLowest = Function.DatabaseUpgrade3 / (databaseOutputPerUnit * databaseUnitCount);
                    }
                }
                else if (databasePowerUpCount == 3)
                {
                    labelDatabaseUpgradeCost.Text = Function.Beautify(Function.DatabaseUpgrade4 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.DatabaseUpgrade4 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m));
                    labelDatabasePriceOfPowerUp.Text = Function.Beautify(Function.DatabaseUpgrade4) + Function.AppendCorrectAbbreviation(Function.DatabaseUpgrade4);
                    if (currentLowest > Function.DatabaseUpgrade4 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Database Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.DatabaseUpgrade4;
                        currentLowest = Function.DatabaseUpgrade4 / (databaseOutputPerUnit * databaseUnitCount);
                    }
                }
                else if (databasePowerUpCount == 4)
                {
                    labelDatabaseUpgradeCost.Text = Function.Beautify(Function.DatabaseUpgrade5 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.DatabaseUpgrade5 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m));
                    labelDatabasePriceOfPowerUp.Text = Function.Beautify(Function.DatabaseUpgrade5) + Function.AppendCorrectAbbreviation(Function.DatabaseUpgrade5);
                    if (currentLowest > Function.DatabaseUpgrade5 / (databaseOutputPerUnit * databaseUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Database Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.DatabaseUpgrade5;
                        currentLowest = Function.DatabaseUpgrade5 / (databaseOutputPerUnit * databaseUnitCount);
                    }
                }
                else if (databasePowerUpCount == 5)
                {
                    labelDatabaseUpgradeCost.Text = Function.Beautify(Function.DatabaseUpgrade6 / (databaseOutputPerUnit * databaseUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.DatabaseUpgrade6 / (databaseOutputPerUnit * databaseUnitCount * 0.1m));
                    labelDatabasePriceOfPowerUp.Text = Function.Beautify(Function.DatabaseUpgrade6) + Function.AppendCorrectAbbreviation(Function.DatabaseUpgrade6);
                    if (currentLowest > Function.DatabaseUpgrade6 / (databaseOutputPerUnit * databaseUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Database Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.DatabaseUpgrade6;
                        currentLowest = Function.DatabaseUpgrade6 / (databaseOutputPerUnit * databaseUnitCount);
                    }
                }
                else if (databasePowerUpCount == 6)
                {
                    labelDatabaseUpgradeCost.Text = Function.Beautify(Function.DatabaseUpgrade7 / (databaseOutputPerUnit * databaseUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.DatabaseUpgrade7 / (databaseOutputPerUnit * databaseUnitCount * 0.1m));
                    labelDatabasePriceOfPowerUp.Text = Function.Beautify(Function.DatabaseUpgrade7) + Function.AppendCorrectAbbreviation(Function.DatabaseUpgrade7);
                    if (currentLowest > Function.DatabaseUpgrade7 / (databaseOutputPerUnit * databaseUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Database Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.DatabaseUpgrade7;
                        currentLowest = Function.DatabaseUpgrade7 / (databaseOutputPerUnit * databaseUnitCount);
                    }
                }
                else if (databasePowerUpCount == 7)
                {
                    labelDatabaseUpgradeCost.Text = Function.Beautify(Function.DatabaseUpgrade8 / (databaseOutputPerUnit * databaseUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.DatabaseUpgrade8 / (databaseOutputPerUnit * databaseUnitCount * 0.1m));
                    labelDatabasePriceOfPowerUp.Text = Function.Beautify(Function.DatabaseUpgrade8) + Function.AppendCorrectAbbreviation(Function.DatabaseUpgrade8);
                    if (currentLowest > Function.DatabaseUpgrade8 / (databaseOutputPerUnit * databaseUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Database Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.DatabaseUpgrade8;
                        currentLowest = Function.DatabaseUpgrade8 / (databaseOutputPerUnit * databaseUnitCount);
                    }
                }
                else if (databasePowerUpCount == 8)
                {
                    labelDatabaseUpgradeCost.Text = Function.Beautify(Function.DatabaseUpgrade9 / (databaseOutputPerUnit * databaseUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.DatabaseUpgrade9 / (databaseOutputPerUnit * databaseUnitCount * 0.1m));
                    labelDatabasePriceOfPowerUp.Text = Function.Beautify(Function.DatabaseUpgrade9) + Function.AppendCorrectAbbreviation(Function.DatabaseUpgrade9);
                    if (currentLowest > Function.DatabaseUpgrade9 / (databaseOutputPerUnit * databaseUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Database Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.DatabaseUpgrade9;
                        currentLowest = Function.DatabaseUpgrade9 / (databaseOutputPerUnit * databaseUnitCount);
                    }
                }
            }
        }

        private void UpdateCachePowerUpCosts()
        {
            if (cacheUnitCount != 0)
            {
                if (cachePowerUpCount == 0)
                {
                    labelCacheUpgradeCost.Text = Function.Beautify(Function.CacheUpgrade1 / (cacheOutputPerUnit * cacheUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CacheUpgrade1 / (cacheOutputPerUnit * cacheUnitCount  * 0.1m));
                    labelCachePriceOfPowerUp.Text = Function.Beautify(Function.CacheUpgrade1) + Function.AppendCorrectAbbreviation(Function.CacheUpgrade1);
                    if (currentLowest > Function.CacheUpgrade1 / (cacheOutputPerUnit * cacheUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cache Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CacheUpgrade1;
                        currentLowest = Function.CacheUpgrade1 / (cacheOutputPerUnit * cacheUnitCount);
                    }
                }
                else if (cachePowerUpCount == 1)
                {
                    labelCacheUpgradeCost.Text = Function.Beautify(Function.CacheUpgrade2 / (cacheOutputPerUnit * cacheUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CacheUpgrade2 / (cacheOutputPerUnit * cacheUnitCount  * 0.1m));
                    labelCachePriceOfPowerUp.Text = Function.Beautify(Function.CacheUpgrade2) + Function.AppendCorrectAbbreviation(Function.CacheUpgrade2);
                    if (currentLowest > Function.CacheUpgrade2 / (cacheOutputPerUnit * cacheUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cache Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CacheUpgrade2;
                        currentLowest = Function.CacheUpgrade2 / (cacheOutputPerUnit * cacheUnitCount);
                    }
                }
                else if (cachePowerUpCount == 2)
                {
                    labelCacheUpgradeCost.Text = Function.Beautify(Function.CacheUpgrade3 / (cacheOutputPerUnit * cacheUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CacheUpgrade3 / (cacheOutputPerUnit * cacheUnitCount  * 0.1m));
                    labelCachePriceOfPowerUp.Text = Function.Beautify(Function.CacheUpgrade3) + Function.AppendCorrectAbbreviation(Function.CacheUpgrade3);
                    if (currentLowest > Function.CacheUpgrade3 / (cacheOutputPerUnit * cacheUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cache Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CacheUpgrade3;
                        currentLowest = Function.CacheUpgrade3 / (cacheOutputPerUnit * cacheUnitCount);
                    }
                }
                else if (cachePowerUpCount == 3)
                {
                    labelCacheUpgradeCost.Text = Function.Beautify(Function.CacheUpgrade4 / (cacheOutputPerUnit * cacheUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CacheUpgrade4 / (cacheOutputPerUnit * cacheUnitCount  * 0.1m));
                    labelCachePriceOfPowerUp.Text = Function.Beautify(Function.CacheUpgrade4) + Function.AppendCorrectAbbreviation(Function.CacheUpgrade4);
                    if (currentLowest > Function.CacheUpgrade4 / (cacheOutputPerUnit * cacheUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cache Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CacheUpgrade4;
                        currentLowest = Function.CacheUpgrade4 / (cacheOutputPerUnit * cacheUnitCount);
                    }
                }
                else if (cachePowerUpCount == 4)
                {
                    labelCacheUpgradeCost.Text = Function.Beautify(Function.CacheUpgrade5 / (cacheOutputPerUnit * cacheUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CacheUpgrade5 / (cacheOutputPerUnit * cacheUnitCount * 0.1m));
                    labelCachePriceOfPowerUp.Text = Function.Beautify(Function.CacheUpgrade5) + Function.AppendCorrectAbbreviation(Function.CacheUpgrade5);
                    if (currentLowest > Function.CacheUpgrade5 / (cacheOutputPerUnit * cacheUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cache Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CacheUpgrade5;
                        currentLowest = Function.CacheUpgrade5 / (cacheOutputPerUnit * cacheUnitCount);
                    }
                }
                else if (cachePowerUpCount == 5)
                {
                    labelCacheUpgradeCost.Text = Function.Beautify(Function.CacheUpgrade6 / (cacheOutputPerUnit * cacheUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CacheUpgrade6 / (cacheOutputPerUnit * cacheUnitCount * 0.1m));
                    labelCachePriceOfPowerUp.Text = Function.Beautify(Function.CacheUpgrade6) + Function.AppendCorrectAbbreviation(Function.CacheUpgrade6);
                    if (currentLowest > Function.CacheUpgrade6 / (cacheOutputPerUnit * cacheUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cache Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CacheUpgrade6;
                        currentLowest = Function.CacheUpgrade6 / (cacheOutputPerUnit * cacheUnitCount);
                    }
                }
                else if (cachePowerUpCount == 6)
                {
                    labelCacheUpgradeCost.Text = Function.Beautify(Function.CacheUpgrade7 / (cacheOutputPerUnit * cacheUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CacheUpgrade7 / (cacheOutputPerUnit * cacheUnitCount * 0.1m));
                    labelCachePriceOfPowerUp.Text = Function.Beautify(Function.CacheUpgrade7) + Function.AppendCorrectAbbreviation(Function.CacheUpgrade7);
                    if (currentLowest > Function.CacheUpgrade7 / (cacheOutputPerUnit * cacheUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cache Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CacheUpgrade7;
                        currentLowest = Function.CacheUpgrade7 / (cacheOutputPerUnit * cacheUnitCount);
                    }
                }
            }
        }

        private void UpdateCPUPowerUpCosts()
        {
            if (cpuUnitCount != 0)
            {
                if (cpuPowerUpCount == 0)
                {
                    labelCPUUpgradeCost.Text = Function.Beautify(Function.CPUUpgrade1 / (cpuOutputPerUnit * cpuUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CPUUpgrade1 / (cpuOutputPerUnit * cpuUnitCount  * 0.1m));
                    labelCPUPriceOfPowerUp.Text = Function.Beautify(Function.CPUUpgrade1) + Function.AppendCorrectAbbreviation(Function.CPUUpgrade1);
                    if (currentLowest > Function.CPUUpgrade1 / (cpuOutputPerUnit * cpuUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a CPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CPUUpgrade1;
                        currentLowest = Function.CPUUpgrade1 / (cpuOutputPerUnit * cpuUnitCount);
                    }
                }
                else if (cpuPowerUpCount == 1)
                {
                    labelCPUUpgradeCost.Text = Function.Beautify(Function.CPUUpgrade2 / (cpuOutputPerUnit * cpuUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CPUUpgrade2 / (cpuOutputPerUnit * cpuUnitCount  * 0.1m));
                    labelCPUPriceOfPowerUp.Text = Function.Beautify(Function.CPUUpgrade2) + Function.AppendCorrectAbbreviation(Function.CPUUpgrade2);
                    if (currentLowest > Function.CPUUpgrade2 / (cpuOutputPerUnit * cpuUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a CPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CPUUpgrade2;
                        currentLowest = Function.CPUUpgrade2 / (cpuOutputPerUnit * cpuUnitCount);
                    }
                }
                else if (cpuPowerUpCount == 2)
                {
                    labelCPUUpgradeCost.Text = Function.Beautify(Function.CPUUpgrade3 / (cpuOutputPerUnit * cpuUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CPUUpgrade3 / (cpuOutputPerUnit * cpuUnitCount * 0.1m));
                    labelCPUPriceOfPowerUp.Text = Function.Beautify(Function.CPUUpgrade3) + Function.AppendCorrectAbbreviation(Function.CPUUpgrade3);
                    if (currentLowest > Function.CPUUpgrade3 / (cpuOutputPerUnit * cpuUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a CPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CPUUpgrade3;
                        currentLowest = Function.CPUUpgrade3 / (cpuOutputPerUnit * cpuUnitCount);
                    }
                }
                else if (cpuPowerUpCount == 3)
                {
                    labelCPUUpgradeCost.Text = Function.Beautify(Function.CPUUpgrade4 / (cpuOutputPerUnit * cpuUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CPUUpgrade4 / (cpuOutputPerUnit * cpuUnitCount * 0.1m));
                    labelCPUPriceOfPowerUp.Text = Function.Beautify(Function.CPUUpgrade4) + Function.AppendCorrectAbbreviation(Function.CPUUpgrade4);
                    if (currentLowest > Function.CPUUpgrade4 / (cpuOutputPerUnit * cpuUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a CPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CPUUpgrade4;
                        currentLowest = Function.CPUUpgrade4 / (cpuOutputPerUnit * cpuUnitCount);
                    }
                }
                else if (cpuPowerUpCount == 4)
                {
                    labelCPUUpgradeCost.Text = Function.Beautify(Function.CPUUpgrade5 / (cpuOutputPerUnit * cpuUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CPUUpgrade5 / (cpuOutputPerUnit * cpuUnitCount * 0.1m));
                    labelCPUPriceOfPowerUp.Text = Function.Beautify(Function.CPUUpgrade5) + Function.AppendCorrectAbbreviation(Function.CPUUpgrade5);
                    if (currentLowest > Function.CPUUpgrade5 / (cpuOutputPerUnit * cpuUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a CPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CPUUpgrade5;
                        currentLowest = Function.CPUUpgrade5 / (cpuOutputPerUnit * cpuUnitCount);
                    }
                }
                else if (cpuPowerUpCount == 5)
                {
                    labelCPUUpgradeCost.Text = Function.Beautify(Function.CPUUpgrade6 / (cpuOutputPerUnit * cpuUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CPUUpgrade6 / (cpuOutputPerUnit * cpuUnitCount * 0.1m));
                    labelCPUPriceOfPowerUp.Text = Function.Beautify(Function.CPUUpgrade6) + Function.AppendCorrectAbbreviation(Function.CPUUpgrade6);
                    if (currentLowest > Function.CPUUpgrade6 / (cpuOutputPerUnit * cpuUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a CPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CPUUpgrade6;
                        currentLowest = Function.CPUUpgrade6 / (cpuOutputPerUnit * cpuUnitCount);
                    }
                }
                else if (cpuPowerUpCount == 6)
                {
                    labelCPUUpgradeCost.Text = Function.Beautify(Function.CPUUpgrade7 / (cpuOutputPerUnit * cpuUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CPUUpgrade7 / (cpuOutputPerUnit * cpuUnitCount * 0.1m));
                    labelCPUPriceOfPowerUp.Text = Function.Beautify(Function.CPUUpgrade7) + Function.AppendCorrectAbbreviation(Function.CPUUpgrade7);
                    if (currentLowest > Function.CPUUpgrade7 / (cpuOutputPerUnit * cpuUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a CPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CPUUpgrade7;
                        currentLowest = Function.CPUUpgrade7 / (cpuOutputPerUnit * cpuUnitCount);
                    }
                }
                else if (cpuPowerUpCount == 7)
                {
                    labelCPUUpgradeCost.Text = Function.Beautify(Function.CPUUpgrade8 / (cpuOutputPerUnit * cpuUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CPUUpgrade8 / (cpuOutputPerUnit * cpuUnitCount * 0.1m));
                    labelCPUPriceOfPowerUp.Text = Function.Beautify(Function.CPUUpgrade8) + Function.AppendCorrectAbbreviation(Function.CPUUpgrade8);
                    if (currentLowest > Function.CPUUpgrade8 / (cpuOutputPerUnit * cpuUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a CPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CPUUpgrade8;
                        currentLowest = Function.CPUUpgrade8 / (cpuOutputPerUnit * cpuUnitCount);
                    }
                }
                else if (cpuPowerUpCount == 8)
                {
                    labelCPUUpgradeCost.Text = Function.Beautify(Function.CPUUpgrade9 / (cpuOutputPerUnit * cpuUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CPUUpgrade9 / (cpuOutputPerUnit * cpuUnitCount * 0.1m));
                    labelCPUPriceOfPowerUp.Text = Function.Beautify(Function.CPUUpgrade9) + Function.AppendCorrectAbbreviation(Function.CPUUpgrade9);
                    if (currentLowest > Function.CPUUpgrade9 / (cpuOutputPerUnit * cpuUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a CPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CPUUpgrade9;
                        currentLowest = Function.CPUUpgrade9 / (cpuOutputPerUnit * cpuUnitCount);
                    }
                }
                else if (cpuPowerUpCount == 9)
                {
                    labelCPUUpgradeCost.Text = Function.Beautify(Function.CPUUpgrade10 / (cpuOutputPerUnit * cpuUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.CPUUpgrade10 / (cpuOutputPerUnit * cpuUnitCount * 0.1m));
                    labelCPUPriceOfPowerUp.Text = Function.Beautify(Function.CPUUpgrade10) + Function.AppendCorrectAbbreviation(Function.CPUUpgrade10);
                    if (currentLowest > Function.CPUUpgrade10 / (cpuOutputPerUnit * cpuUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a CPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.CPUUpgrade10;
                        currentLowest = Function.CPUUpgrade10 / (cpuOutputPerUnit * cpuUnitCount);
                    }
                }
            }
        }

        private void UpdateGPUPowerUpCosts()
        {
            if (gpuUnitCount != 0)
            {
                if (gpuPowerUpCount == 0)
                {
                    labelGPUUpgradeCost.Text = Function.Beautify(Function.GPUUpgrade1 / (gpuOutputPerUnit * gpuUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GPUUpgrade1 / (gpuOutputPerUnit * gpuUnitCount  * 0.1m));
                    labelGPUPriceOfPowerUp.Text = Function.Beautify(Function.GPUUpgrade1) + Function.AppendCorrectAbbreviation(Function.GPUUpgrade1);
                    if (currentLowest > Function.GPUUpgrade1 / (gpuOutputPerUnit * gpuUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GPUUpgrade1;
                        currentLowest = Function.GPUUpgrade1 / (gpuOutputPerUnit * gpuUnitCount);
                    }
                }
                else if (gpuPowerUpCount == 1)
                {
                    labelGPUUpgradeCost.Text = Function.Beautify(Function.GPUUpgrade2 / (gpuOutputPerUnit * gpuUnitCount  * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GPUUpgrade2 / (gpuOutputPerUnit * gpuUnitCount  * 0.1m));
                    labelGPUPriceOfPowerUp.Text = Function.Beautify(Function.GPUUpgrade2) + Function.AppendCorrectAbbreviation(Function.GPUUpgrade2);
                    if (currentLowest > Function.GPUUpgrade2 / (gpuOutputPerUnit * gpuUnitCount  * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GPUUpgrade2;
                        currentLowest = Function.GPUUpgrade2 / (gpuOutputPerUnit * gpuUnitCount);
                    }
                }
                else if (gpuPowerUpCount == 2)
                {
                    labelGPUUpgradeCost.Text = Function.Beautify(Function.GPUUpgrade3 / (gpuOutputPerUnit * gpuUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GPUUpgrade3 / (gpuOutputPerUnit * gpuUnitCount * 0.1m));
                    labelGPUPriceOfPowerUp.Text = Function.Beautify(Function.GPUUpgrade3) + Function.AppendCorrectAbbreviation(Function.GPUUpgrade3);
                    if (currentLowest > Function.GPUUpgrade3 / (gpuOutputPerUnit * gpuUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GPUUpgrade3;
                        currentLowest = Function.GPUUpgrade3 / (gpuOutputPerUnit * gpuUnitCount);
                    }
                }
                else if (gpuPowerUpCount == 3)
                {
                    labelGPUUpgradeCost.Text = Function.Beautify(Function.GPUUpgrade4 / (gpuOutputPerUnit * gpuUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GPUUpgrade4 / (gpuOutputPerUnit * gpuUnitCount * 0.1m));
                    labelGPUPriceOfPowerUp.Text = Function.Beautify(Function.GPUUpgrade4) + Function.AppendCorrectAbbreviation(Function.GPUUpgrade4);
                    if (currentLowest > Function.GPUUpgrade4 / (gpuOutputPerUnit * gpuUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GPUUpgrade4;
                        currentLowest = Function.GPUUpgrade4 / (gpuOutputPerUnit * gpuUnitCount);
                    }
                }
                else if (gpuPowerUpCount == 4)
                {
                    labelGPUUpgradeCost.Text = Function.Beautify(Function.GPUUpgrade5 / (gpuOutputPerUnit * gpuUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GPUUpgrade5 / (gpuOutputPerUnit * gpuUnitCount * 0.1m));
                    labelGPUPriceOfPowerUp.Text = Function.Beautify(Function.GPUUpgrade5) + Function.AppendCorrectAbbreviation(Function.GPUUpgrade5);
                    if (currentLowest > Function.GPUUpgrade5 / (gpuOutputPerUnit * gpuUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GPUUpgrade5;
                        currentLowest = Function.GPUUpgrade5 / (gpuOutputPerUnit * gpuUnitCount);
                    }
                }
                else if (gpuPowerUpCount == 5)
                {
                    labelGPUUpgradeCost.Text = Function.Beautify(Function.GPUUpgrade6 / (gpuOutputPerUnit * gpuUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.GPUUpgrade6 / (gpuOutputPerUnit * gpuUnitCount * 0.1m));
                    labelGPUPriceOfPowerUp.Text = Function.Beautify(Function.GPUUpgrade6) + Function.AppendCorrectAbbreviation(Function.GPUUpgrade6);
                    if (currentLowest > Function.GPUUpgrade6 / (gpuOutputPerUnit * gpuUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a GPU Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.GPUUpgrade6;
                        currentLowest = Function.GPUUpgrade6 / (gpuOutputPerUnit * gpuUnitCount);
                    }
                }
            }
        }

        private void UpdateClusterPowerUpCosts()
        {
            if (clusterUnitCount != 0)
            {
                if (clusterPowerUpCount == 0)
                {
                    labelClusterUpgradeCost.Text = Function.Beautify(Function.ClusterUpgrade1 / (clusterOutputPerUnit * clusterUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.ClusterUpgrade1 / (clusterOutputPerUnit * clusterUnitCount * 0.1m));
                    labelClusterPriceOfPowerUp.Text = Function.Beautify(Function.ClusterUpgrade1) + Function.AppendCorrectAbbreviation(Function.ClusterUpgrade1);
                    if (currentLowest > Function.ClusterUpgrade1 / (clusterOutputPerUnit * clusterUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cluster Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.ClusterUpgrade1;
                        currentLowest = Function.ClusterUpgrade1 / (clusterOutputPerUnit * clusterUnitCount);
                    }
                }
                else if (clusterPowerUpCount == 1)
                {
                    labelClusterUpgradeCost.Text = Function.Beautify(Function.ClusterUpgrade2 / (clusterOutputPerUnit * clusterUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.ClusterUpgrade2 / (clusterOutputPerUnit * clusterUnitCount * 0.1m));
                    labelClusterPriceOfPowerUp.Text = Function.Beautify(Function.ClusterUpgrade2) + Function.AppendCorrectAbbreviation(Function.ClusterUpgrade2);
                    if (currentLowest > Function.ClusterUpgrade2 / (clusterOutputPerUnit * clusterUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cluster Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.ClusterUpgrade2;
                        currentLowest = Function.ClusterUpgrade2 / (clusterOutputPerUnit * clusterUnitCount);
                    }
                }
                else if (clusterPowerUpCount == 2)
                {
                    labelClusterUpgradeCost.Text = Function.Beautify(Function.ClusterUpgrade3 / (clusterOutputPerUnit * clusterUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.ClusterUpgrade3 / (clusterOutputPerUnit * clusterUnitCount * 0.1m));
                    labelClusterPriceOfPowerUp.Text = Function.Beautify(Function.ClusterUpgrade3) + Function.AppendCorrectAbbreviation(Function.ClusterUpgrade3);
                    if (currentLowest > Function.ClusterUpgrade3 / (clusterOutputPerUnit * clusterUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cluster Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.ClusterUpgrade3;
                        currentLowest = Function.ClusterUpgrade3 / (clusterOutputPerUnit * clusterUnitCount);
                    }
                }
                else if (clusterPowerUpCount == 3)
                {
                    labelClusterUpgradeCost.Text = Function.Beautify(Function.ClusterUpgrade4 / (clusterOutputPerUnit * clusterUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.ClusterUpgrade4 / (clusterOutputPerUnit * clusterUnitCount * 0.1m));
                    labelClusterPriceOfPowerUp.Text = Function.Beautify(Function.ClusterUpgrade4) + Function.AppendCorrectAbbreviation(Function.ClusterUpgrade4);
                    if (currentLowest > Function.ClusterUpgrade4 / (clusterOutputPerUnit * clusterUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cluster Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.ClusterUpgrade4;
                        currentLowest = Function.ClusterUpgrade4 / (clusterOutputPerUnit * clusterUnitCount);
                    }
                }
                else if (clusterPowerUpCount == 4)
                {
                    labelClusterUpgradeCost.Text = Function.Beautify(Function.ClusterUpgrade5 / (clusterOutputPerUnit * clusterUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.ClusterUpgrade5 / (clusterOutputPerUnit * clusterUnitCount * 0.1m));
                    labelClusterPriceOfPowerUp.Text = Function.Beautify(Function.ClusterUpgrade5) + Function.AppendCorrectAbbreviation(Function.ClusterUpgrade5);
                    if (currentLowest > Function.ClusterUpgrade5 / (clusterOutputPerUnit * clusterUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cluster Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.ClusterUpgrade5;
                        currentLowest = Function.ClusterUpgrade5 / (clusterOutputPerUnit * clusterUnitCount);
                    }
                }
                else if (clusterPowerUpCount == 5)
                {
                    labelClusterUpgradeCost.Text = Function.Beautify(Function.ClusterUpgrade6 / (clusterOutputPerUnit * clusterUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.ClusterUpgrade6 / (clusterOutputPerUnit * clusterUnitCount * 0.1m));
                    labelClusterPriceOfPowerUp.Text = Function.Beautify(Function.ClusterUpgrade6) + Function.AppendCorrectAbbreviation(Function.ClusterUpgrade6);
                    if (currentLowest > Function.ClusterUpgrade6 / (clusterOutputPerUnit * clusterUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Cluster Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.ClusterUpgrade6;
                        currentLowest = Function.ClusterUpgrade6 / (clusterOutputPerUnit * clusterUnitCount);
                    }
                }
            }
        }

        private void UpdateSpringFrameworkPowerUpCosts()
        {
            if (springFrameworkUnitCount != 0)
            {
                if (springFrameworkPowerUpCount == 0)
                {
                    labelSpringFrameworkUpgradeCost.Text = Function.Beautify(Function.SpringFrameworkUpgrade1 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.SpringFrameworkUpgrade1 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m));
                    labelSpringFrameworkPriceOfPowerUp.Text = Function.Beautify(Function.SpringFrameworkUpgrade1) + Function.AppendCorrectAbbreviation(Function.SpringFrameworkUpgrade1);
                    if (currentLowest > Function.SpringFrameworkUpgrade1 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Spring Framework Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.SpringFrameworkUpgrade1;
                        currentLowest = Function.SpringFrameworkUpgrade1 / (springFrameworkOutputPerUnit * springFrameworkUnitCount);
                    }
                }
                else if (springFrameworkPowerUpCount == 1)
                {
                    labelSpringFrameworkUpgradeCost.Text = Function.Beautify(Function.SpringFrameworkUpgrade2 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.SpringFrameworkUpgrade2 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m));
                    labelSpringFrameworkPriceOfPowerUp.Text = Function.Beautify(Function.SpringFrameworkUpgrade2) + Function.AppendCorrectAbbreviation(Function.SpringFrameworkUpgrade2);
                    if (currentLowest > Function.SpringFrameworkUpgrade2 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Spring Framework Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.SpringFrameworkUpgrade2;
                        currentLowest = Function.SpringFrameworkUpgrade2 / (springFrameworkOutputPerUnit * springFrameworkUnitCount);
                    }
                }
                else if (springFrameworkPowerUpCount == 2)
                {   





                    labelSpringFrameworkUpgradeCost.Text = Function.Beautify(Function.SpringFrameworkUpgrade3 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.SpringFrameworkUpgrade3 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m));
                    labelSpringFrameworkPriceOfPowerUp.Text = Function.Beautify(Function.SpringFrameworkUpgrade3) + Function.AppendCorrectAbbreviation(Function.SpringFrameworkUpgrade3);
                    if (currentLowest > Function.SpringFrameworkUpgrade3 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Spring Framework Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.SpringFrameworkUpgrade3;
                        currentLowest = Function.SpringFrameworkUpgrade3 / (springFrameworkOutputPerUnit * springFrameworkUnitCount);
                    }
                }
                else if (springFrameworkPowerUpCount == 3)
                {
                    labelSpringFrameworkUpgradeCost.Text = Function.Beautify(Function.SpringFrameworkUpgrade4 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.SpringFrameworkUpgrade4 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m));
                    labelSpringFrameworkPriceOfPowerUp.Text = Function.Beautify(Function.SpringFrameworkUpgrade4) + Function.AppendCorrectAbbreviation(Function.SpringFrameworkUpgrade4);
                    if (currentLowest > Function.SpringFrameworkUpgrade4 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Spring Framework Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.SpringFrameworkUpgrade4;
                        currentLowest = Function.SpringFrameworkUpgrade4 / (springFrameworkOutputPerUnit * springFrameworkUnitCount);
                    }
                }
                else if (springFrameworkPowerUpCount == 4)
                {
                    labelSpringFrameworkUpgradeCost.Text = Function.Beautify(Function.SpringFrameworkUpgrade5 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.SpringFrameworkUpgrade5 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m));
                    labelSpringFrameworkPriceOfPowerUp.Text = Function.Beautify(Function.SpringFrameworkUpgrade5) + Function.AppendCorrectAbbreviation(Function.SpringFrameworkUpgrade5);
                    if (currentLowest > Function.SpringFrameworkUpgrade5 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Spring Framework Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.SpringFrameworkUpgrade5;
                        currentLowest = Function.SpringFrameworkUpgrade5 / (springFrameworkOutputPerUnit * springFrameworkUnitCount);
                    }
                }
                else if (springFrameworkPowerUpCount == 5)
                {
                    labelSpringFrameworkUpgradeCost.Text = Function.Beautify(Function.SpringFrameworkUpgrade6 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.SpringFrameworkUpgrade6 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m));
                    labelSpringFrameworkPriceOfPowerUp.Text = Function.Beautify(Function.SpringFrameworkUpgrade6) + Function.AppendCorrectAbbreviation(Function.SpringFrameworkUpgrade6);
                    if (currentLowest > Function.SpringFrameworkUpgrade6 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Spring Framework Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.SpringFrameworkUpgrade6;
                        currentLowest = Function.SpringFrameworkUpgrade6 / (springFrameworkOutputPerUnit * springFrameworkUnitCount);
                    }
                }
                else if (springFrameworkPowerUpCount == 6)
                {
                    labelSpringFrameworkUpgradeCost.Text = Function.Beautify(Function.SpringFrameworkUpgrade7 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.SpringFrameworkUpgrade7 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m));
                    labelSpringFrameworkPriceOfPowerUp.Text = Function.Beautify(Function.SpringFrameworkUpgrade7) + Function.AppendCorrectAbbreviation(Function.SpringFrameworkUpgrade7);
                    if (currentLowest > Function.SpringFrameworkUpgrade7 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Spring Framework Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.SpringFrameworkUpgrade7;
                        currentLowest = Function.SpringFrameworkUpgrade7 / (springFrameworkOutputPerUnit * springFrameworkUnitCount);
                    }
                }
                else if (springFrameworkPowerUpCount == 7)
                {
                    labelSpringFrameworkUpgradeCost.Text = Function.Beautify(Function.SpringFrameworkUpgrade8 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.SpringFrameworkUpgrade8 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m));
                    labelSpringFrameworkPriceOfPowerUp.Text = Function.Beautify(Function.SpringFrameworkUpgrade8) + Function.AppendCorrectAbbreviation(Function.SpringFrameworkUpgrade8);
                    if (currentLowest > Function.SpringFrameworkUpgrade8 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Spring Framework Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.SpringFrameworkUpgrade8;
                        currentLowest = Function.SpringFrameworkUpgrade8 / (springFrameworkOutputPerUnit * springFrameworkUnitCount);
                    }
                }
                else if (springFrameworkPowerUpCount == 8)
                {
                    labelSpringFrameworkUpgradeCost.Text = Function.Beautify(Function.SpringFrameworkUpgrade9 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m)) + Function.AppendCorrectAbbreviationCost(Function.SpringFrameworkUpgrade9 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m));
                    labelSpringFrameworkPriceOfPowerUp.Text = Function.Beautify(Function.SpringFrameworkUpgrade9) + Function.AppendCorrectAbbreviation(Function.SpringFrameworkUpgrade9);
                    if (currentLowest > Function.SpringFrameworkUpgrade9 / (springFrameworkOutputPerUnit * springFrameworkUnitCount * 0.1m))
                    {
                        labelRecommendation.Text = "You should now buy a Spring Framework Power Up for optimal BPS increase.";
                        priceOfNext = (long)Function.SpringFrameworkUpgrade9;
                        currentLowest = Function.SpringFrameworkUpgrade9 / (springFrameworkOutputPerUnit * springFrameworkUnitCount);
                    }
                }
            }
        }


        #endregion

        private void UpdateTime()
        {
            try
            {
                capacity = long.Parse(textBoxCapacity.Text);
            }
            catch (Exception)
            {
                noClicksPerSecond = 0;
                System.Windows.Forms.MessageBox.Show("You entered an invalid value for the capacity. Numbers only please!");
            }

            if (totalPower == 0)
                labelTimeTakenReal.Text = "No Power!";
            else if (capacity != 0)
            {
                long totalSecondsToMax = (long)(capacity / totalPower);
                long secondsToMax = totalSecondsToMax % 60;
                long minutesToMax = (totalSecondsToMax / 60) % 60;
                long hoursToMax = (totalSecondsToMax / (60 * 60)) % 60;

                labelTimeTakenReal.Text = hoursToMax + " Hours, " + minutesToMax + " Minutes and " + secondsToMax + " Seconds.";
            }
            else 
            {
                labelTimeTakenReal.Text = "No capacity specified!";
            }
        }

        private void ResetAll()
        {
            noClicksPerSecond = 2;

            cursorUnitCount = 0;
            brogrammerUnitCount = 0;
            gcfailureUnitCount = 0;
            memoryleakUnitCount = 0;
            messagequeueUnitCount = 0;
            databaseUnitCount = 0;
            cacheUnitCount = 0;
            cpuUnitCount = 0;
            gpuUnitCount = 0;
            clusterUnitCount = 0;
            springFrameworkUnitCount = 0;
            cursorPowerUpCount = 0;
            brogrammerPowerUpCount = 0;
            gcfailurePowerUpCount = 0;
            memoryleakPowerUpCount = 0;
            messagequeuePowerUpCount = 0;
            databasePowerUpCount = 0;
            cachePowerUpCount = 0;
            cpuPowerUpCount = 0;
            gpuPowerUpCount = 0;
            clusterPowerUpCount = 0;
            springFrameworkPowerUpCount = 0;

            cursorCurrentRealPrice = Function.StartingPriceCursor;
            brogrammerCurrentRealPrice = Function.StartingPriceBrogrammer;
            gcfailureCurrentRealPrice = Function.StartingPriceGCFailure;
            memoryleakCurrentRealPrice = Function.StartingPriceMemoryLeak;
            messagequeueCurrentRealPrice = Function.StartingPriceMessageQueue;
            databaseCurrentRealPrice = Function.StartingPriceDatabase;
            cacheCurrentRealPrice = Function.StartingPriceCache;
            cpuCurrentRealPrice = Function.StartingPriceCPU;
            gpuCurrentRealPrice = Function.StartingPriceGPU;
            clusterCurrentRealPrice = Function.StartingPriceCluster;
            springFrameworkCurrentRealPrice = Function.StartingPriceSpringFramework;

            cursorOutputPerUnit = (decimal)Function.StartingBPSCursor;
            brogrammerOutputPerUnit = (decimal)Function.StartingBPSBrogrammer;
            gcfailureOutputPerUnit = (decimal)Function.StartingBPSGCFailure;
            memoryleakOutputPerUnit = (decimal)Function.StartingBPSMemoryLeak;
            messagequeueOutputPerUnit = (decimal)Function.StartingBPSMessageQueue;
            databaseOutputPerUnit = (decimal)Function.StartingBPSDatabase;
            cacheOutputPerUnit = (decimal)Function.StartingBPSCache;
            cpuOutputPerUnit = (decimal)Function.StartingBPSCPU;
            gpuOutputPerUnit = (decimal)Function.StartingBPSGPU;
            clusterOutputPerUnit = (decimal)Function.StartingBPSCluster;
            springFrameworkOutputPerUnit = (decimal)Function.StartingBPSSpringFramework;

            cursorCurrentPrettyPrice = Function.Beautify(cursorCurrentRealPrice) + Function.AppendCorrectAbbreviation(cursorCurrentRealPrice);
            brogrammerCurrentPrettyPrice = Function.Beautify(brogrammerCurrentRealPrice) + Function.AppendCorrectAbbreviation(brogrammerCurrentRealPrice);
            gcfailureCurrentPrettyPrice = Function.Beautify(gcfailureCurrentRealPrice) + Function.AppendCorrectAbbreviation(gcfailureCurrentRealPrice);
            memoryleakCurrentPrettyPrice = Function.Beautify(memoryleakCurrentRealPrice) + Function.AppendCorrectAbbreviation(memoryleakCurrentRealPrice);
            messagequeueCurrentPrettyPrice = Function.Beautify(messagequeueCurrentRealPrice) + Function.AppendCorrectAbbreviation(messagequeueCurrentRealPrice);
            databaseCurrentPrettyPrice = Function.Beautify(databaseCurrentRealPrice) + Function.AppendCorrectAbbreviation(databaseCurrentRealPrice);
            cacheCurrentPrettyPrice = Function.Beautify(cacheCurrentRealPrice) + Function.AppendCorrectAbbreviation(cacheCurrentRealPrice);
            cpuCurrentPrettyPrice = Function.Beautify(cpuCurrentRealPrice) + Function.AppendCorrectAbbreviation(cpuCurrentRealPrice);
            gpuCurrentPrettyPrice = Function.Beautify(gpuCurrentRealPrice) + Function.AppendCorrectAbbreviation(gpuCurrentRealPrice);
            clusterCurrentPrettyPrice = Function.Beautify(clusterCurrentRealPrice) + Function.AppendCorrectAbbreviation(clusterCurrentRealPrice);
            springFrameworkCurrentPrettyPrice = Function.Beautify(springFrameworkCurrentRealPrice) + Function.AppendCorrectAbbreviation(springFrameworkCurrentRealPrice);

            buttonCursorBuyPowerUp.Enabled = true;
            buttonBrogrammerBuyPowerUp.Enabled = true;
            buttonGCFailureBuyPowerUp.Enabled = true;
            buttonMemoryLeakBuyPowerUp.Enabled = true;
            buttonMessageQueueBuyPowerUp.Enabled = true;
            buttonDatabaseBuyPowerUp.Enabled = true;
            buttonCacheBuyPowerUp.Enabled = true;
            buttonCPUBuyPowerUp.Enabled = true;
            buttonGPUBuyPowerUp.Enabled = true;
            buttonClusterBuyPowerUp.Enabled = true;
            buttonSpringFrameworkBuyPowerUp.Enabled = true;

            labelCursorPriceOfPowerUp.Text = Function.Beautify(Function.ReturnPowerUpCostCursor(1)) + Function.AppendCorrectAbbreviation(Function.ReturnPowerUpCostCursor(1));
            labelBrogrammerPriceOfPowerUp.Text = Function.Beautify(Function.ReturnPowerUpCostBrogrammer(1)) + Function.AppendCorrectAbbreviation(Function.ReturnPowerUpCostBrogrammer(1));
            labelGCFailurePriceOfPowerUp.Text = Function.Beautify(Function.ReturnPowerUpCostGCFailure(1)) + Function.AppendCorrectAbbreviation(Function.ReturnPowerUpCostGCFailure(1));
            labelMemoryLeakPriceOfPowerUp.Text = Function.Beautify(Function.ReturnPowerUpCostMemoryLeak(1)) + Function.AppendCorrectAbbreviation(Function.ReturnPowerUpCostMemoryLeak(1));
            labelMessageQueuePriceOfPowerUp.Text = Function.Beautify(Function.ReturnPowerUpCostMessageQueue(1)) + Function.AppendCorrectAbbreviation(Function.ReturnPowerUpCostMessageQueue(1));
            labelDatabasePriceOfPowerUp.Text = Function.Beautify(Function.ReturnPowerUpCostDatabase(1)) + Function.AppendCorrectAbbreviation(Function.ReturnPowerUpCostDatabase(1));
            labelCachePriceOfPowerUp.Text = Function.Beautify(Function.ReturnPowerUpCostCache(1)) + Function.AppendCorrectAbbreviation(Function.ReturnPowerUpCostCache(1));
            labelCPUPriceOfPowerUp.Text = Function.Beautify(Function.ReturnPowerUpCostCPU(1)) + Function.AppendCorrectAbbreviation(Function.ReturnPowerUpCostCPU(1));
            labelGPUPriceOfPowerUp.Text = Function.Beautify(Function.ReturnPowerUpCostGPU(1)) + Function.AppendCorrectAbbreviation(Function.ReturnPowerUpCostGPU(1));
            labelClusterPriceOfPowerUp.Text = Function.Beautify(Function.ReturnPowerUpCostCluster(1)) + Function.AppendCorrectAbbreviation(Function.ReturnPowerUpCostCluster(1));
            labelSpringFrameworkPriceOfPowerUp.Text = Function.Beautify(Function.ReturnPowerUpCostSpringFramework(1)) + Function.AppendCorrectAbbreviation(Function.ReturnPowerUpCostSpringFramework(1));

            labelCursorUpgradeCost.Text = "0";
            labelBrogrammerUpgradeCost.Text = "0";
            labelGCFailureUpgradeCost.Text = "0";
            labelMemoryLeakUpgradeCost.Text = "0";
            labelMessageQueueUpgradeCost.Text = "0";
            labelDatabaseUpgradeCost.Text = "0";
            labelCacheUpgradeCost.Text = "0";
            labelCPUUpgradeCost.Text = "0";
            labelGPUUpgradeCost.Text = "0";
            labelClusterUpgradeCost.Text = "0";
            labelSpringFrameworkUpgradeCost.Text = "0";

            bytesSpent = 0;
            priceOfNext = 0;

            UpdateAll();
        }

        #endregion

        #region Events

        public DripStatCalculator()
        {
            InitializeComponent();
        }

        private void DripStatCalculator_Load(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void buttonBuyUnit_Click(object sender, EventArgs e)
        {
            if (sender.Equals(buttonCursorBuyUnit))
            {
                cursorUnitCount++;
                bytesSpent += (long)cursorCurrentRealPrice;
                cursorCurrentRealPrice *= Function.Multiplier;
                cursorCurrentRealPrice = Function.BeautifyButKeepLength(cursorCurrentRealPrice);
                cursorCurrentPrettyPrice = Function.Beautify(cursorCurrentRealPrice) + Function.AppendCorrectAbbreviation(cursorCurrentRealPrice);
            }
            else if (sender.Equals(buttonBrogrammerBuyUnit))
            {
                brogrammerUnitCount++;
                bytesSpent += (long)brogrammerCurrentRealPrice;
                if (brogrammerUnitCount == 1)
                {
                    brogrammerCurrentRealPrice = 111;
                }
                else 
                {
                    brogrammerCurrentRealPrice *= Function.Multiplier;
                    brogrammerCurrentRealPrice = Function.BeautifyButKeepLength(brogrammerCurrentRealPrice);
                }
                brogrammerCurrentPrettyPrice = Function.Beautify(brogrammerCurrentRealPrice) + Function.AppendCorrectAbbreviation(brogrammerCurrentRealPrice);
            }
            else if (sender.Equals(buttonGCFailureBuyUnit))
            {
                gcfailureUnitCount++;
                bytesSpent += (long)gcfailureCurrentRealPrice;
                gcfailureCurrentRealPrice *= Function.Multiplier;
                gcfailureCurrentRealPrice = Function.BeautifyButKeepLength(gcfailureCurrentRealPrice);
                gcfailureCurrentPrettyPrice = Function.Beautify(gcfailureCurrentRealPrice) + Function.AppendCorrectAbbreviation(gcfailureCurrentRealPrice);
            }
            else if (sender.Equals(buttonMemoryLeakBuyUnit))
            {
                memoryleakUnitCount++;
                bytesSpent += (long)memoryleakCurrentRealPrice;
                memoryleakCurrentRealPrice *= Function.Multiplier;
                memoryleakCurrentRealPrice = Function.BeautifyButKeepLength(memoryleakCurrentRealPrice);
                memoryleakCurrentPrettyPrice = Function.Beautify(memoryleakCurrentRealPrice) + Function.AppendCorrectAbbreviation(memoryleakCurrentRealPrice);
            }
            else if (sender.Equals(buttonMessageQueueBuyUnit))
            {
                messagequeueUnitCount++;
                bytesSpent += (long)messagequeueCurrentRealPrice;
                messagequeueCurrentRealPrice *= Function.Multiplier;
                messagequeueCurrentRealPrice = Function.BeautifyButKeepLength(messagequeueCurrentRealPrice);
                messagequeueCurrentPrettyPrice = Function.Beautify(messagequeueCurrentRealPrice) + Function.AppendCorrectAbbreviation(messagequeueCurrentRealPrice);
            }
            else if (sender.Equals(buttonDatabaseBuyUnit))
            {
                databaseUnitCount++;
                bytesSpent += (long)databaseCurrentRealPrice;
                databaseCurrentRealPrice *= Function.Multiplier;
                databaseCurrentRealPrice = Function.BeautifyButKeepLength(databaseCurrentRealPrice);
                databaseCurrentPrettyPrice = Function.Beautify(databaseCurrentRealPrice) + Function.AppendCorrectAbbreviation(databaseCurrentRealPrice);
            }
            else if (sender.Equals(buttonCacheBuyUnit))
            {
                cacheUnitCount++;
                bytesSpent += (long)cacheCurrentRealPrice;
                cacheCurrentRealPrice *= Function.Multiplier;
                cacheCurrentRealPrice = Function.BeautifyButKeepLength(cacheCurrentRealPrice);
                cacheCurrentPrettyPrice = Function.Beautify(cacheCurrentRealPrice) + Function.AppendCorrectAbbreviation(cacheCurrentRealPrice);
            }
            else if (sender.Equals(buttonCPUBuyUnit))
            {
                cpuUnitCount++;
                bytesSpent += (long)cpuCurrentRealPrice;
                cpuCurrentRealPrice *= Function.Multiplier;
                cpuCurrentRealPrice = Function.BeautifyButKeepLength(cpuCurrentRealPrice);
                cpuCurrentPrettyPrice = Function.Beautify(cpuCurrentRealPrice) + Function.AppendCorrectAbbreviation(cpuCurrentRealPrice);
            }
            else if (sender.Equals(buttonGPUBuyUnit))
            {
                gpuUnitCount++;
                bytesSpent += (long)gpuCurrentRealPrice;
                gpuCurrentRealPrice *= Function.Multiplier;
                gpuCurrentRealPrice = Function.BeautifyButKeepLength(gpuCurrentRealPrice);
                gpuCurrentPrettyPrice = Function.Beautify(gpuCurrentRealPrice) + Function.AppendCorrectAbbreviation(gpuCurrentRealPrice);
            }
            else if (sender.Equals(buttonClusterBuyUnit))
            {
                clusterUnitCount++;
                bytesSpent += (long)clusterCurrentRealPrice;
                clusterCurrentRealPrice *= Function.Multiplier;
                clusterCurrentRealPrice = Function.BeautifyButKeepLength(clusterCurrentRealPrice);
                clusterCurrentPrettyPrice = Function.Beautify(clusterCurrentRealPrice) + Function.AppendCorrectAbbreviation(clusterCurrentRealPrice);
            }
            else if (sender.Equals(buttonSpringFrameworkBuyUnit))
            {
                springFrameworkUnitCount++;
                bytesSpent += (long)springFrameworkCurrentRealPrice;
                springFrameworkCurrentRealPrice *= Function.Multiplier;
                springFrameworkCurrentRealPrice = Function.BeautifyButKeepLength(springFrameworkCurrentRealPrice);
                springFrameworkCurrentPrettyPrice = Function.Beautify(springFrameworkCurrentRealPrice) + Function.AppendCorrectAbbreviation(springFrameworkCurrentRealPrice);
            }
            UpdateAll();
        }

        private void buttonBuyPowerUp_Click(object sender, EventArgs e)
        {
            if (sender.Equals(buttonCursorBuyPowerUp))
            {
                cursorPowerUpCount++;
                bytesSpent += Function.ReturnPowerUpCostCursor(cursorPowerUpCount);
                cursorOutputPerUnit *= Function.Multiplier;
                if (cursorPowerUpCount == Function.NumberOfCursorUpgrades)
                {
                    buttonCursorBuyPowerUp.Enabled = false;
                    labelCursorUpgradeCost.Text = "All Bought!";
                    labelCursorPriceOfPowerUp.Text = "All Bought!";
                }
            }
            else if (sender.Equals(buttonBrogrammerBuyPowerUp))
            {
                brogrammerPowerUpCount++;
                bytesSpent += Function.ReturnPowerUpCostBrogrammer(brogrammerPowerUpCount);
                brogrammerOutputPerUnit *= Function.Multiplier;
                if (brogrammerPowerUpCount == Function.NumberOfBrogrammerUpgrades)
                {
                    buttonBrogrammerBuyPowerUp.Enabled = false;
                    labelBrogrammerUpgradeCost.Text = "All Bought!";
                    labelBrogrammerPriceOfPowerUp.Text = "All Bought!";
                }
            }
            else if (sender.Equals(buttonGCFailureBuyPowerUp))
            {
                gcfailurePowerUpCount++;
                bytesSpent += Function.ReturnPowerUpCostGCFailure(gcfailurePowerUpCount);
                gcfailureOutputPerUnit *= Function.Multiplier;
                if (gcfailurePowerUpCount == Function.NumberOfGCFailureUpgrades)
                {
                    buttonGCFailureBuyPowerUp.Enabled = false;
                    labelGCFailureUpgradeCost.Text = "All Bought!";
                    labelGCFailurePriceOfPowerUp.Text = "All Bought!";
                }
            }
            else if (sender.Equals(buttonMemoryLeakBuyPowerUp))
            {
                memoryleakPowerUpCount++;
                bytesSpent += Function.ReturnPowerUpCostMemoryLeak(memoryleakPowerUpCount);
                memoryleakOutputPerUnit *= Function.Multiplier;
                if (memoryleakPowerUpCount == Function.NumberOfMemoryLeakUpgrades)
                {
                    buttonMemoryLeakBuyPowerUp.Enabled = false;
                    labelMemoryLeakUpgradeCost.Text = "All Bought!";
                    labelMemoryLeakPriceOfPowerUp.Text = "All Bought!";
                }
            }
            else if (sender.Equals(buttonMessageQueueBuyPowerUp))
            {
                messagequeuePowerUpCount++;
                bytesSpent += Function.ReturnPowerUpCostMessageQueue(messagequeuePowerUpCount);
                messagequeueOutputPerUnit *= Function.Multiplier;
                if (messagequeuePowerUpCount == Function.NumberOfMessageQueueUpgrades)
                {
                    buttonMessageQueueBuyPowerUp.Enabled = false;
                    labelMessageQueueUpgradeCost.Text = "All Bought!";
                    labelMessageQueuePriceOfPowerUp.Text = "All Bought!";
                }
            }
            else if (sender.Equals(buttonDatabaseBuyPowerUp))
            {
                databasePowerUpCount++;
                bytesSpent += Function.ReturnPowerUpCostDatabase(databasePowerUpCount);
                databaseOutputPerUnit *= Function.Multiplier;
                if (databasePowerUpCount == Function.NumberOfDatabaseUpgrades)
                {
                    buttonDatabaseBuyPowerUp.Enabled = false;
                    labelDatabaseUpgradeCost.Text = "All Bought!";
                    labelDatabasePriceOfPowerUp.Text = "All Bought!";
                }
            }
            else if (sender.Equals(buttonCacheBuyPowerUp))
            {
                cachePowerUpCount++;
                bytesSpent += Function.ReturnPowerUpCostCache(cachePowerUpCount);
                cacheOutputPerUnit *= Function.Multiplier;
                if (cachePowerUpCount == Function.NumberOfCacheUpgrades)
                {
                    buttonCacheBuyPowerUp.Enabled = false;
                    labelCacheUpgradeCost.Text = "All Bought!";
                    labelCachePriceOfPowerUp.Text = "All Bought!";
                }
            }
            else if (sender.Equals(buttonCPUBuyPowerUp))
            {
                cpuPowerUpCount++;
                bytesSpent += Function.ReturnPowerUpCostCPU(cpuPowerUpCount);
                cpuOutputPerUnit *= Function.Multiplier;
                if (cpuPowerUpCount == Function.NumberOfCPUUpgrades)
                {
                    buttonCPUBuyPowerUp.Enabled = false;
                    labelCPUUpgradeCost.Text = "All Bought!";
                    labelCPUPriceOfPowerUp.Text = "All Bought!";
                }
            }
            else if (sender.Equals(buttonGPUBuyPowerUp))
            {
                gpuPowerUpCount++;
                bytesSpent += Function.ReturnPowerUpCostGPU(gpuPowerUpCount);
                gpuOutputPerUnit *= Function.Multiplier;
                if (gpuPowerUpCount == Function.NumberOfGPUUpgrades)
                {
                    buttonGPUBuyPowerUp.Enabled = false;
                    labelGPUUpgradeCost.Text = "All Bought!";
                    labelGPUPriceOfPowerUp.Text = "All Bought!";
                }
            }
            else if (sender.Equals(buttonClusterBuyPowerUp))
            {
                clusterPowerUpCount++;
                bytesSpent += Function.ReturnPowerUpCostCluster(clusterPowerUpCount);
                clusterOutputPerUnit *= Function.Multiplier;
                if (clusterPowerUpCount == Function.NumberOfClusterUpgrades)
                {
                    buttonClusterBuyPowerUp.Enabled = false;
                    labelClusterUpgradeCost.Text = "All Bought!";
                    labelClusterPriceOfPowerUp.Text = "All Bought!";
                }
            }
            else if (sender.Equals(buttonSpringFrameworkBuyPowerUp))
            {
                springFrameworkPowerUpCount++;
                bytesSpent += Function.ReturnPowerUpCostSpringFramework(springFrameworkPowerUpCount);
                springFrameworkOutputPerUnit *= Function.Multiplier;
                if (springFrameworkPowerUpCount == Function.NumberOfSpringFrameworkUpgrades)
                {
                    buttonSpringFrameworkBuyPowerUp.Enabled = false;
                    labelSpringFrameworkUpgradeCost.Text = "All Bought!";
                    labelSpringFrameworkPriceOfPowerUp.Text = "All Bought!";
                }
            }
            UpdateAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxClicksPerSecond.Text != "")
            {
                try
                {
                    noClicksPerSecond = int.Parse(textBoxClicksPerSecond.Text);
                    if (noClicksPerSecond > 3 && cursorPowerUpCount != 7)
                    {
                        System.Windows.Forms.MessageBox.Show("Please bear in mind that increasing the Click Per Second to values over 3 causes the system to heavily favour Cursor upgrades. While Cursor upgrades are better than all others, the favouring might be too extreme. Consider setting this value to 1 or 2 instead, while not maxed out on Cursor Power Ups.");
                    }
                }
                catch (Exception)
                {
                    noClicksPerSecond = 0;
                    System.Windows.Forms.MessageBox.Show("You entered an invalid value for clicks per second.");
                }
                UpdateAll();
            }
        }

        private void buttonResetSpendings_Click(object sender, EventArgs e)
        {
            bytesSpent = 0;
            UpdateAll();
        }

        #endregion

        private void textBoxCapacity_TextChanged(object sender, EventArgs e)
        {
            if(textBoxCapacity.Text != "")
                UpdateTime();
        }

        private void buttonFAQ_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("This program is updated for Level 4 of the DripStat Game at www.dripstat.com/game. Updates will come when new levels are available." 
                + Environment.NewLine + Environment.NewLine + "Version 1.0.0.1:" + Environment.NewLine + "- Fixed a bug causing upgrades for GC Failures Power Up Level 2 to be too desirable."
                + Environment.NewLine + Environment.NewLine + "Version 1.0.0.2:" + Environment.NewLine + "- Fixed a bug causing upgrades for CPU Power Up Level 3 to be too desirable, also fixed a crash."
                + Environment.NewLine + Environment.NewLine + "Version 1.0.0.4:" + Environment.NewLine + "- Fixed a bug crashing the program on resets and added time till next item is purchaseable."
                + Environment.NewLine + Environment.NewLine + "Version 1.0.0.5:" + Environment.NewLine + "- Added Spring Framework to the program.");
        }

        private void buttonResetAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset all?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ResetAll();
            }
        }

        private void buttonBugReport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will redirect you to the bug reporting/suggestions webpage. Do you want to continue?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string target = "https://docs.google.com/forms/d/1mCVAJcGCKMrlGm5xlxGHjW_RyezQcOKn_iv1nct5qFU/viewform";

                try
                {
                    System.Diagnostics.Process.Start(target);
                }
                catch
                    (
                     System.ComponentModel.Win32Exception noBrowser)
                {
                    if (noBrowser.ErrorCode == -2147467259)
                        MessageBox.Show(noBrowser.Message);
                }
                catch (System.Exception other)
                {
                    MessageBox.Show(other.Message);
                }
            }
        }

        

    }
}
