using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Communication.Interface;
using System.Threading;

namespace Communication.Interface.Implementation
{
    public abstract class AbsCommunicationInterface : ICommunicationInterface
    {
        protected string DEFAULT_LINE_FEED = "\r\n";
        public static readonly int DefaultGlobalBufferSize = 40960;
        public static readonly int DefaultFragmentBufferSize = 4096;
        public static readonly int DefaultReadBufferSize = 4096;

        internal IBufferInternal global_buffer = null;
        internal IBufferInternal fragment_buffer = null;
        internal IBufferInternal read_buffer = null;

        internal bool FragmentBufferRecord = false;
        private string config_string = string.Empty;
        protected string friendly_name = string.Empty;
        protected Dictionary<string, string> Config = null;

        public event OnBufferUpdatedEvent BufferUpdatedHandler;
        public event OnWriteEvent WriteEventHandler;

        internal AbsCommunicationInterface()
        {
            global_buffer = new Buffer(DefaultGlobalBufferSize);
            fragment_buffer = new Buffer(DefaultFragmentBufferSize);
            read_buffer = new Buffer(DefaultReadBufferSize);
            Timeout = 10;
            StopToken = string.Empty;
            LineFeed = DEFAULT_LINE_FEED;
            WriteReadInterval = 0.1;
            WriteReadLoopInterval = 0.5;
            WriteEcho = false;
        }

        /// <summary>
        /// Constructor using configuration string
        /// </summary>
        /// <param name="ConfigString">Configuration String</param>
        /// <param name="FriendlyName">Friendly Name</param>
        internal AbsCommunicationInterface(string ConfigString, string FriendlyName) : this()
        {
            this.config_string = ConfigString;
            this.friendly_name = FriendlyName;
            Config = new Dictionary<string, string>();
            string[] ConfigItem = ConfigString.Split(new char[] { ',' });

            // Parse all config elements
            foreach (string Item in ConfigItem)
            {
                string[] ConfigNameAndValue = Item.Split(new char[] { '=' });
                if (ConfigNameAndValue.Length >= 2 && !ConfigNameAndValue[0].Equals(string.Empty))
                {
                    Config.Add(ConfigNameAndValue[0].Trim(), ConfigNameAndValue[1].Trim());
                }
            }

            // Global buffer setup
            if (Config.ContainsKey("GlobalBuffer"))
            {
                global_buffer = null;
                global_buffer = new Buffer(int.Parse(Config["GlobalBuffer"]));
            }

            // Read buffer setup
            if (Config.ContainsKey("ReadBuffer"))
            {
                read_buffer = null;
                read_buffer = new Buffer(int.Parse(Config["ReadBuffer"]));
            }

            fragment_buffer = new Buffer(DefaultFragmentBufferSize);
        }

        public string StopToken { get; set; }
        public string LineFeed { get; set; }
        abstract public bool IsOpened { get; }
        public bool WriteEcho { get; set; }
        public double WriteReadInterval { get; set; }
        public double WriteReadLoopInterval { get; set; }

        public string FriendlyName { get { return friendly_name; } }
        public string ConfigString { get { return config_string; } }
        public IBuffer ReadBuffer { get { return (IBuffer)read_buffer; } }
        public IBuffer FragmentBuffer { get { return (IBuffer)fragment_buffer; } }
        public IBuffer GlobalBuffer { get { return (IBuffer)global_buffer; } }

        public double Timeout { get; set; }
        abstract public void Flush();
        abstract public void Open();
        abstract public void Close();
        abstract public int ReadByte();
        abstract public void Write(byte data);
        abstract public void Write(byte[] data);

        public string ReadAll()
        {
            return ReadUntil(string.Empty);
        }

        public string ReadAll(double Timespan)
        {
            StringBuilder last_read_buffer = new StringBuilder(255);
            DateTime start_time = DateTime.Now;

            if (Timespan == -1)
            {
                do
                {
                    last_read_buffer.Append(ReadAll());
                } while (true);
            }
            else
            {
                do
                {
                    last_read_buffer.Append(ReadAll());
                } while (((DateTime.Now - start_time).TotalSeconds < Timespan));
            }

            ((IBufferInternal)read_buffer).Copy(last_read_buffer);
            return read_buffer.ToString();
        }

