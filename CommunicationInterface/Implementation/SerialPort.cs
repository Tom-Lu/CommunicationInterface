using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using Communication.Interface;

namespace Communication.Interface.Implementation
{
    [InterfaceImplementation(Name = "Serial Port", Scheme = "SerialPort", ConfigPanel = typeof(Panel.SerialPortPanel))]
    public class SerialPort : AbsCommunicationInterface
    {
        private System.IO.Ports.SerialPort port = null;
        private Stream stream = null;

        override public bool IsOpened
        {
            get
            {
                if (port == null)
                {
                    return false;
                }
                else
                {
                    return port.IsOpen;
                }
            }
        }

        public System.IO.Ports.Handshake FlowControl
        {
            set
            {
                port.Handshake = value;
            }
        }

        public SerialPort(string portName, int baudRate, System.IO.Ports.Parity parity, int dataBits, System.IO.Ports.StopBits stopBits) : base()
        {
            port = new System.IO.Ports.SerialPort(portName, baudRate, parity, dataBits, stopBits);
        }

        public SerialPort(string ConfigString, string FriendlyName) : base(ConfigString, FriendlyName)
        {
            string Port = Config["Port"];
            int BaudRate = int.Parse(Config["BaudRate"]);
            System.IO.Ports.Parity Parity = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), Config["Parity"]);
            int DataBits = int.Parse(Config["DataBits"]);
            System.IO.Ports.StopBits StopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), Config["StopBits"]);

            if (FriendlyName == null || FriendlyName.Equals(string.Empty))
            {
                friendly_name = Port;
            }
            port = new System.IO.Ports.SerialPort(Port, BaudRate, Parity, DataBits, StopBits);
        }

        override public void Open()
        {
            if (port != null)
            {
                port.Open();
                stream = port.BaseStream;
            }
        }

        override public void Close()
        {
            if (port != null)
            {
                port.Close();
            }
        }

        override public void Flush()
        {
            stream.Flush();
        }

        override public int ReadByte()
        {
            int data = -1;
            if (stream.CanRead)
            {
                if (port.BytesToRead > 0)
                {
                    data = stream.ReadByte();
                }
            }
            return data;
        }

        override public void Write(byte data)
        {
            if (stream.CanWrite)
            {
                stream.WriteByte(data);
            }
        }

        override public void Write(byte[] data)
        {
            if (stream.CanWrite)
            {
                stream.Write(data, 0, data.Length);
            }
        }

    
    }
}
