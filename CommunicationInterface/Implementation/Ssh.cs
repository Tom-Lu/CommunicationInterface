using System;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using Communication.Interface;
using System.Threading;
using System.Collections.Generic;

namespace Communication.Interface.Implementation
{
    [InterfaceImplementation(Name = "SSH", Scheme = "Ssh", ConfigPanel = typeof(Panel.SshPanel))]
    public class Ssh : AbsCommunicationInterface
    {
        private static string PLINK_PATH = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "plink.exe");
        private ProcessStartInfo Plink;
        private Process PlinkProcess;
        private StreamWriter InputStream;
        private StreamReader OutputStream;
        private Queue<byte> OutputBuffer;
        private object OutputBufferLocker = new Object();
        private const int AsyncReadBufferLength = 0x1000;
        private byte[] AsyncReadBuffer;

        public Ssh(string IpAddress, int Port) : base()
        {
            OutputBuffer = new Queue<byte>();
            Plink = new ProcessStartInfo()
            {
                FileName = PLINK_PATH,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = false
            };
            Plink.Arguments = String.Format("-P {0} {1}", Port, IpAddress);

        }

        public Ssh(string ConfigString, string FriendlyName)
            : base(ConfigString, FriendlyName)
        {
            if (FriendlyName == null || FriendlyName.Equals(string.Empty))
            {
                friendly_name = Config["IP"];
            }

            OutputBuffer = new Queue<byte>();
            Plink = new ProcessStartInfo()
            {
                FileName = PLINK_PATH,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = false
            };

            if (Config.ContainsKey("Key"))
            {
                Plink.Arguments = String.Format(" -i {0}", Config["Key"]);
            }
            else
            {
                Plink.Arguments = String.Format(" -l {0} -pw {1}", Config["Username"], Config["Password"]);
            }

            Plink.Arguments += String.Format(" -P {0} {1}", int.Parse(Config["Port"]), Config["IP"]);
        }

        override public bool IsOpened
        {
            get
            {
                try
                {
                    return PlinkProcess != null && !PlinkProcess.HasExited;
                }
                catch
                {
                    return false;
                }
            }
        }

        override public void Open()
        {
            if (Plink != null)
            {
                AsyncReadBuffer = new byte[AsyncReadBufferLength];
                PlinkProcess = Process.Start(Plink);
                InputStream = PlinkProcess.StandardInput;
                OutputStream = PlinkProcess.StandardOutput;
                BeginOutputStreamRead();
            }
        }

        override public void Close()
        {
            if (IsOpened)
            {
                PlinkProcess.Kill();
            }
        }

        override public void Flush()
        {
            InputStream.Flush();
        }

        override public int ReadByte()
        {
            int data = -1;

            if (OutputBuffer != null)
            {
                lock (OutputBufferLocker)
                {
                    if (OutputBuffer.Count > 0)
                    {
                        data = OutputBuffer.Dequeue();
                    }
                }
            }
            return data;
        }

        override public void Write(byte data)
        {
            if (InputStream.BaseStream.CanWrite)
            {
                InputStream.BaseStream.WriteByte(data);
            }
        }

        override public void Write(byte[] data)
        {
            if (InputStream.BaseStream.CanWrite)
            {
                InputStream.Write(Encoding.Default.GetString(data, 0, data.Length));
            }
        }

        private void BeginOutputStreamRead()
        {
            OutputStream.BaseStream.BeginRead(AsyncReadBuffer, 0, AsyncReadBuffer.Length, new AsyncCallback(OutputStreamReadCallback), null);
        }

        private void OutputStreamReadCallback(IAsyncResult result)
        {
            int ReadLenght = OutputStream.BaseStream.EndRead(result);
            if (ReadLenght > 0)
            {
                OutputBufferEnqueue(ReadLenght);
                BeginOutputStreamRead();
            }
            else if (ReadLenght < 0)
            {
                BeginOutputStreamRead();
            }
        }

        private void OutputBufferEnqueue(int Length)
        {
            lock (OutputBufferLocker)
            {
                for (int i = 0; i < Length; i++)
                {
                    OutputBuffer.Enqueue(AsyncReadBuffer[i]);
                }
            }
        }
    }
}
