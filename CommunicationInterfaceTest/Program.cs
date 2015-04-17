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

            ICommunicationInterface CommInterface = CommunicationManager.InstanceInterface("Telnet:IP=127.0.0.1,Port=23", "LocalTest");

            // Buffer update event handler for console applicaiton, for WinForm applicaiton you should use ShowCommunicationViewer to display the trace window
            CommInterface.BufferUpdatedHandler += new OnBufferUpdatedEvent(CommInterface_BufferUpdatedHandler);
            // Open communication interface
            CommInterface.Open();
            if (CommInterface.IsOpened)
            {
                CommInterface.Timeout = 10;
                CommInterface.StopToken = "test>";
                CommInterface.WaitForString("login:", 100);
                CommInterface.WriteLine("test");
                CommInterface.WaitForString("password:", 100);
                Thread.Sleep(100);
                CommInterface.WriteLineWaitToken("test");
                CommInterface.WriteLineWaitToken("ipconfig");
                string LocalIP = string.Empty;
                string LocalIPv6 = string.Empty;
                CommInterface.ReadBuffer.ReadString("IPv4  . . . . . . . . . . . . :", out LocalIP);
                CommInterface.ReadBuffer.ReadString("IPv6 . . . . . . . . :", out LocalIPv6);
                CommInterface.WriteLineWaitToken("arp -a");
                string Mac = string.Empty;
                CommInterface.ReadBuffer.ReadString("192.168.1.1", out Mac);
                CommInterface.WriteLineWaitToken("ping 192.168.1.1");
                CommInterface.ReadBuffer.ReadString(@"IPv4\s*.*:", out Mac);

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
