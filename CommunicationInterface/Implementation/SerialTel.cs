using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using Communication.Interface;

namespace Communication.Interface.Implementation
{
    [InterfaceImplementation(Name = "Telnet Through Serial Port", Scheme = "SerialTel", ConfigPanel = typeof(Panel.SerialPortPanel))]
    public class SerialTel : SerialPort
    {
        public SerialTel(string portName, int baudRate, System.IO.Ports.Parity parity, int dataBits, System.IO.Ports.StopBits stopBits)
            : base(portName, baudRate, parity, dataBits, stopBits)
        {
        }

        public SerialTel(string ConfigString, string FriendlyName) : base(ConfigString, FriendlyName)
        {
        }

        override public string ReadUntil(string StopFlag)
        {
            read_buffer.Clear();
            int data = -1;
            int cmd = -1;
            int option = -1;

            do
            {
                data = ReadByte();
                switch (data)
                {
                    case -1:
                        break;
                    case (int) Telnet.TELNET_CMD.IAC:
                        {
                            cmd = ReadByte();
                            if (cmd == -1) break;

                            switch ((Telnet.TELNET_CMD)cmd)
                            {
                                case Telnet.TELNET_CMD.IAC:   // data 0xFF
                                    read_buffer.Append((byte)cmd);
                                    break;
                                case Telnet.TELNET_CMD.DO:
                                    {
                                        option = ReadByte();
                                        // Refuse all request
                                        Write((byte)Telnet.TELNET_CMD.IAC);
                                        Write((byte)Telnet.TELNET_CMD.WONT);
                                        Write((byte)option);
                                        break;
                                    }
                                case Telnet.TELNET_CMD.DONT:
                                    {
                                        ReadByte(); //  Yes, I hear you.
                                        break;
                                    }
                                case Telnet.TELNET_CMD.WILL:
                                    {
                                        option = ReadByte();
                                        Write((byte)Telnet.TELNET_CMD.IAC);
                                        Write((byte)Telnet.TELNET_CMD.DONT);
                                        Write((byte)option);
                                        break;
                                    }
                                case Telnet.TELNET_CMD.WONT:
                                    {
                                        ReadByte(); //  Yes, I hear you.
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
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
                if (FragmentBufferRecord)
                {
                    fragment_buffer.Append((IBufferInternal)read_buffer);
                }

                TriggerBufferUpdateEvent(read_buffer);
            }
            return read_buffer.ToString();
        }  
    }
}
