using System.Data;
using System;

namespace NI_Data_Collector
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbSensorID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCalibFactor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelChannel = new System.Windows.Forms.Panel();
            this.tbTerMode = new System.Windows.Forms.TextBox();
            this.panelNode = new System.Windows.Forms.Panel();
            this.tbNodeID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbIPAddr = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDeletingPer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSendingPer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSamplingFreq = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btStartStop = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.lbNumOfNode = new System.Windows.Forms.Label();
            this.lbNumOfSensor = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btApply = new System.Windows.Forms.Button();
            this.lbTime = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.dialogBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbUser = new System.Windows.Forms.Label();
            this.tbStartWithWin = new System.Windows.Forms.CheckBox();
            this.panelChannel.SuspendLayout();
            this.panelNode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSensorID
            // 
            this.tbSensorID.Location = new System.Drawing.Point(80, 2);
            this.tbSensorID.Margin = new System.Windows.Forms.Padding(2);
            this.tbSensorID.Name = "tbSensorID";
            this.tbSensorID.Size = new System.Drawing.Size(135, 22);
            this.tbSensorID.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sensor";
            // 
            // tbType
            // 
            this.tbType.Location = new System.Drawing.Point(80, 32);
            this.tbType.Margin = new System.Windows.Forms.Padding(2);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(135, 22);
            this.tbType.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Calibration Factor";
            // 
            // tbCalibFactor
            // 
            this.tbCalibFactor.Location = new System.Drawing.Point(119, 75);
            this.tbCalibFactor.Margin = new System.Windows.Forms.Padding(2);
            this.tbCalibFactor.Name = "tbCalibFactor";
            this.tbCalibFactor.Size = new System.Drawing.Size(96, 22);
            this.tbCalibFactor.TabIndex = 10;
            this.tbCalibFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Terminal Mode";
            // 
            // panelChannel
            // 
            this.panelChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChannel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelChannel.Controls.Add(this.tbTerMode);
            this.panelChannel.Controls.Add(this.label1);
            this.panelChannel.Controls.Add(this.tbSensorID);
            this.panelChannel.Controls.Add(this.label4);
            this.panelChannel.Controls.Add(this.label2);
            this.panelChannel.Controls.Add(this.tbType);
            this.panelChannel.Controls.Add(this.tbCalibFactor);
            this.panelChannel.Controls.Add(this.label3);
            this.panelChannel.Enabled = false;
            this.panelChannel.Location = new System.Drawing.Point(864, 284);
            this.panelChannel.Margin = new System.Windows.Forms.Padding(2);
            this.panelChannel.Name = "panelChannel";
            this.panelChannel.Size = new System.Drawing.Size(223, 139);
            this.panelChannel.TabIndex = 9;
            // 
            // tbTerMode
            // 
            this.tbTerMode.Location = new System.Drawing.Point(119, 106);
            this.tbTerMode.Margin = new System.Windows.Forms.Padding(2);
            this.tbTerMode.Name = "tbTerMode";
            this.tbTerMode.ReadOnly = true;
            this.tbTerMode.Size = new System.Drawing.Size(96, 22);
            this.tbTerMode.TabIndex = 11;
            this.tbTerMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panelNode
            // 
            this.panelNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelNode.Controls.Add(this.tbNodeID);
            this.panelNode.Controls.Add(this.label9);
            this.panelNode.Controls.Add(this.tbIPAddr);
            this.panelNode.Controls.Add(this.label8);
            this.panelNode.Controls.Add(this.tbDeletingPer);
            this.panelNode.Controls.Add(this.label7);
            this.panelNode.Controls.Add(this.label6);
            this.panelNode.Controls.Add(this.tbSendingPer);
            this.panelNode.Controls.Add(this.label5);
            this.panelNode.Controls.Add(this.tbSamplingFreq);
            this.panelNode.Enabled = false;
            this.panelNode.Location = new System.Drawing.Point(864, 91);
            this.panelNode.Margin = new System.Windows.Forms.Padding(2);
            this.panelNode.Name = "panelNode";
            this.panelNode.Size = new System.Drawing.Size(223, 170);
            this.panelNode.TabIndex = 10;
            // 
            // tbNodeID
            // 
            this.tbNodeID.Location = new System.Drawing.Point(80, 1);
            this.tbNodeID.Margin = new System.Windows.Forms.Padding(2);
            this.tbNodeID.Name = "tbNodeID";
            this.tbNodeID.Size = new System.Drawing.Size(135, 22);
            this.tbNodeID.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 5);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Node ID";
            // 
            // tbIPAddr
            // 
            this.tbIPAddr.Location = new System.Drawing.Point(80, 32);
            this.tbIPAddr.Margin = new System.Windows.Forms.Padding(2);
            this.tbIPAddr.Name = "tbIPAddr";
            this.tbIPAddr.Size = new System.Drawing.Size(135, 22);
            this.tbIPAddr.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "IP Address";
            // 
            // tbDeletingPer
            // 
            this.tbDeletingPer.Location = new System.Drawing.Point(164, 138);
            this.tbDeletingPer.Margin = new System.Windows.Forms.Padding(2);
            this.tbDeletingPer.Name = "tbDeletingPer";
            this.tbDeletingPer.Size = new System.Drawing.Size(52, 22);
            this.tbDeletingPer.TabIndex = 7;
            this.tbDeletingPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 141);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Deleting Period (s)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Sending Period (s)";
            // 
            // tbSendingPer
            // 
            this.tbSendingPer.Location = new System.Drawing.Point(164, 106);
            this.tbSendingPer.Margin = new System.Windows.Forms.Padding(2);
            this.tbSendingPer.Name = "tbSendingPer";
            this.tbSendingPer.Size = new System.Drawing.Size(52, 22);
            this.tbSendingPer.TabIndex = 6;
            this.tbSendingPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Sampling Frequency (Hz)";
            // 
            // tbSamplingFreq
            // 
            this.tbSamplingFreq.Location = new System.Drawing.Point(164, 75);
            this.tbSamplingFreq.Margin = new System.Windows.Forms.Padding(2);
            this.tbSamplingFreq.Name = "tbSamplingFreq";
            this.tbSamplingFreq.Size = new System.Drawing.Size(52, 22);
            this.tbSamplingFreq.TabIndex = 5;
            this.tbSamplingFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(864, 265);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "Channel Infomation";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(864, 72);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "Node Infomation";
            // 
            // btStartStop
            // 
            this.btStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btStartStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btStartStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStartStop.Image = global::NI_Data_Collector.Properties.Resources.Start_icon;
            this.btStartStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btStartStop.Location = new System.Drawing.Point(16, 432);
            this.btStartStop.Margin = new System.Windows.Forms.Padding(2);
            this.btStartStop.Name = "btStartStop";
            this.btStartStop.Size = new System.Drawing.Size(98, 34);
            this.btStartStop.TabIndex = 13;
            this.btStartStop.Text = "START";
            this.btStartStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btStartStop.UseVisualStyleBackColor = true;
            this.btStartStop.TextChanged += new System.EventHandler(this.btStartStop_TextChanged);
            this.btStartStop.Click += new System.EventHandler(this.btStartStop_Click);
            // 
            // btAdd
            // 
            this.btAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAdd.Image = ((System.Drawing.Image)(resources.GetObject("btAdd.Image")));
            this.btAdd.Location = new System.Drawing.Point(16, 51);
            this.btAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(32, 32);
            this.btAdd.TabIndex = 1;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRemove
            // 
            this.btRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRemove.Enabled = false;
            this.btRemove.Image = ((System.Drawing.Image)(resources.GetObject("btRemove.Image")));
            this.btRemove.Location = new System.Drawing.Point(48, 51);
            this.btRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(32, 32);
            this.btRemove.TabIndex = 2;
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // lbNumOfNode
            // 
            this.lbNumOfNode.AutoSize = true;
            this.lbNumOfNode.Location = new System.Drawing.Point(98, 59);
            this.lbNumOfNode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNumOfNode.Name = "lbNumOfNode";
            this.lbNumOfNode.Size = new System.Drawing.Size(58, 17);
            this.lbNumOfNode.TabIndex = 16;
            this.lbNumOfNode.Text = "Node: 0";
            // 
            // lbNumOfSensor
            // 
            this.lbNumOfSensor.AutoSize = true;
            this.lbNumOfSensor.Location = new System.Drawing.Point(161, 59);
            this.lbNumOfSensor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNumOfSensor.Name = "lbNumOfSensor";
            this.lbNumOfSensor.Size = new System.Drawing.Size(69, 17);
            this.lbNumOfSensor.TabIndex = 17;
            this.lbNumOfSensor.Text = "Sensor: 0";
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.AutoSize = true;
            this.mainPanel.Location = new System.Drawing.Point(16, 91);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(831, 332);
            this.mainPanel.TabIndex = 18;
            // 
            // btApply
            // 
            this.btApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btApply.Cursor = System.Windows.Forms.Cursors.Default;
            this.btApply.Enabled = false;
            this.btApply.Location = new System.Drawing.Point(1015, 429);
            this.btApply.Margin = new System.Windows.Forms.Padding(2);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(72, 26);
            this.btApply.TabIndex = 12;
            this.btApply.Text = "Apply";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.Teal;
            this.lbTime.Location = new System.Drawing.Point(976, 29);
            this.lbTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(111, 29);
            this.lbTime.TabIndex = 19;
            this.lbTime.Text = "00:00:00";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(134, 442);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Output Directory:";
            // 
            // tbDirectory
            // 
            this.tbDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbDirectory.Location = new System.Drawing.Point(242, 438);
            this.tbDirectory.Margin = new System.Windows.Forms.Padding(2);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(166, 22);
            this.tbDirectory.TabIndex = 21;
            this.tbDirectory.Text = "D:\\SensorData";
            // 
            // btBrowse
            // 
            this.btBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btBrowse.Location = new System.Drawing.Point(415, 438);
            this.btBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(72, 26);
            this.btBrowse.TabIndex = 22;
            this.btBrowse.Text = "Browse";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(911, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 10);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.ForeColor = System.Drawing.Color.Blue;
            this.lbUser.Location = new System.Drawing.Point(98, 19);
            this.lbUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(44, 18);
            this.lbUser.TabIndex = 25;
            this.lbUser.Text = "User";
            // 
            // tbStartWithWin
            // 
            this.tbStartWithWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbStartWithWin.AutoSize = true;
            this.tbStartWithWin.Checked = true;
            this.tbStartWithWin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbStartWithWin.Location = new System.Drawing.Point(16, 472);
            this.tbStartWithWin.Margin = new System.Windows.Forms.Padding(2);
            this.tbStartWithWin.Name = "tbStartWithWin";
            this.tbStartWithWin.Size = new System.Drawing.Size(120, 21);
            this.tbStartWithWin.TabIndex = 26;
            this.tbStartWithWin.Text = "Run at startup";
            this.tbStartWithWin.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1104, 496);
            this.Controls.Add(this.tbStartWithWin);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.tbDirectory);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.lbNumOfSensor);
            this.Controls.Add(this.lbNumOfNode);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btStartStop);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panelNode);
            this.Controls.Add(this.panelChannel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(248, 193);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NI Sensor Data Collector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.panelChannel.ResumeLayout(false);
            this.panelChannel.PerformLayout();
            this.panelNode.ResumeLayout(false);
            this.panelNode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.TextBox tbSensorID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCalibFactor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelChannel;
        private System.Windows.Forms.Panel panelNode;
        private System.Windows.Forms.TextBox tbNodeID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbIPAddr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDeletingPer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSendingPer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSamplingFreq;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btStartStop;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Label lbNumOfNode;
        private System.Windows.Forms.Label lbNumOfSensor;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TextBox tbTerMode;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.FolderBrowserDialog dialogBrowse;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.CheckBox tbStartWithWin;
    }
}

