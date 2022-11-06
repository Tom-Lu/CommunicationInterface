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
    [InterfaceImplementation(Name = "Ssh", Scheme = "Ssh", ConfigPanel = typeof(Panel.SshPanel))]
    public class PlinkSsh : AbsCommunicationInterface
    {
        private static string PLINK_PATH = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "plink_mod.exe");
        private ProcessStartInfo Plink;
        private Process PlinkProcess;
        private StreamWriter InputStream;
        private StreamReader OutputStream;
        private Queue<byte> OutputBuffer;
        private object OutputBufferLocker = new Object();
        private const int AsyncReadBufferLength = 0x4000;
        private byte[] AsyncReadBuffer;

        public PlinkSsh(string IpAddress, int Port) : base()
        {
            OutputBuffer = new Queue<byte>();

            PLINK_PATH = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "plink_mod.exe");
            if(!File.Exists(PLINK_PATH))
            {
                PLINK_PATH = "plink_mod.exe";
            }

            Plink = new ProcessStartInfo()
            {
                FileName = PLINK_PATH,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                WindowStyle = ProcessWindowStyle.Hidden | ProcessWindowStyle.Minimized,
                CreateNoWindow = true
            };
            Plink.Arguments = String.Format("-ssh {0} -P {1} -x -batch", Port, IpAddress);

        }

        public PlinkSsh(string ConfigString, string FriendlyName)
            : base(ConfigString, FriendlyName)
        {
            if (FriendlyName == null || FriendlyName.Equals(string.Empty))
            {
                friendly_name = Config["IP"];
            }

            OutputBuffer = new Queue<byte>();

            PLINK_PATH = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "plink_mod.exe");
            if (!File.Exists(PLINK_PATH))
            {
                PLINK_PATH = "plink_mod.exe";
            }

            Plink = new ProcessStartInfo()
            {
                FileName = PLINK_PATH,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                WindowStyle = ProcessWindowStyle.Hidden | ProcessWindowStyle.Minimized,
                CreateNoWindow = true
            };

            Plink.Arguments = String.Format("-ssh {0} -P {1}", Config["IP"], int.Parse(Config["Port"]));

            if (Config.ContainsKey("Key") && !Config["Key"].Equals(string.Empty))
            {
                Plink.Arguments += String.Format(" -i {0}", Config["Key"]);
            }

            if (Config.ContainsKey("Username") && !Config["Username"].Equals(string.Empty))
            {
                Plink.Arguments += String.Format(" -l {0}", Config["Username"]);
            }

            if (Config.ContainsKey("Password") && !Config["Password"].Equals(string.Empty))
            {
                Plink.Arguments += String.Format(" -pw {0}", Config["Password"]);
            }

            Plink.Arguments += " -x -batch";
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
                if (InputStream != null)
                {
                    InputStream.BaseStream.Close();
                    InputStream = null;
                }
                if (OutputStream != null)
                {
                    OutputStream.BaseStream.Close();
                    OutputStream = null;
                }
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
                if (ByteWriteMode)
                {
                    foreach (byte dataByte in data)
                    {
                        Thread.Sleep((int)(ByteWriteInterval * 1000));
                        InputStream.BaseStream.WriteByte(dataByte);
                    }
                }
                else
                {
                    InputStream.Write(Encoding.ASCII.GetString(data, 0, data.Length));
                }
            }
        }

        private void BeginOutputStreamRead()
        {
            OutputStream.BaseStream.BeginRead(AsyncReadBuffer, 0, AsyncReadBuffer.Length, new AsyncCallback(OutputStreamReadCallback), null);
        }

        private void OutputStreamReadCallback(IAsyncResult result)
        {
            if (OutputStream != null)
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
