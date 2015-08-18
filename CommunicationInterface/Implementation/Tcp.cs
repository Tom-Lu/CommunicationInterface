using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Communication.Interface;

namespace Communication.Interface.Implementation
{
    [InterfaceImplementation(Name = "Tcp", Scheme = "Tcp", ConfigPanel = typeof(Panel.IpPortPanel))]
    public class Tcp : AbsCommunicationInterface
    {
        private IPEndPoint ip_end_point = null;
        private TcpClient tcp_client = null;
        private NetworkStream stream = null;

        public Tcp(string IpAddress, int Port) : base()
        {
            ip_end_point = new IPEndPoint(IPAddress.Parse(IpAddress), Port);
            tcp_client = new TcpClient();
        }

        public Tcp(string ConfigString, string FriendlyName) : base(ConfigString, FriendlyName)
        {
            if (FriendlyName == null || FriendlyName.Equals(string.Empty))
            {
                friendly_name = Config["IP"];
            }
            ip_end_point = new IPEndPoint(IPAddress.Parse(Config["IP"]), int.Parse(Config["Port"]));
            tcp_client = new TcpClient();
        }

        override public bool IsOpened
        {
            get
            {
                try
                {
                    return tcp_client.Connected;
                }
                catch
                {
                    return false;
                }
            }
        }

        override public void Open()
        {
            if (tcp_client != null && ip_end_point != null)
            {
                tcp_client.Connect(ip_end_point);
                stream = tcp_client.GetStream();
            }
        }

        override public void Close()
        {
            if (tcp_client != null)
            {
                tcp_client.Close();
                stream = null;
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
                if (stream.DataAvailable)
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
