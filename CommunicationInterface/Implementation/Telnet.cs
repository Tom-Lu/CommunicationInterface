using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Communication.Interface;
using System.Threading;

namespace Communication.Interface.Implementation
{
    [InterfaceImplementation(Name = "Telnet", Scheme = "Telnet", ConfigPanel = typeof(Panel.IpPortPanel))]
    public class Telnet : AbsCommunicationInterface
    {
        private IPEndPoint ip_end_point = null;
        private TcpClient tcp_client = null;
        private NetworkStream stream = null;

        public Telnet(string IpAddress, int Port) : base()
        {
            ip_end_point = new IPEndPoint(IPAddress.Parse(IpAddress), Port);
            tcp_client = new TcpClient();
        }

        public Telnet(string ConfigString, string FriendlyName) : base(ConfigString, FriendlyName)
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
                stream.Close();
                stream = null;
                tcp_client.Close();
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
                if (ByteWriteMode)
                {
                    foreach (byte dataByte in data)
                    {
                        Thread.Sleep((int)(ByteWriteInterval * 1000));
                        stream.WriteByte(dataByte);
                    }
                }
                else
                {
                    stream.Write(data, 0, data.Length);
                }
            }
        }

        override public string ReadUntil(string StopFlag)
        {
            read_buffer.Clear();
            int data = -1;
            int cmd = -1;
            int option = -1;
            int previous_data = -1;
            int previous_data2 = -1;

            do
            {
                previous_data2 = previous_data;
                previous_data = data;
                data = ReadByte();

                switch (data)
                {
                    case -1:
                        break;
                    case (int)TELNET_CMD.IAC:
                        {
                            cmd = ReadByte();
                            // File.AppendAllText("d:\\telnet.txt", string.Format("-> IAC: 0x{0:X2}\r\n", cmd));
                            if (cmd == -1) break;

                            switch ((TELNET_CMD)cmd)
                            {
                                case TELNET_CMD.IAC:   // data 0xFF
                                        read_buffer.Append((byte)cmd);
                                        // File.AppendAllText("d:\\telnet.txt", "IAC: IAC\r\n");
                                    break;
                                case TELNET_CMD.DO:
                                    {
                                        option = ReadByte();
                                        // File.AppendAllText("d:\\telnet.txt", string.Format("-> IAC: DO: 0x{0:X2}\r\n", option));
                                        // Refuse all request
                                        Write((byte)TELNET_CMD.IAC);
                                        Write((byte)TELNET_CMD.DONT);
                                        Write((byte)option);
                                        File.AppendAllText("d:\\telnet.txt", string.Format("<- IAC: DO: 0x{0:X2}\r\n", option));
                                        break;
                                    }
                                case TELNET_CMD.DONT:
                                    {
                                        option = ReadByte(); //  Yes, I hear you.
                                        // File.AppendAllText("d:\\telnet.txt", string.Format("-> IAC: DONT: 0x{0:X2}\r\n", option));
                                        break;
                                    }
                                case TELNET_CMD.WILL:
                                    {
                                        option = ReadByte();
                                        // File.AppendAllText("d:\\telnet.txt", string.Format("-> IAC: WILL: 0x{0:X2}\r\n", option));
                                        Write((byte)TELNET_CMD.IAC);
                                        Write((byte)TELNET_CMD.WONT);
                                        Write((byte)option);
                                        // File.AppendAllText("d:\\telnet.txt", string.Format("<- IAC: DO: 0x{0:X2}\r\n", option));
                                        break;
                                    }
                                case TELNET_CMD.WONT:
                                    {
                                        option = ReadByte(); //  Yes, I hear you.
                                        // File.AppendAllText("d:\\telnet.txt", string.Format("-> IAC: WONT: 0x{0:X2}\r\n", option));
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case 0:
                        // Do Nothing if read 0
                        break;
                    default:
                        read_buffer.Append((byte)data);
                        break;
                }

                if (StopFlag != null && !StopFlag.Equals(string.Empty))
                {
                    if (((IBuffer)read_buffer).Contains(StopFlag))
                    {
                        break;
                    }
                }

            } while (data != -1);

            if (!read_buffer.IsEmpty())
            {
                global_buffer.Append((IBufferInternal)read_buffer);
                if (fragment_buffer_record)
                {
                    fragment_buffer.Append((IBufferInternal)read_buffer);
                }

                TriggerBufferUpdateEvent(read_buffer);
            }
            return read_buffer.ToString();
        }

        internal enum TELNET_CMD
        {
            XEOF = 236,         // End of file
            SUSP = 237,         // Suspend process
            ABORT = 238,        // Abort process
            EOR = 239,          // End of record
            SE = 240,           // End of subnegotiation parameters.
            NOP = 241,          // No operation.
            DATA_MARK = 242,    // The data stream portion of a Synch. This should always be accompanied by a TCP Urgent notification.
            BREAK = 243,        // NVT character BRK.
            IP = 244,           // Interrupt Process
            AO = 245,           // Abort output
            AYT = 246,          // Are You There
            EC = 247,           // Erase character
            EL = 248,           // Erase Line
            GA = 249,           // Go ahead
            SB = 250,           // Indicates that what follows is subnegotiation of the indicated option.
            WILL = 251,         // Indicates the desire to begin performing, or confirmation that you are now performing, the indicated option.
            WONT = 252,         // Indicates the refusal to perform, or continue performing, the indicated option.
            DO = 253,           // Indicates the request that the other party perform, or confirmation that you are expecting the other party to perform, the indicated option.
            DONT = 254,         // Indicates the demand that the other party stop performing, or confirmation that you are no longer expecting the other party to perform, the indicated option.
            IAC = 255           // Data Byte 255.
        }

        internal enum TELNET_OPT
        {
            BINARY = 0,             // 8-bit data path
            ECHO = 1,               // echo
            RCP = 2,                // prepare to reconnect
            SGA = 3,                // suppress go ahead
            NAMS = 4,               // approximate message size
            STATUS = 5,             // give status
            TM = 6,                 // timing mark
            RCTE = 7,               // remote controlled transmission and echo
            NAOL = 8,               // negotiate about output line width
            NAOP = 9,               // negotiate about output page size
            NAOCRD = 10,            // negotiate about CR disposition
            NAOHTS = 11,            // negotiate about horizontal tabstops
            NAOHTD = 12,            // negotiate about horizontal tab disposition
            NAOFFD = 13,            // negotiate about formfeed disposition
            NAOVTS = 14,            // negotiate about vertical tab stops
            NAOVTD = 15,            // negotiate about vertical tab disposition
            NAOLFD = 16,            // negotiate about output LF disposition
            XASCII = 17,            // extended ascic character set
            LOGOUT = 18,            // force logout
            BM = 19,                // byte macro
            DET = 20,               // data entry terminal
            SUPDUP = 21,            // supdup protocol
            SUPDUPOUTPUT = 22,      // supdup output
            SNDLOC = 23,            // send location
            TTYPE = 24,             // terminal type
            EOR = 25,               // end or record
            TUID = 26,              // TACACS user identification
            OUTMRK = 27,            // output marking
            TTYLOC = 28,            // terminal location number
            _3270REGIME = 29,       // 3270 regime
            X3PAD = 30,             // X.3 PAD
            NAWS = 31,              // window size
            TSPEED = 32,            // terminal speed
            LFLOW = 33,             // remote flow control
            LINEMODE = 34,          // Linemode option
            XDISPLOC = 35,          // X Display Location
            OLD_ENVIRON = 36,       // Old - Environment variables
            AUTHENTICATION = 37,    // Authenticate
            ENCRYPT = 38,           // Encryption option
            NEW_ENVIRON = 39,       // New - Environment variables
            TN3270E = 40,           // TN3270 enhancements
            XAUTH = 41,
            CHARSET = 42,           // Character set
            RSP = 43,               // Remote serial port
            COM_PORT_OPTION = 44,   // Com port control
            SLE = 45,               // Suppress local echo
            STARTTLS = 46,          // Start TLS
            KERMIT = 47,            // Automatic Kermit file transfer
            SEND_URL = 48,
            FORWARD_X = 49,
            PRAGMA_LOGON = 138,
            SSPI_LOGON = 139,
            PRAGMA_HEARTBEAT = 140,
            EXOPL = 255             // extended-options-list
        }

    }
}
