using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NI_Data_Collector
{
    public partial class Form2 : Form
    {
        private string nodeID = string.Empty;
        private string ipAddress = string.Empty;
        private string samplingFrequency = string.Empty;
        private string sendingPeriod = string.Empty;
        private string deletingPeriod = string.Empty;
        private string numberOfChannels = string.Empty;

        public string NodeID
        {
            get
            {
                return nodeID;
            }

            set
            {
                nodeID = value;
            }
        }

        public string IpAddress
        {
            get
            {
                return ipAddress;
            }

            set
            {
                ipAddress = value;
            }
        }

        public string SamplingFrequency
        {
            get
            {
                return samplingFrequency;
            }

            set
            {
                samplingFrequency = value;
            }
        }

        public string DeletingPeriod
        {
            get
            {
                return deletingPeriod;
            }

            set
            {
                deletingPeriod = value;
            }
        }

        public string SendingPeriod
        {
            get
            {
                return sendingPeriod;
            }

            set
            {
                sendingPeriod = value;
            }
        }

        public string NumberOfChannels
        {
            get
            {
                return numberOfChannels;
            }

            set
            {
                numberOfChannels = value;
            }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            NodeID = tbNodeID.Text;
            numberOfChannels = tbNumofChannels.Text;
            IpAddress = tbIPAddress.Text;
            SamplingFrequency = tbSamplingFrequency.Text;
            SendingPeriod = tbSendingPeriod.Text;
            DeletingPeriod = tbDeletingPeriod.Text;
            this.DialogResult =  DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
