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

        #endregion

        #region GUI Functions

        public void UpdateUnitCount()
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

        public void UpdatePowerUpCount()
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

        public void UpdateUnitPrice()
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
            
            UpdateUnitCount();
            UpdatePowerUpCount();
            UpdateUnitPrice();
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

            UpdateUnitCount();
            UpdateUnitPrice();
        }

        private void buttonBuyPowerUp_Click(object sender, EventArgs e)
        {
            if (sender.Equals(buttonCursorBuyPowerUp))
                cursorPowerUpCount++;
            else if (sender.Equals(buttonBrogrammerBuyPowerUp))
                brogrammerPowerUpCount++;
            else if (sender.Equals(buttonGCFailureBuyPowerUp))
                gcfailurePowerUpCount++;
            else if (sender.Equals(buttonMemoryLeakBuyPowerUp))
                memoryleakPowerUpCount++;
            else if (sender.Equals(buttonMessageQueueBuyPowerUp))
                messagequeuePowerUpCount++;
            else if (sender.Equals(buttonDatabaseBuyPowerUp))
                databasePowerUpCount++;
            else if (sender.Equals(buttonCacheBuyPowerUp))
                cachePowerUpCount++;
            else if (sender.Equals(buttonCPUBuyPowerUp))
                cpuPowerUpCount++;
            else if (sender.Equals(buttonGPUBuyPowerUp))
                gpuPowerUpCount++;
            else if (sender.Equals(buttonClusterBuyPowerUp))
                clusterPowerUpCount++;

            UpdatePowerUpCount();
        }

        #endregion

    }
}
