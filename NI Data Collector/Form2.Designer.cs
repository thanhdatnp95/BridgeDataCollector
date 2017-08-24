namespace NI_Data_Collector
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.tbNodeID = new System.Windows.Forms.TextBox();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.tbSamplingFrequency = new System.Windows.Forms.TextBox();
            this.tbSendingPeriod = new System.Windows.Forms.TextBox();
            this.tbDeletingPeriod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNumofChannels = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Node ID";
            // 
            // tbNodeID
            // 
            this.tbNodeID.Location = new System.Drawing.Point(224, 28);
            this.tbNodeID.Margin = new System.Windows.Forms.Padding(4);
            this.tbNodeID.Name = "tbNodeID";
            this.tbNodeID.Size = new System.Drawing.Size(132, 22);
            this.tbNodeID.TabIndex = 1;
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(224, 124);
            this.tbIPAddress.Margin = new System.Windows.Forms.Padding(4);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(132, 22);
            this.tbIPAddress.TabIndex = 3;
            // 
            // tbSamplingFrequency
            // 
            this.tbSamplingFrequency.Location = new System.Drawing.Point(224, 172);
            this.tbSamplingFrequency.Margin = new System.Windows.Forms.Padding(4);
            this.tbSamplingFrequency.Name = "tbSamplingFrequency";
            this.tbSamplingFrequency.Size = new System.Drawing.Size(132, 22);
            this.tbSamplingFrequency.TabIndex = 4;
            this.tbSamplingFrequency.Text = "50";
            // 
            // tbSendingPeriod
            // 
            this.tbSendingPeriod.Location = new System.Drawing.Point(224, 220);
            this.tbSendingPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.tbSendingPeriod.Name = "tbSendingPeriod";
            this.tbSendingPeriod.Size = new System.Drawing.Size(132, 22);
            this.tbSendingPeriod.TabIndex = 5;
            this.tbSendingPeriod.Text = "300";
            // 
            // tbDeletingPeriod
            // 
            this.tbDeletingPeriod.Location = new System.Drawing.Point(224, 268);
            this.tbDeletingPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.tbDeletingPeriod.Name = "tbDeletingPeriod";
            this.tbDeletingPeriod.Size = new System.Drawing.Size(132, 22);
            this.tbDeletingPeriod.TabIndex = 6;
            this.tbDeletingPeriod.Text = "1200";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "IP Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 175);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sampling Frequency (Hz)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 223);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sending Period (s)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 271);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Deleting Period (s)";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(28, 320);
            this.btOK.Margin = new System.Windows.Forms.Padding(4);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(100, 28);
            this.btOK.TabIndex = 7;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(256, 320);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(100, 28);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 79);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Number of Channels";
            // 
            // tbNumofChannels
            // 
            this.tbNumofChannels.Location = new System.Drawing.Point(224, 76);
            this.tbNumofChannels.Margin = new System.Windows.Forms.Padding(4);
            this.tbNumofChannels.Name = "tbNumofChannels";
            this.tbNumofChannels.Size = new System.Drawing.Size(132, 22);
            this.tbNumofChannels.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 357);
            this.Controls.Add(this.tbNumofChannels);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.tbDeletingPeriod);
            this.Controls.Add(this.tbSendingPeriod);
            this.Controls.Add(this.tbSamplingFrequency);
            this.Controls.Add(this.tbIPAddress);
            this.Controls.Add(this.tbNodeID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Input Node Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNodeID;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.TextBox tbSamplingFrequency;
        private System.Windows.Forms.TextBox tbSendingPeriod;
        private System.Windows.Forms.TextBox tbDeletingPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNumofChannels;
    }
}