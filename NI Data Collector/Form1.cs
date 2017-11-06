using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NI_Data_Collector
{
    public partial class Form1 : Form
    {
        private List<NI_Data_Collector.NodeData> lstNode;
        private BrightIdeasSoftware.TreeListView treeListView;

        private const int PORT_CTRL = 7777;
        private string DATA_FILE = Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\SensorInfo.txt";
        private string AUTH_FILE = Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\HashData.txt";
        private const string APPNAME = "SensorDataCollector";
        private string outputDirectoy;
        private int timeout = 0;
        private int numOfNode = 0;
        private int numOfSensor = 0;
        private int portListener = 7778;

        private List<int> lstPortFile;
        private List<int> lstPortStatus;

        private List<Thread> lstCtrlThread;
        private List<Thread> lstRecvFileThread;
        private List<Thread> lstRecvStatusThread;

        private List<TcpListener> lstFileListener;
        private List<TcpListener> lstStatusListener;

        private List<TcpClient> lstCtrlClient;
        private List<TcpClient> lstFileClient;
        private List<TcpClient> lstStatusClient;

        private List<NetworkStream> lstCtrlStream;
        private List<NetworkStream> lstFileStream;
        private List<NetworkStream> lstStatusStream;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1(string user)
        {
            // Log info
            log.Info("START PROGRAM");

            InitializeComponent();
            lbUser.Text = user;
            initTable();
            initTableProperties();
            lstNode = new List<NI_Data_Collector.NodeData>();

            lstPortFile = new List<int>();
            lstPortStatus = new List<int>();
            lstCtrlThread = new List<Thread>();
            lstRecvFileThread = new List<Thread>();
            lstRecvStatusThread = new List<Thread>();
            lstFileListener = new List<TcpListener>();
            lstStatusListener = new List<TcpListener>();

            lstCtrlClient = new List<TcpClient>();
            lstFileClient = new List<TcpClient>();
            lstStatusClient = new List<TcpClient>();

            lstCtrlStream = new List<NetworkStream>();
            lstFileStream = new List<NetworkStream>();
            lstStatusStream = new List<NetworkStream>();

            System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();            

            loadData();
            getStartupStatus();
            detectStartupArg();
            btStartStop_Click(this, new EventArgs());
        }

        void detectStartupArg()
        {
            string[] arg = Environment.GetCommandLineArgs();
            
            if (arg.Length < 2)
            {
                this.Visible = true;
                return;
            }

            if (arg[1].Equals("-runminimized"))
            {
                this.Visible = false;
            }
            else
            {
                this.Visible = true;
            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        delegate void SetButtonCallback(string btText);

        private void setButtonText(string btText)
        {
            if (this.btStartStop.InvokeRequired)
            {
                SetButtonCallback d = new SetButtonCallback(setButtonText);
                this.Invoke(d, new object[] { btText});
            }
            else
            {
                btStartStop.Text = btText;                
            }
        }

        private void initTableProperties()
        {
            this.treeListView.SelectionChanged += new System.EventHandler(this.treeListView_SelectionChanged);
        }

        private void initTable()
        {
            treeListView = new BrightIdeasSoftware.TreeListView();
            treeListView.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(treeListView);

            // set the delegate that the tree uses to know if a node is expandable
            this.treeListView.CanExpandGetter = x => (x as NodeData).lstChannel.Count > 0;
            // set the delegate that the tree uses to know the children of a node
            this.treeListView.ChildrenGetter = x => (x as NodeData).lstChannel;

            // create the tree columns and set the delegates to print the desired object proerty
            var nameCol = new BrightIdeasSoftware.OLVColumn("Node", "Name");
            nameCol.AspectGetter = x => (x as NodeData).Name;

            var col1 = new BrightIdeasSoftware.OLVColumn("Sensor", "Column1");
            col1.AspectGetter = x => (x as NodeData).ID;

            var col2 = new BrightIdeasSoftware.OLVColumn("Type", "Column2");
            col2.AspectGetter = x => (x as NodeData).Type;

            var col3 = new BrightIdeasSoftware.OLVColumn("Calib. factor", "Column5");
            col3.AspectGetter = x => (x as NodeData).CalibFactor;

            var col4 = new BrightIdeasSoftware.OLVColumn("Status", "Column3");
            col4.AspectGetter = x => (x as NodeData).State;

            var col5 = new BrightIdeasSoftware.OLVColumn("Time", "Column4");
            col5.AspectGetter = x => (x as NodeData).Time;

            var col6 = new BrightIdeasSoftware.OLVColumn("Temp", "Column5");
            col6.AspectGetter = x => (x as NodeData).Temp;

            

            // add the columns to the tree
            
            this.treeListView.Columns.Add(nameCol);
            this.treeListView.Columns.Add(col1);
            this.treeListView.Columns.Add(col2);
            this.treeListView.Columns.Add(col3);
            this.treeListView.Columns.Add(col4);
            this.treeListView.Columns.Add(col5);
            this.treeListView.Columns.Add(col6);

            this.treeListView.Columns[0].Width = 100;
            this.treeListView.Columns[1].Width = 140;
            this.treeListView.Columns[2].Width = 100;
            this.treeListView.Columns[3].Width = 80;
            this.treeListView.Columns[4].Width = 100;
            this.treeListView.Columns[5].Width = 90;
            this.treeListView.Columns[6].Width = 50;
        }

        private void addNode(string nodeID, int numberOfChannel, int numberOfSensor, int samplingFrequency, int sendingPeriod, int deletingPeriod, string ipAddress)
        {
            lstNode.Add(new NodeData(nodeID, numberOfChannel, numberOfSensor, samplingFrequency, sendingPeriod, deletingPeriod, ipAddress));
            lstNode[lstNode.Count - 1].initChannel();
            this.treeListView.Roots = lstNode;

            lstPortFile.Add(portListener++);
            lstPortStatus.Add(portListener++);
            lstCtrlThread.Add(null);            

            lstCtrlClient.Add(null);
            lstCtrlStream.Add(null);
            lstRecvFileThread.Add(null);
            lstRecvStatusThread.Add(null);

            lstFileListener.Add(null);
            lstFileClient.Add(null);
            lstFileStream.Add(null);

            lstStatusListener.Add(null);
            lstStatusClient.Add(null);
            lstStatusStream.Add(null);

            numOfNode++;
            numOfSensor += numberOfSensor;
            lbNumOfNode.Text = "Node: " + numOfNode.ToString();
            lbNumOfSensor.Text = "Sensor: " + numOfSensor.ToString();
        }

        private void removeNode(NodeData node)
        {
            int index = lstNode.IndexOf(node);
            numOfNode--;
            numOfSensor -= node.NumOfSensor;

            lstNode.RemoveAt(index);
            this.treeListView.Roots = lstNode;

            lstPortFile.RemoveAt(index);
            lstPortStatus.RemoveAt(index);
            lstCtrlThread.RemoveAt(index);

            lstCtrlClient.RemoveAt(index);
            lstCtrlStream.RemoveAt(index);
            lstRecvFileThread.RemoveAt(index);
            lstRecvStatusThread.RemoveAt(index);

            lstFileListener.RemoveAt(index);
            lstFileClient.RemoveAt(index);
            lstFileStream.RemoveAt(index);

            lstStatusListener.RemoveAt(index);
            lstStatusClient.RemoveAt(index);
            lstStatusStream.RemoveAt(index);
            
            lbNumOfNode.Text = "Node: " + numOfNode.ToString();
            lbNumOfSensor.Text = "Sensor: " + numOfSensor.ToString();
        }

        private void treeListView_SelectionChanged (object sender, EventArgs e)
        {
            NodeData selectedObject = (NodeData)treeListView.SelectedObject;

            if (selectedObject == null)
            {
                btRemove.Enabled = false;
                panelNode.Enabled = false;
                panelChannel.Enabled = false;
                btApply.Enabled = false;

                tbNodeID.Text = string.Empty;
                tbIPAddr.Text = string.Empty;
                tbSamplingFreq.Text = string.Empty;
                tbSendingPer.Text = string.Empty;
                tbDeletingPer.Text = string.Empty;

                tbSensorID.Text = string.Empty;
                tbChannelID.Text = string.Empty;
                tbType.Text = string.Empty;
                tbCalibFactor.Text = string.Empty;
                tbTerMode.Text = string.Empty;

                return;
            }
            if (selectedObject.Type == "Root Node")
            {
                btRemove.Enabled = true;
                if (btStartStop.Text.Equals("STOP"))
                {
                    panelNode.Enabled = false;
                    panelChannel.Enabled = false;
                    btApply.Enabled = false;
                }
                else
                {
                    panelNode.Enabled = true;
                    panelChannel.Enabled = false;
                    btApply.Enabled = true;
                }

                tbNodeID.Text = selectedObject.Name;
                tbIPAddr.Text = selectedObject.IPAddress;
                tbSamplingFreq.Text = selectedObject.SamplingFrequency.ToString();
                tbSendingPer.Text = selectedObject.SendingPeriod.ToString();
                tbDeletingPer.Text = selectedObject.DeletingPeriod.ToString();

                tbSensorID.Text = string.Empty;
                tbChannelID.Text = string.Empty;
                tbType.Text = string.Empty;
                tbCalibFactor.Text = string.Empty;
                tbTerMode.Text = string.Empty;
            }
            else
            {
                btRemove.Enabled = false;
                if (btStartStop.Text.Equals("STOP"))
                {
                    panelNode.Enabled = false;
                    panelChannel.Enabled = false;
                    btApply.Enabled = false;
                }
                else
                {
                    panelNode.Enabled = false;
                    panelChannel.Enabled = true;
                    btApply.Enabled = true;
                }                

                tbNodeID.Text = selectedObject.ParrentNode.Name;
                tbIPAddr.Text = selectedObject.ParrentNode.IPAddress;
                tbSamplingFreq.Text = selectedObject.ParrentNode.SamplingFrequency.ToString();
                tbSendingPer.Text = selectedObject.ParrentNode.SendingPeriod.ToString();
                tbDeletingPer.Text = selectedObject.ParrentNode.DeletingPeriod.ToString();

                tbSensorID.Text = selectedObject.ID;
                tbChannelID.Text = selectedObject.Name;
                tbType.Text = selectedObject.Type;
                tbCalibFactor.Text = selectedObject.CalibFactor;
                tbTerMode.Text = selectedObject.TerminalMode;
            }
        }

        private string getLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void sendMessage(string message, NetworkStream netStream)
        {
            int intValue = message.Length;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(intBytes);
            }

            byte[] result = intBytes;

            byte[] sendBytes = Encoding.UTF8.GetBytes(message);
            netStream.Write(result, 0, 4);
            netStream.Write(sendBytes, 0, sendBytes.Length);
        }

        private void connectToDevice(int nodeID)
        {
            // Log info
            log.Info("Connecting to " + lstNode[nodeID].Name + "...");

            string message;

            try
            {                
                lstCtrlClient[nodeID] = new TcpClient();
                lstCtrlClient[nodeID].Connect(lstNode[nodeID].IPAddress, PORT_CTRL);
                lstCtrlStream[nodeID] = lstCtrlClient[nodeID].GetStream();

                lstRecvFileThread[nodeID] = new Thread(() => openConnectToReceiveFile(nodeID));
                lstRecvFileThread[nodeID].IsBackground = true;
                lstRecvFileThread[nodeID].Start();

                lstRecvStatusThread[nodeID] = new Thread(() => openConnectToReceiveStatus(nodeID));
                lstRecvStatusThread[nodeID].IsBackground = true;
                lstRecvStatusThread[nodeID].Start();

                message = "START";
                sendMessage(message, lstCtrlStream[nodeID]);

                message = lstNode[nodeID].SamplingFrequency.ToString() + "," +
                          lstNode[nodeID].SendingPeriod.ToString() + "," +
                          lstNode[nodeID].DeletingPeriod.ToString() + "," +
                          getLocalIPAddress() + "," +
                          lstPortFile[nodeID].ToString() + "," +
                          lstNode[nodeID].NumOfChannel;

                for (int i = 0; i < lstNode[nodeID].lstChannel.Count; i++)
                {                    
                    if (lstNode[nodeID].lstChannel[i].Type.Equals("Not Set"))
                    {
                        message += ",";
                        message += lstNode[nodeID].lstChannel[i].Type;
                    }
                    else
                    {
                        message += ",";
                        message += lstNode[nodeID].lstChannel[i].ID;
                    }                    
                    message += ",";
                    message += lstNode[nodeID].lstChannel[i].CalibFactor;
                }
                sendMessage(message, lstCtrlStream[nodeID]);                

                lstNode[nodeID].State = "Connected";
                lstNode[nodeID].IsActive = true;
                btStartStop.Image = global::NI_Data_Collector.Properties.Resources.Stop_icon;
                setButtonText("STOP");                

                if (lstCtrlStream[nodeID] != null)
                {
                    lstCtrlStream[nodeID].Flush();
                    lstCtrlStream[nodeID].Close();
                    lstCtrlStream[nodeID] = null;
                }

                if (lstCtrlClient[nodeID] != null)
                {
                    lstCtrlClient[nodeID].Close();
                    lstCtrlClient[nodeID] = null;
                }

                // Log info
                log.Info("Connected successfully to " + lstNode[nodeID].Name + ".");
            }
            catch
            {
                // Log error
                log.Error("Failed to connect to node " + lstNode[nodeID].Name + ".");

                MessageBox.Show("Cannot connect to node " + lstNode[nodeID].Name, "Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void disconnectToDevice(int nodeID)
        {
            // Log info
            log.Info("Disconnecting from " + lstNode[nodeID].Name + "...");

            if (lstNode[nodeID].State.Equals("Connected"))
            {
                try
                {
                    lstCtrlClient[nodeID] = new TcpClient();
                    lstCtrlClient[nodeID].Connect(lstNode[nodeID].IPAddress, PORT_CTRL);
                    lstCtrlStream[nodeID] = lstCtrlClient[nodeID].GetStream();

                    String message = "STOP";

                    sendMessage(message, lstCtrlStream[nodeID]);

                    // Log info
                    log.Info("Disconnected successfully from " + lstNode[nodeID].Name + ".");
                }
                catch
                {
                    // Log error
                    log.Error("Failed to disconnect from node " + lstNode[nodeID].Name + ".");

                    MessageBox.Show("Cannot connect to node " + lstNode[nodeID].Name, "Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (lstFileListener[nodeID] != null)
            {
                lstFileListener[nodeID].Stop();
                lstFileListener[nodeID] = null;
            }

            if (lstStatusListener[nodeID] != null)
            {
                lstStatusListener[nodeID].Stop();
                lstStatusListener[nodeID] = null;
            }

            if (lstCtrlStream[nodeID] != null)
            {
                lstCtrlStream[nodeID].Flush();
                lstCtrlStream[nodeID].Close();
                lstCtrlStream[nodeID] = null;
            }

            if (lstFileStream[nodeID] != null)
            {
                lstFileStream[nodeID].Flush();
                lstFileStream[nodeID].Close();
                lstFileStream[nodeID] = null;
            }

            if (lstStatusStream[nodeID] != null)
            {
                lstStatusStream[nodeID].Flush();
                lstStatusStream[nodeID].Close();
                lstStatusStream[nodeID] = null;
            }

            if (lstCtrlClient[nodeID] != null)
            {
                lstCtrlClient[nodeID].Close();
                lstCtrlClient[nodeID] = null;
            }

            if (lstFileClient[nodeID] != null)
            {
                lstFileClient[nodeID].Close();
                lstFileClient[nodeID] = null;
            }

            if (lstStatusClient[nodeID] != null)
            {
                lstStatusClient[nodeID].Close();
                lstStatusClient[nodeID] = null;
            }

            lstNode[nodeID].State = "Unconnected";
            lstNode[nodeID].Time = "--:--:--";
            lstNode[nodeID].Temp = "--";
            lstNode[nodeID].IsActive = false;
            this.treeListView.UpdateObject(lstNode[nodeID]);
            if (lstNode.All(node => !node.IsActive))
            {
                setButtonText("START");
                btStartStop.Image = global::NI_Data_Collector.Properties.Resources.Start_icon;             
            }                
        }

        private int convertBytesArrayToInt(byte[] arrayByte)
        {
            int result = 0;
            int multiplier = 1;
            for (int i = arrayByte.Length - 1; i >= 0; i--)
            {
                result += arrayByte[i] * multiplier;
                multiplier *= 256;
            }
            return result;
        }

        private void openConnectToReceiveFile(int nodeID)
        {
            try
            {
                timeout = lstNode[nodeID].SendingPeriod * 2 * 1000; 
                Stopwatch timer = new Stopwatch();
                lstFileListener[nodeID] = new TcpListener(IPAddress.Any, lstPortFile[nodeID]);
                lstFileListener[nodeID].Start();
                timer.Start();

                while (true)
                {
                    if (timer.ElapsedMilliseconds > timeout)
                    {
                        timer.Restart();
                        if (lstNode[nodeID].State == "Connected")
                        {
                            // Log warning
                            log.Warn("Node " + lstNode[nodeID].Name + " is disconnected.");
                        }
                        lstNode[nodeID].State = "Disconnected";
                        this.treeListView.UpdateObject(lstNode[nodeID]);
                    }
                    if (lstFileListener[nodeID].Pending())
                    {
                        timer.Restart();
                        if (lstNode[nodeID].State == "Disconnected")
                        {
                            // Log info
                            log.Info("Node " + lstNode[nodeID].Name + " is reconnected.");
                        }
                        lstNode[nodeID].State = "Connected";
                        this.treeListView.UpdateObject(lstNode[nodeID]);

                        lstFileClient[nodeID] = lstFileListener[nodeID].AcceptTcpClient();
                        lstFileStream[nodeID] = lstFileClient[nodeID].GetStream();

                        startReceiveFile(nodeID);

                        if (lstFileStream[nodeID] != null)
                        {
                            lstFileStream[nodeID].Flush();
                            lstFileStream[nodeID].Close();
                            lstFileStream[nodeID] = null;
                        }

                        if (lstFileClient[nodeID] != null)
                        {
                            lstFileClient[nodeID].Close();
                            lstFileClient[nodeID] = null;
                        }
                    }
                }
            }
            catch
            {
                if (lstFileStream[nodeID] != null)
                {
                    lstFileStream[nodeID].Flush();
                    lstFileStream[nodeID].Close();
                    lstFileStream[nodeID] = null;
                }

                if (lstFileClient[nodeID] != null)
                {
                    lstFileClient[nodeID].Close();
                    lstFileClient[nodeID] = null;
                }

                // Log warning
                log.Warn("Connection to node " + lstNode[nodeID].Name + " is terminated.");

                MessageBox.Show("Connection to node " + lstNode[nodeID].Name + " is terminated", "Disconnected",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void startReceiveFile(int nodeID)
        {
            byte[] receiveData = null;
            int bufferSize = 65536;
            int bytesRead = 0;
            int allBytesRead = 0;
            string filePath = outputDirectoy + "\\";

            try
            {
                receiveData = new byte[4];
                lstFileStream[nodeID].Read(receiveData, 0, 4); // Read name size 
                int fileNameSize = convertBytesArrayToInt(receiveData);

                receiveData = new byte[fileNameSize];
                lstFileStream[nodeID].Read(receiveData, 0, fileNameSize); // Read file name 
                String fileName = Encoding.UTF8.GetString(receiveData);
                filePath += fileName;

                receiveData = new byte[4];
                lstFileStream[nodeID].Read(receiveData, 0, 4); // Read data size 
                int fileSize = convertBytesArrayToInt(receiveData);

                int bytesLeft = fileSize;
                receiveData = new byte[fileSize];

                while (bytesLeft > 0)
                {
                    int nextPacketSize = (bytesLeft > bufferSize) ? bufferSize : bytesLeft;

                    bytesRead = lstFileStream[nodeID].Read(receiveData, allBytesRead, nextPacketSize);
                    allBytesRead += bytesRead;
                    bytesLeft -= bytesRead;
                }
                File.WriteAllBytes(filePath, receiveData);
            }
            catch
            {
                // Log warning
                log.Warn("Connection to node " + lstNode[nodeID].Name + " is terminated.");

                MessageBox.Show("Connection to node " + lstNode[nodeID].Name + " is terminated", "Disconnected",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openConnectToReceiveStatus(int nodeID)
        {
            try
            {
                timeout = lstNode[nodeID].SendingPeriod * 2 * 1000;
                Stopwatch timer = new Stopwatch();
                lstStatusListener[nodeID] = new TcpListener(IPAddress.Any, lstPortStatus[nodeID]);
                lstStatusListener[nodeID].Start();
                timer.Start();

                while (true)
                {
                    if (timer.ElapsedMilliseconds > timeout)
                    {
                        timer.Restart();
                        if (lstNode[nodeID].State == "Connected")
                        {
                            // Log warning
                            log.Warn("Node " + lstNode[nodeID].Name + " is disconnected.");
                        }
                        lstNode[nodeID].State = "Disconnected";                        
                    }
                    if (lstStatusListener[nodeID].Pending())
                    {
                        timer.Restart();
                        if (lstNode[nodeID].State == "Disconnected")
                        {
                            // Log info
                            log.Info("Node " + lstNode[nodeID].Name + " is reconnected.");
                        }
                        lstNode[nodeID].State = "Connected";

                        lstStatusClient[nodeID] = lstStatusListener[nodeID].AcceptTcpClient();
                        lstStatusStream[nodeID] = lstStatusClient[nodeID].GetStream();

                        startReceiveStatus(nodeID);

                        if (lstStatusStream[nodeID] != null)
                        {
                            lstStatusStream[nodeID].Flush();
                            lstStatusStream[nodeID].Close();
                            lstStatusStream[nodeID] = null;
                        }

                        if (lstStatusClient[nodeID] != null)
                        {
                            lstStatusClient[nodeID].Close();
                            lstStatusClient[nodeID] = null;
                        }
                    }
                }
            }
            catch
            {
                if (lstStatusStream[nodeID] != null)
                {
                    lstStatusStream[nodeID].Flush();
                    lstStatusStream[nodeID].Close();
                    lstStatusStream[nodeID] = null;
                }

                if (lstStatusClient[nodeID] != null)
                {
                    lstStatusClient[nodeID].Close();
                    lstStatusClient[nodeID] = null;
                }
            }
        }

        private void startReceiveStatus(int nodeID)
        {
            byte[] receiveData = null;

            try
            {
                receiveData = new byte[4];
                lstStatusStream[nodeID].Read(receiveData, 0, 4); // Read status size 
                int statusSize = convertBytesArrayToInt(receiveData);

                receiveData = new byte[statusSize];
                lstStatusStream[nodeID].Read(receiveData, 0, statusSize); // Read status
                string[] status = Encoding.UTF8.GetString(receiveData).Split(',');

                lstNode[nodeID].Time = status[0];
                lstNode[nodeID].Temp = status[1];

                this.treeListView.UpdateObject(lstNode[nodeID]);
            }
            catch
            {
                // Log warning
                log.Warn("Connection to node " + lstNode[nodeID].Name + " is terminated.");

                MessageBox.Show("Connection to node " + lstNode[nodeID].Name + " is terminated", "Disconnected",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void storeData()
        {
            List<string> lines = new List<string>();

            lines.Add(tbDirectory.Text);
            for (int i = 0; i < lstNode.Count; i++)
            {
                lines.Add(string.Join(",", lstNode[i].Name, lstNode[i].NumOfChannel, lstNode[i].NumOfSensor, lstNode[i].SamplingFrequency,
                                           lstNode[i].SendingPeriod, lstNode[i].DeletingPeriod, lstNode[i].IPAddress));
                for (int j = 0; j < lstNode[i].NumOfChannel; j++)
                    lines.Add(string.Join(",", lstNode[i].lstChannel[j].Name, lstNode[i].lstChannel[j].ID, lstNode[i].lstChannel[j].Type,
                                               lstNode[i].lstChannel[j].CalibFactor, lstNode[i].lstChannel[j].TerminalMode));
            }
            File.WriteAllLines(DATA_FILE, lines);
        }

        private void loadData()
        {
            if (!File.Exists(DATA_FILE))
            {
                // Log error
                log.Error("Failed to load data from file.");

                return;
            }
                
            string[] lines = File.ReadAllLines(DATA_FILE);
            int numOfChannels;
            
            if(lines.Length == 0)
            {
                return;
            }

            tbDirectory.Text = lines[0];
            for (int i = 1; i < lines.Length; i++)
            {
                int j;
                string[] lstParam = lines[i].Split(',');
                numOfChannels = Int32.Parse(lstParam[1]);
                lstNode.Add(new NodeData(lstParam[0], Int32.Parse(lstParam[1]), Int32.Parse(lstParam[2]), Int32.Parse(lstParam[3]),
                                         Int32.Parse(lstParam[4]), Int32.Parse(lstParam[5]), lstParam[6]));                

                lstPortFile.Add(portListener++);
                lstPortStatus.Add(portListener++);
                lstCtrlThread.Add(null);

                lstCtrlClient.Add(null);
                lstCtrlStream.Add(null);
                lstRecvFileThread.Add(null);
                lstRecvStatusThread.Add(null);

                lstFileListener.Add(null);
                lstFileClient.Add(null);
                lstFileStream.Add(null);

                lstStatusListener.Add(null);
                lstStatusClient.Add(null);
                lstStatusStream.Add(null);

                numOfNode++;
                numOfSensor += lstNode[lstNode.Count - 1].NumOfSensor;
                lbNumOfNode.Text = "Node: " + numOfNode.ToString();
                lbNumOfSensor.Text = "Sensor: " + numOfSensor.ToString();

                for (j = 1; j <= numOfChannels; j++)
                {
                    i++;
                    lstParam = lines[i].Split(',');
                    lstNode[lstNode.Count - 1].lstChannel.Add(new NodeData(lstNode[lstNode.Count - 1], lstParam[0],
                                                                           lstParam[1], lstParam[2], Double.Parse(lstParam[3]), lstParam[4]));                
                }                
            }
            this.treeListView.Roots = lstNode;

            // log info
            log.Info("Loaded data successfully from file.");
        }

        string calculateMD5(string input)
        {
            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        int login()
        {
            int i = 0;
            string filePath = AUTH_FILE;
            Form3 form = new Form3();

            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Username or Password is invalid", "Invalid",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                string[] lines = File.ReadAllLines(filePath);

                for (i = 0; i < lines.Length; i += 2)
                {
                    if (calculateMD5(form.Username).Equals(lines[i]) &&
                        calculateMD5(form.Password).Equals(lines[i + 1]))
                        break;
                }
                if (i < lines.Length)
                {
                    return 1;
                }                    

                MessageBox.Show("Username or Password is invalid", "Invalid",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            else
            {
                return 0;
            }
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            if (dialogBrowse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbDirectory.Text = dialogBrowse.SelectedPath;

                // Log info
                log.Info("Changed output directory into \"" + dialogBrowse.SelectedPath + "\".");

                // Store data to file after changing output directory
                storeData();
            }
        }
      
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (btStartStop.Text.Equals("STOP"))
            {
                MessageBox.Show("Please stop the system before adding a node", "Stop First",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form2 form = new Form2();

            while (true)
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        string nodeID = form.NodeID;
                        string ipAddress = form.IpAddress;
                        int numberOfChannels = Int32.Parse(form.NumberOfChannels);
                        int samplingFrequency = Int32.Parse(form.SamplingFrequency);
                        int sendingPeriod = Int32.Parse(form.SendingPeriod);
                        int deletingPeriod = Int32.Parse(form.DeletingPeriod);

                        if (numberOfChannels < 0 || samplingFrequency < 0 ||
                            sendingPeriod < 0 || deletingPeriod < 0)
                        {
                            MessageBox.Show("Invalid values", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        if (samplingFrequency > 50)
                        {
                            MessageBox.Show("Maximum sampling frequency is 50Hz", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }                        
                        addNode(nodeID, numberOfChannels, 0, samplingFrequency, sendingPeriod, deletingPeriod, ipAddress);

                        // Store data to file after adding a node
                        storeData();

                        // Log info
                        log.Info("Added a node: " + nodeID + " (" + ipAddress + " - " + numberOfChannels.ToString() +
                                  " Channels - " + samplingFrequency.ToString() + " Hz - " + sendingPeriod + " - " +
                                  deletingPeriod.ToString() + ").");
                        break;
                    }
                    catch
                    {
                        MessageBox.Show("Invalid values", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }
                else
                    break;
            }                  
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (btStartStop.Text.Equals("STOP"))
            {
                MessageBox.Show("Please stop the system before removing a node", "Stop First",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NodeData selectedObject = (NodeData)treeListView.SelectedObject;
            DialogResult userChoice = MessageBox.Show("Do you want to delete the node " + 
                                                      selectedObject.Name, "Removing?",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (userChoice == DialogResult.Yes)
            {
                string nodeID = selectedObject.Name;
                string ipAddress = selectedObject.IPAddress;
                int numberOfChannels = selectedObject.NumOfChannel;
                int samplingFrequency = selectedObject.SamplingFrequency;
                int sendingPeriod = selectedObject.SendingPeriod;
                int deletingPeriod = selectedObject.DeletingPeriod;

                removeNode(selectedObject);

                btRemove.Enabled = false;
                panelNode.Enabled = false;
                panelChannel.Enabled = false;
                btApply.Enabled = false;

                tbNodeID.Text = string.Empty;
                tbIPAddr.Text = string.Empty;
                tbSamplingFreq.Text = string.Empty;
                tbSendingPer.Text = string.Empty;
                tbDeletingPer.Text = string.Empty;

                // Store data to file after removing a node
                storeData();

                // Log info
                log.Info("Removed a node: " + nodeID + " (" + ipAddress + " - " + numberOfChannels.ToString() +
                          " Channels - " + samplingFrequency.ToString() + " Hz - " + sendingPeriod + " - " +
                          deletingPeriod.ToString() + ").");
            }            
        }

        private void btStartStop_Click(object sender, EventArgs e)
        {
            if (btStartStop.Text.Equals("START"))
            {
                // Log info
                log.Info("Initializing connections...");

                if (tbDirectory.Text.Equals(string.Empty))
                {
                    // Log warning
                    log.Warn("Failed to initialize connections - No output directory.");

                    MessageBox.Show("Please choose folder to store data first", "Browse directory first",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    outputDirectoy = tbDirectory.Text;
                    System.IO.Directory.CreateDirectory(outputDirectoy);
                }
                catch
                {
                    // Log warning
                    log.Warn("Failed to initialize connections - Invalid output directory.");

                    MessageBox.Show("Output directory is not valid", "Invalid", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                if (lstNode == null || lstNode.Count < 1)
                {
                    // Log warning
                    log.Warn("Failed to initialize connections - No node is found.");

                    MessageBox.Show("There is nothing to start. Please add node first", "No node",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                for (int i = 0; i < lstNode.Count; i++)
                {
                    int nodeID = i;
                    lstCtrlThread[i] = new Thread(() => connectToDevice(nodeID));
                    lstCtrlThread[i].IsBackground = true;
                    lstCtrlThread[i].Start();
                }
            }
            else
            {
                // Log info
                log.Info("Closing connections...");
                if (login() == 1)
                {
                    for (int i = 0; i < lstNode.Count; i++)
                    {
                        int nodeID = i;
                        lstCtrlThread[i] = new Thread(() => disconnectToDevice(nodeID));
                        lstCtrlThread[i].IsBackground = true;
                        lstCtrlThread[i].Start();
                    }
                }
                else
                {
                    // Log warning
                    log.Warn("Failed to close connections - Login failed.");
                }
            }
        }

        private void btStartStop_TextChanged(object sender, EventArgs e)
        {
            if (btStartStop.Text.Equals("START"))
            {
                tbDirectory.Enabled = true;
                btBrowse.Enabled = true;
                NodeData selectedObject = (NodeData)treeListView.SelectedObject;

                if (selectedObject == null)
                {
                    panelNode.Enabled = false;
                    panelChannel.Enabled = false;
                    btApply.Enabled = false;
                }
                else if (selectedObject.Type.Equals("Root Node"))
                {
                    panelNode.Enabled = true;
                    panelChannel.Enabled = false;
                    btApply.Enabled = true;
                }
                else
                {
                    panelNode.Enabled = false;
                    panelChannel.Enabled = true;
                    btApply.Enabled = true;
                }
            }
            else
            {
                tbDirectory.Enabled = false;
                btBrowse.Enabled = false;
                panelNode.Enabled = false;
                panelChannel.Enabled = false;
                btApply.Enabled = false;
            }
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            NodeData selectedObject = (NodeData)treeListView.SelectedObject;

            try
            {
                if (selectedObject.Type == "Root Node")
                {
                    if (Int32.Parse(tbSamplingFreq.Text) < 0 || Int32.Parse(tbSendingPer.Text) < 0 ||
                        Int32.Parse(tbDeletingPer.Text) < 0)
                    {
                        MessageBox.Show("Invalid values", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Int32.Parse(tbSamplingFreq.Text) > 50)
                    {
                        MessageBox.Show("Maximum sampling frequency is 50Hz", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }     
                    for (int i = 0; i < selectedObject.NumOfChannel; i++)
                    {
                        if (selectedObject.lstChannel[i].ID.Equals(selectedObject.Name + "-" + "CHAN" + "-" +
                                                                   (i + 1).ToString()))
                            selectedObject.lstChannel[i].ID = tbNodeID.Text + "-" + "CHAN" + "-" +
                                                              (i + 1).ToString();
                    }
                    selectedObject.Name = tbNodeID.Text;
                    selectedObject.IPAddress = tbIPAddr.Text;
                    selectedObject.SamplingFrequency = Int32.Parse(tbSamplingFreq.Text);
                    selectedObject.SendingPeriod = Int32.Parse(tbSendingPer.Text);
                    selectedObject.DeletingPeriod = Int32.Parse(tbDeletingPer.Text);

                    for (int i = 0; i < lstNode.Count; i++)
                    {
                        lstNode[i].SamplingFrequency = selectedObject.SamplingFrequency;
                        lstNode[i].SendingPeriod = selectedObject.SendingPeriod;
                        lstNode[i].DeletingPeriod = selectedObject.DeletingPeriod;
                        this.treeListView.UpdateObject(lstNode[i]);
                    }

                    // Log info
                    log.Info("Updated infomation for node " + selectedObject.Name + ".");

                    MessageBox.Show("Updated infomation successfully for node " + selectedObject.Name,
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    selectedObject.ID = tbSensorID.Text;
                    selectedObject.Name = tbChannelID.Text;
                    if (selectedObject.Type.Equals("Not Set") && !tbType.Text.Equals("Not Set"))
                    {
                        selectedObject.ParrentNode.NumOfSensor++;
                        numOfSensor++;
                    }                        
                    else if (!selectedObject.Type.Equals("Not Set") && tbType.Text.Equals("Not Set"))
                    {
                        selectedObject.ParrentNode.NumOfSensor--;
                        numOfSensor--;
                    }
                        
                    selectedObject.Type = tbType.Text;
                    selectedObject.CalibFactor = Double.Parse(tbCalibFactor.Text).ToString();
                    selectedObject.TerminalMode = tbTerMode.Text;
                    this.treeListView.UpdateObject(selectedObject.ParrentNode);
                    lbNumOfSensor.Text = "Sensor: " + numOfSensor.ToString();

                    // Log info
                    log.Info("Updated infomation for " + selectedObject.Name + " of node " + selectedObject.ParrentNode.Name + ".");

                    MessageBox.Show("Updated infomation successfully for " + selectedObject.Name +
                                    " of node " + selectedObject.ParrentNode.Name, "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Store data to file after applying changes
                storeData();
            }
            catch
            {
                MessageBox.Show("Invalid values", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                 
        }

        private void getStartupStatus()
        {
            /***************************************************************
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (rk.GetValue(APPNAME) != null)
                tbStartWithWin.Checked = true;
            else
                tbStartWithWin.Checked = false;
            ***************************************************************/
            string userName = Environment.UserName;
            string startupConfigFile = "C:\\Users\\" + userName + "" +
                                       "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\SensorDataCollector.vbs";

            if (File.Exists(startupConfigFile))
            {
                tbStartWithWin.Checked = true;
            }
            else
            {
                tbStartWithWin.Checked = false;
            }
        }

        private void setStartup()
        {
            /**********************************************************************************
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (tbStartWithWin.Checked)
                rk.SetValue(APPNAME, Path.GetDirectoryName(Application.ExecutablePath) + "\\" 
                            + Path.GetFileName(Application.ExecutablePath) + " -runminimized");
            else
                rk.DeleteValue(APPNAME, false);
            **********************************************************************************/
            string userName = Environment.UserName;
            string startupConfigFile = "C:\\Users\\" + userName + "" +
                                       "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\SensorDataCollector.vbs";

            if (File.Exists(startupConfigFile))
            {
                File.Delete(startupConfigFile);
            }

            // Run as startup
            if (tbStartWithWin.Checked)
            {
                using (StreamWriter sw = File.CreateText(startupConfigFile))
                {
                    sw.WriteLine("Set WshShell = CreateObject(\"WScript.Shell\")");
                    sw.WriteLine("WshShell.Run \"\"\"" + Path.GetDirectoryName(Application.ExecutablePath) + "\\"
                                + Path.GetFileName(Application.ExecutablePath) + "\"\"\", 0");
                    sw.WriteLine("Set WshShell = Nothing");
                }

                // Log info
                log.Info("Set program to run at startup.");
            }
            else
            {
                // Do nothing

                // Log info
                log.Info("Set program not to run at startup.");
            }
        }

        private void notifyIcon1_Click(object Sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Visible = true;
            }
        }

        private void menuItem1_Click(object Sender, EventArgs e)
        {
            if (btStartStop.Text.Equals("STOP"))
            {
                MessageBox.Show("Please stop the system before closing application", "Stop First",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Visible = true;
                return;
            }

            // Display a MsgBox asking the user for confirming exiting application.
            DialogResult userChoice = MessageBox.Show("Do you want to exit application?", "Exit?",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (userChoice == DialogResult.Yes)
            {
                // Store data to file before exiting
                storeData();

                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void menuItem0_Click(object Sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                // Log info
                log.Info("EXIT PROGRAM");
                return;
            }

            this.Visible = false;
            e.Cancel = true;
        }

        private void tbStartWithWin_CheckedChanged(object sender, EventArgs e)
        {
            setStartup();
        }
    }
}
