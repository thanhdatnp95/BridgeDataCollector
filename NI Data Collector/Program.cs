using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NI_Data_Collector
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool result;
            var mutex = new System.Threading.Mutex(true, "SensorDataCollector", out result);

            if (!result)
            {
                //MessageBox.Show("Another instance is already running");
                return;
            }      

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1("Rach Mieu Bridge"));

            GC.KeepAlive(mutex); 
        }        
    }
}
