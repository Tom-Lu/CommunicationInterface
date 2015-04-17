using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Communication.Interface;
using Communication.Interface.Interop;
using System.Threading;

namespace CommLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CommunicationManager.InitCommunicationViewer();
            string ConnString = CommunicationManager.ShowCommunicationBuilder();

            if (!string.IsNullOrEmpty(ConnString))
            {
                try
                {
                    ICommunicationInterface CommInterface = CommunicationManager.InstanceInterface(ConnString);
                    CommInterface.Open();
                    if (CommInterface.IsOpened)
                    {
                        Application.Run(CommunicationManager.GetCommunicationViewer());
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
