using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NI_Data_Collector
{

    class NodeData
    {
        //Infomation of Node
        public string Name { get; set; }
        public int NumOfChannel { get; set; }
        public int NumOfSensor { get; set; }
        public int SamplingFrequency { get; set; }
        public int SendingPeriod { get; set; }
        public int DeletingPeriod { get; set; }
        public string IPAddress { get; set; }
        public string State { get; set; }
        public bool IsActive { get; set; }
        public string Time { get; set; }
        public string Temp { get; set; }

        //Information of Channel
        public string ID { get; set; }
        public string Type { get; set; }
        public string CalibFactor { get; set; }
        public string TerminalMode { get; set; }

        public List<NodeData> lstChannel { get; set; }
        public NodeData ParrentNode { get; set; }

        //Constructor for Parrent Node
        public NodeData(string name, int numOfChannel, int numOfSensor, int samplingFreq, int sendPer, int delPer, string IP)
        {
            this.Name = name;
            this.Type = "Root Node";
            this.State = "Unconnected";
            this.Time = "--:--:--";
            this.Temp = "--";
            this.IsActive = false;
            this.NumOfChannel = numOfChannel;
            this.NumOfSensor = numOfSensor;
            this.SamplingFrequency = samplingFreq;
            this.SendingPeriod = sendPer;
            this.DeletingPeriod = delPer;
            this.IPAddress = IP;
            this.lstChannel = new List<NodeData>();
        }

        //Constructor for Child Node
        public NodeData(NodeData parrentNode, string channelName, string channelID, string type, double calibFactor, string terminalMode)
        {
            this.Name = channelName;
            this.ID = channelID;
            this.Type = type;
            this.CalibFactor = calibFactor.ToString();
            this.TerminalMode = terminalMode;
            this.lstChannel = new List<NodeData>();
            this.ParrentNode = parrentNode;
        }

        //Init List of Channel
        public void initChannel()
        {            
            for (int i = 0; i < NumOfChannel; i++)
            {
                lstChannel.Add(new NodeData(this, "Channel " + (i + 1).ToString(), this.Name + "-" + "CHAN" + "-" +
                                            (i + 1).ToString(), "Not Set", 0.0, "DIFFERENTIAL"));
            }                
        }
    }
}
