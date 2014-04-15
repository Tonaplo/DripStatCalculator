using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DripStatCalculator
{
    public partial class DripStatCalculator : Form
    {
        #region All the variables
        int cursorUnitCount, brogrammerUnitCount, gcfailureUnitCount, memoryleakUnitCount, messagequeueUnitCount, databaseUnitCount, cacheUnitCount, cpuUnitCount, gpuUnitCount, clusterUnitCount;
        int cursorPowerUpCount, brogrammerPowerUpCount, gcfailurePowerUpCount, memoryleakPowerUpCount, messagequeuePowerUpCount, databasePowerUpCount, cachePowerUpCount, cpuPowerUpCount, gpuPowerUpCount, clusterPowerUpCount;

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
        #endregion


        #region Events

        public DripStatCalculator()
        {
            InitializeComponent();
        }

        private void DripStatCalculator_Load(object sender, EventArgs e)
        {

        }

        private void buttonBuyUnit_Click(object sender, EventArgs e)
        {
            if (sender.Equals(buttonCursorBuyUnit))
                cursorUnitCount++;
            else if (sender.Equals(buttonBrogrammerBuyUnit))
                brogrammerUnitCount++;
            else if (sender.Equals(buttonGCFailureBuyUnit))
                gcfailureUnitCount++;
            else if (sender.Equals(buttonMemoryLeakBuyUnit))
                memoryleakUnitCount++;
            else if (sender.Equals(buttonMessageQueueBuyUnit))
                messagequeueUnitCount++;
            else if (sender.Equals(buttonDatabaseBuyUnit))
                databaseUnitCount++;
            else if (sender.Equals(buttonCacheBuyUnit))
                cacheUnitCount++;
            else if (sender.Equals(buttonCPUBuyUnit))
                cpuUnitCount++;
            else if (sender.Equals(buttonGPUBuyUnit))
                gpuUnitCount++;
            else if (sender.Equals(buttonClusterBuyUnit))
                clusterUnitCount++;

            UpdateUnitCount();
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
