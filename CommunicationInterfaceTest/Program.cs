using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Communication.Interface.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create communication interface instance based on connection string: "Telnet:IP=127.0.0.1,Port=23"
            // Connection String Example:
            // SerialPort - "SerialPort:Port=COM5,BaudRate=115200,DataBits=8,Parity=None,StopBits=One"
            // Telnet - "Telnet:IP=127.0.0.1,Port=23"
            // Ssh - "Ssh:IP=192.168.1.100,Port=23,Username=admin, Password=admin"
            // Tcp - "Tcp:IP=127.0.0.1,Port=23"
            // You can use connection builder user interface to configure connection string "ShowCommunicationBuilder"

            CommunicationManager.InitCommunicationViewer(UI.DockType.Right);
            CommunicationManager.ShowCommunicationViewer();
            ICommunicationInterface CommInterface = CommunicationManager.InstanceInterface("Telnet:IP=192.168.106.24,Port=23", "Zhone OLT");

            // Buffer update event handler for console applicaiton, for WinForm applicaiton you should use ShowCommunicationViewer to display the trace window
            CommInterface.BufferUpdatedHandler += new OnBufferUpdatedEvent(CommInterface_BufferUpdatedHandler);
            // Open communication interface
            CommInterface.Open();
            if (CommInterface.IsOpened)
            {
                CommunicationManager.GetCommunicationViewer().AddDisplayFilter("\n\r", "\r\n");
                CommInterface.Timeout = 10;
                CommInterface.LineFeed = "\r\n";

                bool login = CommInterface.WaitForString("login:", 10);
                if (!login)
                {
                    Console.WriteLine("Cannot capture login message!");
                }
                CommInterface.WriteLine("admin");
                CommInterface.WaitForString("password:", 10);
                CommInterface.WriteLine("zhone");
                CommInterface.WaitForString(">", 5);

                CommInterface.StopToken = ">";

                CommInterface.WriteLineWaitToken("swversion");

                Console.WriteLine("Press any key continue ...");
                Console.ReadKey();
            }

            // Close communication interface
            CommInterface.Close();
            CommInterface = null;
        }

        static void CommInterface_BufferUpdatedHandler(string Buffer)
        {
            Console.Write(Buffer);
        }
    }
}