        virtual public string ReadUntil(string StopFlag)
        {
            read_buffer.Clear();

            int data = -1;
            do
            {
                data = ReadByte();
                if (data != -1 && data != 0)
                {
                    read_buffer.Append((byte)data);

                    if (StopFlag != null && !StopFlag.Equals(string.Empty))
                    {
                        if (((IBuffer)read_buffer).Contains(StopFlag))
                        {
                            break;
                        }
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

        public bool WaitForString(string Pattern, double Timeout)
        {
            StringBuilder last_read_buffer = new StringBuilder(255);
            DateTime start_time = DateTime.Now;

            do
            {
                last_read_buffer.Append(ReadUntil(Pattern));
            } while (!last_read_buffer.ToString().Contains(Pattern) && ((DateTime.Now - start_time).TotalSeconds < Timeout));

            ((IBufferInternal)read_buffer).Copy(last_read_buffer);
            return read_buffer.ToString().Contains(Pattern);
        }

        public bool WaitForQuiet(double QuietTime, double Timeout)
        {
            bool quiet_status = false;
            StringBuilder last_read_buffer = new StringBuilder(255);
            DateTime start_time = DateTime.Now;
            DateTime last_respond = DateTime.Now;
            string last_read = string.Empty;

            do
            {
                last_read = ReadAll();
                if (last_read.Length > 0)
                {
                    last_respond = DateTime.Now;
                    last_read_buffer.Append(last_read);
                }
                else
                {
                    quiet_status = ((DateTime.Now - last_respond).TotalSeconds >= QuietTime);
                }
            }
            while (!quiet_status && ((DateTime.Now - start_time).TotalSeconds < Timeout));
            ((IBufferInternal)read_buffer).Copy(last_read_buffer);
            return quiet_status;
        }

        public void Write(string command)
        {
            Write(Encoding.ASCII.GetBytes(command));
            TriggerWriteEvent(command);
        }

        public void WriteLine(string command)
        {
            Write(command + LineFeed);
        }

        public void WriteRead(string command, double delay)
        {
            Write(command);
            if (delay > 0)
            {
                Thread.Sleep((int)(delay * 1000));
            }
            ReadAll();
        }

        public void WriteLineRead(string command, double delay)
        {
            WriteLine(command);
            if (delay > 0)
            {
                Thread.Sleep((int)(delay * 1000));
            }
            ReadAll();
        }

        public bool WriteWaitToken(string command)
        {
            bool Status = false;

            StringBuilder last_read_buffer = new StringBuilder(255);
            last_read_buffer.Append(ReadAll());    // Read All Previous Content

            Write(command);
            Thread.Sleep((int)(WriteReadInterval * 1000));
            Status = WaitForString(StopToken, Timeout);

            last_read_buffer.Append(read_buffer.ToString());
            ((IBufferInternal)read_buffer).Copy(last_read_buffer);

            return Status;
        }

        public bool WriteWaitTokenUntil(string Command, string Pattern, double Timeout)
        {
            StringBuilder last_read_buffer = new StringBuilder(255);
            DateTime start_time = DateTime.Now;

            do
            {
                WriteWaitToken(Command);
                last_read_buffer.Append(read_buffer.ToString());
                Thread.Sleep((int)(WriteReadLoopInterval * 1000));
            } while (!last_read_buffer.ToString().Contains(Pattern) && ((DateTime.Now - start_time).TotalSeconds < Timeout));

            ((IBufferInternal)read_buffer).Copy(last_read_buffer);
            return read_buffer.ToString().Contains(Pattern);
        }

        public bool WriteLineWaitToken(string Command)
        {
            return WriteWaitToken(Command + LineFeed);
        }

        public bool WriteLineWaitTokenUntil(string Command, string Pattern, double Timeout)
        {
            return WriteWaitTokenUntil(Command + LineFeed, Pattern, Timeout);
        }

        public void StartFragmentBufferRecord()
        {
            FragmentBufferRecord = true;
            FragmentBuffer.Clear();
        }

        public IBuffer StopFragmentBufferRecord()
        {
            FragmentBufferRecord = false;
            return FragmentBuffer;
        }

        protected void TriggerBufferUpdateEvent(IBufferInternal ReadBuffer)
        {
            if (BufferUpdatedHandler != null)
            {
                BufferUpdatedHandler(ReadBuffer.ToString());
            }
        }

        protected void TriggerWriteEvent(string WriteBuffer)
        {
            if (WriteEventHandler != null)
            {
                WriteEventHandler(WriteBuffer);
            }
        }
    }
}
