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
        int cursorUnitCount, brogrammerUnitCount, gcfailureUnitCount, memoryleakUnitCount, messagequeueUnitCount, databaseUnitCount, cacheUnitCount, cpuUnitCount, gpuUnitCount, clusterUnitCount;
        int cursorPowerUpCount, brogrammerPowerUpCount, gcfailurePowerUpCount, memoryleakPowerUpCount, messagequeuePowerUpCount, databasePowerUpCount, cachePowerUpCount, cpuPowerUpCount, gpuPowerUpCount, clusterPowerUpCount;
        decimal cursorCurrentRealPrice, brogrammerCurrentRealPrice, gcfailureCurrentRealPrice, memoryleakCurrentRealPrice, messagequeueCurrentRealPrice, databaseCurrentRealPrice, cacheCurrentRealPrice, cpuCurrentRealPrice, gpuCurrentRealPrice, clusterCurrentRealPrice;
        string cursorCurrentPrettyPrice, brogrammerCurrentPrettyPrice, gcfailureCurrentPrettyPrice, memoryleakCurrentPrettyPrice, messagequeueCurrentPrettyPrice, databaseCurrentPrettyPrice, cacheCurrentPrettyPrice, cpuCurrentPrettyPrice, gpuCurrentPrettyPrice, clusterCurrentPrettyPrice;
        decimal cursorOutputPerUnit, brogrammerOutputPerUnit, gcfailureOutputPerUnit, memoryleakOutputPerUnit, messagequeueOutputPerUnit, databaseOutputPerUnit, cacheOutputPerUnit, cpuOutputPerUnit, gpuOutputPerUnit, clusterOutputPerUnit;
        int noClicksPerSecond;

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
        }

        private void UpdatePowerUpEffect()
        {
            UpdatePowerPerUnit();
            UpdatePowerTotal();
        }

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
        }

        private void UpdateUnitCost()
        {
            labelCursorUnitCost.Text = Function.Beautify(cursorCurrentRealPrice / cursorOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(cursorCurrentRealPrice / cursorOutputPerUnit);
            labelBrogrammerUnitCost.Text = Function.Beautify(brogrammerCurrentRealPrice / brogrammerOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(brogrammerCurrentRealPrice / brogrammerOutputPerUnit);
            labelGCFailureUnitCost.Text = Function.Beautify(gcfailureCurrentRealPrice / gcfailureOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(gcfailureCurrentRealPrice / gcfailureOutputPerUnit);
            labelMemoryLeakUnitCost.Text = Function.Beautify(memoryleakCurrentRealPrice / memoryleakOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(memoryleakCurrentRealPrice / memoryleakOutputPerUnit);
            labelMessageQueueUnitCost.Text = Function.Beautify(messagequeueCurrentRealPrice / messagequeueOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(messagequeueCurrentRealPrice / messagequeueOutputPerUnit);
            labelDatabaseUnitCost.Text = Function.Beautify(databaseCurrentRealPrice / databaseOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(databaseCurrentRealPrice / databaseOutputPerUnit);
            labelCacheUnitCost.Text = Function.Beautify(cacheCurrentRealPrice / cacheOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(cacheCurrentRealPrice / cacheOutputPerUnit);
            labelCPUUnitCost.Text = Function.Beautify(cpuCurrentRealPrice / cpuOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(cpuCurrentRealPrice / cpuOutputPerUnit);
            labelGPUUnitCost.Text = Function.Beautify(gpuCurrentRealPrice / gpuOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(gpuCurrentRealPrice / gpuOutputPerUnit);
            labelClusterUnitCost.Text = Function.Beautify(clusterCurrentRealPrice / clusterOutputPerUnit) + Function.AppendCorrectAbbreviationBPS(clusterCurrentRealPrice / clusterOutputPerUnit);
        }

        private void UpdateRecommendation()
        {

            decimal currentLowest = cursorCurrentRealPrice / cursorOutputPerUnit;
            labelRecommendation.Text = "You should now buy a Cursor for optimal BPS increase.";

            if (currentLowest > brogrammerCurrentRealPrice / brogrammerOutputPerUnit) 
            {
                currentLowest = brogrammerCurrentRealPrice / brogrammerOutputPerUnit;
                labelRecommendation.Text = "You should now buy a Brogrammer for optimal BPS increase.";
            }
            if (currentLowest > gcfailureCurrentRealPrice / gcfailureOutputPerUnit) 
                {
                    currentLowest = gcfailureCurrentRealPrice / gcfailureOutputPerUnit;
                labelRecommendation.Text = "You should now buy a GC Failure for optimal BPS increase.";
            }
            if (currentLowest > memoryleakCurrentRealPrice / memoryleakOutputPerUnit) 
                {
                    currentLowest = memoryleakCurrentRealPrice / memoryleakOutputPerUnit;
                labelRecommendation.Text = "You should now buy a Memory Leak for optimal BPS increase.";
            }
            if (currentLowest > messagequeueCurrentRealPrice / messagequeueOutputPerUnit) 
                {
                    currentLowest = messagequeueCurrentRealPrice / messagequeueOutputPerUnit;
                labelRecommendation.Text = "You should now buy a Message Queue for optimal BPS increase.";
            }
            if (currentLowest > databaseCurrentRealPrice / databaseOutputPerUnit) 
                {
                    currentLowest = databaseCurrentRealPrice / databaseOutputPerUnit;
                labelRecommendation.Text = "You should now buy a Database for optimal BPS increase.";
            }
            if (currentLowest > cacheCurrentRealPrice / cacheOutputPerUnit) 
                {
                    currentLowest = cacheCurrentRealPrice / cacheOutputPerUnit;
                labelRecommendation.Text = "You should now buy a Cache for optimal BPS increase.";
            }
            if (currentLowest > cpuCurrentRealPrice / cpuOutputPerUnit) 
                {
                    currentLowest = cpuCurrentRealPrice / cpuOutputPerUnit;
                labelRecommendation.Text = "You should now buy a CPU for optimal BPS increase.";
            }
            if (currentLowest > gpuCurrentRealPrice / gpuOutputPerUnit) 
                {
                    currentLowest = gpuCurrentRealPrice / gpuOutputPerUnit;
                labelRecommendation.Text = "You should now buy a GPU for optimal BPS increase.";
            }
            if (currentLowest > clusterCurrentRealPrice / clusterOutputPerUnit)
            {
                currentLowest = clusterCurrentRealPrice / clusterOutputPerUnit;
                labelRecommendation.Text = "You should now buy a Cluster for optimal BPS increase.";
            }
        }

        private void UpdateTotalBPS()
        {
            decimal totalPower = 0.0m;
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

            labelBPSFromClicks.Text = Function.BeautifyBPS(0.15m * totalPower * ((decimal)Math.Pow(1.1, (double)cursorPowerUpCount))) + Function.AppendCorrectAbbreviationBPS(0.15m * totalPower * ((decimal)Math.Pow(1.1, (double)cursorPowerUpCount)));

            totalPower += (0.15m * totalPower * ((decimal)Math.Pow(1.1, (double)cursorPowerUpCount))) * noClicksPerSecond;

            labelTotalBPS.Text = Function.BeautifyBPS(totalPower) + Function.AppendCorrectAbbreviationBPS(totalPower);
        }

        #endregion

        #region Events

        public DripStatCalculator()
        {
            InitializeComponent();
        }

        private void DripStatCalculator_Load(object sender, EventArgs e)
        {
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

            UpdateAll();
        }

        private void buttonBuyUnit_Click(object sender, EventArgs e)
        {
            if (sender.Equals(buttonCursorBuyUnit))
            {
                cursorUnitCount++;
                cursorCurrentRealPrice *= Function.Multiplier;
                cursorCurrentRealPrice = Function.BeautifyButKeepLength(cursorCurrentRealPrice);
                cursorCurrentPrettyPrice = Function.Beautify(cursorCurrentRealPrice) + Function.AppendCorrectAbbreviation(cursorCurrentRealPrice);
            }
            else if (sender.Equals(buttonBrogrammerBuyUnit))
            {
                brogrammerUnitCount++;
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
                gcfailureCurrentRealPrice *= Function.Multiplier;
                gcfailureCurrentRealPrice = Function.BeautifyButKeepLength(gcfailureCurrentRealPrice);
                gcfailureCurrentPrettyPrice = Function.Beautify(gcfailureCurrentRealPrice) + Function.AppendCorrectAbbreviation(gcfailureCurrentRealPrice);
            }
            else if (sender.Equals(buttonMemoryLeakBuyUnit))
            {
                memoryleakUnitCount++;
                memoryleakCurrentRealPrice *= Function.Multiplier;
                memoryleakCurrentRealPrice = Function.BeautifyButKeepLength(memoryleakCurrentRealPrice);
                memoryleakCurrentPrettyPrice = Function.Beautify(memoryleakCurrentRealPrice) + Function.AppendCorrectAbbreviation(memoryleakCurrentRealPrice);
            }
            else if (sender.Equals(buttonMessageQueueBuyUnit))
            {
                messagequeueUnitCount++;
                messagequeueCurrentRealPrice *= Function.Multiplier;
                messagequeueCurrentRealPrice = Function.BeautifyButKeepLength(messagequeueCurrentRealPrice);
                messagequeueCurrentPrettyPrice = Function.Beautify(messagequeueCurrentRealPrice) + Function.AppendCorrectAbbreviation(messagequeueCurrentRealPrice);
            }
            else if (sender.Equals(buttonDatabaseBuyUnit))
            {
                databaseUnitCount++;
                databaseCurrentRealPrice *= Function.Multiplier;
                databaseCurrentRealPrice = Function.BeautifyButKeepLength(databaseCurrentRealPrice);
                databaseCurrentPrettyPrice = Function.Beautify(databaseCurrentRealPrice) + Function.AppendCorrectAbbreviation(databaseCurrentRealPrice);
            }
            else if (sender.Equals(buttonCacheBuyUnit))
            {
                cacheUnitCount++;
                cacheCurrentRealPrice *= Function.Multiplier;
                cacheCurrentRealPrice = Function.BeautifyButKeepLength(cacheCurrentRealPrice);
                cacheCurrentPrettyPrice = Function.Beautify(cacheCurrentRealPrice) + Function.AppendCorrectAbbreviation(cacheCurrentRealPrice);
            }
            else if (sender.Equals(buttonCPUBuyUnit))
            {
                cpuUnitCount++;
                cpuCurrentRealPrice *= Function.Multiplier;
                cpuCurrentRealPrice = Function.BeautifyButKeepLength(cpuCurrentRealPrice);
                cpuCurrentPrettyPrice = Function.Beautify(cpuCurrentRealPrice) + Function.AppendCorrectAbbreviation(cpuCurrentRealPrice);
            }
            else if (sender.Equals(buttonGPUBuyUnit))
            {
                gpuUnitCount++;
                gpuCurrentRealPrice *= Function.Multiplier;
                gpuCurrentRealPrice = Function.BeautifyButKeepLength(gpuCurrentRealPrice);
                gpuCurrentPrettyPrice = Function.Beautify(gpuCurrentRealPrice) + Function.AppendCorrectAbbreviation(gpuCurrentRealPrice);
            }
            else if (sender.Equals(buttonClusterBuyUnit))
            {
                clusterUnitCount++;
                clusterCurrentRealPrice *= Function.Multiplier;
                clusterCurrentRealPrice = Function.BeautifyButKeepLength(clusterCurrentRealPrice);
                clusterCurrentPrettyPrice = Function.Beautify(clusterCurrentRealPrice) + Function.AppendCorrectAbbreviation(clusterCurrentRealPrice);
            }

            UpdateAll();
        }

        private void buttonBuyPowerUp_Click(object sender, EventArgs e)
        {
            if (sender.Equals(buttonCursorBuyPowerUp))
            {
                cursorPowerUpCount++;
                cursorOutputPerUnit *= Function.Multiplier;
            }
            else if (sender.Equals(buttonBrogrammerBuyPowerUp))
            {
                brogrammerPowerUpCount++;
                brogrammerOutputPerUnit *= Function.Multiplier;
            }
            else if (sender.Equals(buttonGCFailureBuyPowerUp))
            {
                gcfailurePowerUpCount++;
                gcfailureOutputPerUnit *= Function.Multiplier;
            }
            else if (sender.Equals(buttonMemoryLeakBuyPowerUp))
            {
                memoryleakPowerUpCount++;
                memoryleakOutputPerUnit *= Function.Multiplier;
            }
            else if (sender.Equals(buttonMessageQueueBuyPowerUp))
            {
                messagequeuePowerUpCount++;
                messagequeueOutputPerUnit *= Function.Multiplier;
            }
            else if (sender.Equals(buttonDatabaseBuyPowerUp))
            {
                databasePowerUpCount++;
                databaseOutputPerUnit *= Function.Multiplier;
            }
            else if (sender.Equals(buttonCacheBuyPowerUp))
            {
                cachePowerUpCount++;
                cacheOutputPerUnit *= Function.Multiplier;
            }
            else if (sender.Equals(buttonCPUBuyPowerUp))
            {
                cpuPowerUpCount++;
                cpuOutputPerUnit *= Function.Multiplier;
            }
            else if (sender.Equals(buttonGPUBuyPowerUp))
            {
                gpuPowerUpCount++;
                gpuOutputPerUnit *= Function.Multiplier;
            }
            else if (sender.Equals(buttonClusterBuyPowerUp))
            {
                clusterPowerUpCount++;
                clusterOutputPerUnit *= Function.Multiplier;
            }

            UpdateAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                noClicksPerSecond = int.Parse(textBoxClicksPerSecond.Text);
            }
            catch (Exception)
            {
                noClicksPerSecond = 0;
                System.Windows.Forms.MessageBox.Show("You entered an invalid value for clicks per second.");
            }
            UpdateAll();
        }

        #endregion

        #region Decimal Math

        #endregion



    }
}
