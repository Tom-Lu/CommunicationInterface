using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Communication.Interface.UI
{
    public partial class CommunicationIndicator : UserControl
    {
        private Dictionary<string, string> displayFilters = null;
        private ICommunicationInterface latestActiveInterface = null;
        private MemoryStream displayBuffer = null;
        private TextReader displayBufferReader = null;
        private TextWriter displayBufferWriter = null;
        private Thread displayUpdateThread = null;
        private System.Threading.Timer backgroundReadTimer = null;
        private object displayBufferLocker = new object();
        private int interactiveControlCountDown = 0;

        public CommunicationIndicator() : this(null)
        {
        }

        public CommunicationIndicator(Dictionary<string, string> Filters)
        {
            InitializeComponent();
            displayFilters = Filters;
            displayBuffer = new MemoryStream();
            displayBufferReader = new StreamReader(displayBuffer);
            displayBufferWriter = new StreamWriter(displayBuffer);
            StartUpdateThread();
        }

        ~CommunicationIndicator()
        {
            StopUpdateThread();
        }

        public void AttachInterface(ICommunicationInterface CommunicationInterface, bool ClearPrevious = true)
        {
            this.latestActiveInterface = CommunicationInterface;
            CommunicationInterface.BufferUpdatedHandler += new OnBufferUpdatedEvent(CommInterface_OnBufferUpdatedHandler);
            CommunicationInterface.WriteEventHandler += new OnWriteEvent(CommInterface_WriteEventHandler);

            UpdateConnString(this.latestActiveInterface);

            if (ClearPrevious)
            {
                Clear();
            }
        }

        public void DeattachInterface(ICommunicationInterface CommunicationInterface)
        {
            CommunicationInterface.BufferUpdatedHandler -= new OnBufferUpdatedEvent(CommInterface_OnBufferUpdatedHandler);
            CommunicationInterface.WriteEventHandler -= new OnWriteEvent(CommInterface_WriteEventHandler);
        }

        public void UpdateConnString(ICommunicationInterface CommunicationInterface)
        {
            this.SafeInvoke(() =>
            {
                this.ConnectionString.Text = CommunicationInterface.ConfigString;
            });
        }

        public void Clear()
        {
            this.SafeInvoke(() =>
            {
                ConsoleText.Clear();
            });
        }

        public void Release()
        {
            if (backgroundReadTimer != null)
            {
                backgroundReadTimer.Change(Timeout.Infinite, 0); // Stop Timer
            }
            StopUpdateThread();
        }

        private void CommInterface_OnBufferUpdatedHandler(ICommunicationInterface CommunicationInterface, string Buffer)
        {
            lock (displayBufferLocker)
            {
                displayBufferWriter.Write(Buffer);
                displayBufferWriter.Flush();
                latestActiveInterface = CommunicationInterface;
            }
        }

        private void CommInterface_WriteEventHandler(ICommunicationInterface CommunicationInterface, string Buffer)
        {
            if (CommunicationInterface.WriteEcho)
            {
                lock (displayBufferLocker)
                {
                    displayBufferWriter.Write(Buffer);
                }
            }
            latestActiveInterface = CommunicationInterface;
        }

        private void StartUpdateThread()
        {
            if (displayUpdateThread == null)
            {
                displayUpdateThread = new Thread(new ThreadStart(DisplayUpdateHandler));
            }
            displayUpdateThread.Start();
        }

        private void StopUpdateThread()
        {
            if (displayUpdateThread != null)
            {
                Thread tmpThread = displayUpdateThread;
                displayUpdateThread = null;
                tmpThread.Join();
            }
        }

        private void DisplayUpdateHandler()
        {
            while (displayUpdateThread != null)
            {
                lock (displayBufferLocker)
                {
                    if (displayBuffer.Length > 0)
                    {
                        displayBuffer.Seek(0, SeekOrigin.Begin);
                        this.SafeInvoke(() =>
                        {
                            ConsoleText.AppendText(displayBufferReader.ReadToEnd());
                        });
                        displayBuffer.SetLength(0);
                        UpdateConnString(this.latestActiveInterface);
                    }
                }

                Thread.Sleep(100);
            }
        }

        private void toolStripCopySelect_Click(object sender, EventArgs e)
        {
            string TextToClipBoard = string.Empty;
            if (ConsoleText.SelectedText.Length > 0)
            {
                TextToClipBoard = ConsoleText.SelectedText;
            }
            else
            {
                if (ConsoleText.Text.Length > 0)
                {
                    TextToClipBoard = ConsoleText.Text;
                }
            }

            if (!string.IsNullOrEmpty(TextToClipBoard))
            {
                this.SafeInvoke(() =>
                {
                    Clipboard.SetText(TextToClipBoard);
                });
            }
        }

        private void toolStripSave_Click(object sender, EventArgs e)
        {
            string TextToSave = string.Empty;
            if (ConsoleText.SelectedText.Length > 0)
            {
                TextToSave = ConsoleText.SelectedText;
            }
            else
            {
                if (ConsoleText.Text.Length > 0)
                {
                    TextToSave = ConsoleText.Text;
                }
            }

            if (!string.IsNullOrEmpty(TextToSave))
            {
                this.SafeInvoke(() =>
                {
                    SaveFileDialog saveDlg = new SaveFileDialog();
                    saveDlg.DefaultExt = "txt";
                    saveDlg.Filter = "Text files (*.txt)|*.txt|Log files (*.log)|*.log|All files (*.*)|*.*";
                    if (saveDlg.ShowDialog() == DialogResult.OK)
                    {
                        File.AppendAllText(saveDlg.FileName, TextToSave);
                    }
                });
            }
        }

        private void toolStripInteractiveCtrl_Click(object sender, EventArgs e)
        {
            if (!toolStripInteractiveCtrl.Checked)
            {
                if (backgroundReadTimer == null)
                {
                    backgroundReadTimer = new System.Threading.Timer(new TimerCallback(BackgroundReadHandler), null, 0, 100);
                }
                else
                {
                    backgroundReadTimer.Change(0, 100);
                }
                toolStripInteractiveCtrl.Checked = true;
            }
            else
            {
                if (backgroundReadTimer != null)
                {
                    backgroundReadTimer.Change(Timeout.Infinite, 0); // Stop Timer
                }
                toolStripInteractiveCtrl.Checked = false;
            }
        }

        private void StatusBar_DoubleClick(object sender, EventArgs e)
        {
            interactiveControlCountDown++;
            if (interactiveControlCountDown >= 3)
            {
                toolStripInteractiveCtrl.Enabled = !toolStripInteractiveCtrl.Enabled;
                if (!toolStripInteractiveCtrl.Enabled)
                {
                    toolStripInteractiveCtrl.Checked = false;
                    if (backgroundReadTimer != null)
                    {
                        backgroundReadTimer.Change(Timeout.Infinite, 0); // Stop timer
                    }
                }
                interactiveControlCountDown = 0;
            }
        }

        private void BackgroundReadHandler(object obj)
        {
            latestActiveInterface.ReadAll();
        }

    }
}
