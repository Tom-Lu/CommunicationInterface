using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Reflection;
using Communication.Interface;
using System.Threading;

namespace Communication.Interface.UI
{
    public partial class CommunicationIndicator : UserControl
    {
        private bool _ToolbarVisible = true;
        private ICommunicationInterface CommunicationInterface = null;
        private AppendTextEventDelegate AppendTextEventHandler = null;
        private System.Threading.Timer BackgroundReadTimer = null;
        private int SecretCounter = 0;

        [Category("Properties"), Description("Change console toolbar visible properties")]
        public bool ToolbarVisible
        {
            get
            {
                return _ToolbarVisible;
            }
            set
            {
                _ToolbarVisible = value;
                ConsoleToolStrip.Visible = _ToolbarVisible;

                if (_ToolbarVisible)
                {
                    PanelLayout.SetRow(ConsoleToolStrip, 0);
                    PanelLayout.SetRowSpan(ConsoleToolStrip, 1);
                    PanelLayout.SetRow(ConsoleText, 1);
                    PanelLayout.SetRowSpan(ConsoleText, 1);
                    ConsoleText.BorderStyle = BorderStyle.Fixed3D;
                }
                else
                {
                    PanelLayout.SetRow(ConsoleText, 0);
                    PanelLayout.SetRowSpan(ConsoleText, 2);
                    ConsoleText.BorderStyle = BorderStyle.None;
                }
            }
        }

        public void PostMessage(object sender, string Message)
        {
            AppendTextEventProxy(Message, Color.White);
        }

        public CommunicationIndicator()
        {
            InitializeComponent();
            
            AppendTextEventHandler = new AppendTextEventDelegate(AppendTextEventProxy);
            ToolbarVisible = true;
        }

        public CommunicationIndicator(ICommunicationInterface CommunicationInterface)
            : this()
        {
            this.CommunicationInterface = CommunicationInterface;
            this.CommunicationInterface.BufferUpdatedHandler += new OnBufferUpdatedEvent(CommInterface_OnBufferUpdatedHandler);
            this.ConnectionString.Text = this.CommunicationInterface.ConfigString;
        }

        public void Redirect(ICommunicationInterface CommunicationInterface, bool ClearPrevious = true)
        {
            this.CommunicationInterface = CommunicationInterface;
            this.CommunicationInterface.BufferUpdatedHandler += new OnBufferUpdatedEvent(CommInterface_OnBufferUpdatedHandler);

            ConnectionStringProxy(this.CommunicationInterface.ConfigString);

            if (ClearPrevious)
            {
                ClearProxy();
            }
        }

        void CommInterface_OnBufferUpdatedHandler(string Buffer)
        {
            AppendTextEventProxy(Buffer, Color.White);
        }

        void CommInterface_WriteEventHandler(string Buffer)
        {
            AppendTextEventProxy(Buffer, Color.CadetBlue);
        }

        delegate void ConnectionStringDelegate(string text);
        public void ConnectionStringProxy(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ConnectionStringDelegate(ConnectionStringProxy), new object[] { text });
            }
            else
            {
                this.ConnectionString.Text = text;
            }
        }

        delegate void ClearDelegate();
        public void ClearProxy()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ClearDelegate(ClearProxy), null);
            }
            else
            {
                Clear();
            }
        }

        delegate void AppendTextEventDelegate(string text, Color color);
        public void AppendTextEventProxy(string text, Color color)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(AppendTextEventHandler, new object[] { text, color });
            }
            else
            {
                AppendTextEvent(text, color);
            }
        }

        public void AppendTextEvent(string text, Color color)
        {
            if (color != null)
            {
                Append(text, color);
            }
            else
            {
                Append(text);
            }

        }
        public void AppendLine(string text)
        {
            ConsoleText.AppendText(text + "\r\n");
            ConsoleText.ScrollToCaret();
        }
        public void Append(string text)
        {
            ConsoleText.AppendText(text.Replace("\r\r\n", "\r\n"));
            ConsoleText.ScrollToCaret();
        }
        public void Append(string text, Color textColor)
        {
            ConsoleText.AppendText(text.Replace("\r\r\n", "\r\n"));
            ConsoleText.ScrollToCaret();
        }
        public void Append(string text, Font font)
        {
            ConsoleText.AppendText(text.Replace("\r\r\n", "\r\n"));
            ConsoleText.ScrollToCaret();
        }
        public void Append(string text, Color textColor, Font font)
        {
            ConsoleText.AppendText(text.Replace("\r\r\n", "\r\n"));
            ConsoleText.ScrollToCaret();
        }
        public void Clear()
        {
            ConsoleText.Clear();
        }

        private void CleanBtn_Click(object sender, EventArgs e)
        {
            ConsoleText.Clear();
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (ConsoleText.SelectedText.Length > 0)
            {
                Clipboard.SetText(ConsoleText.SelectedText);
            }
            else
            {
                if (ConsoleText.Text.Length > 0)
                {
                    Clipboard.SetText(ConsoleText.Text);
                }
            }
        }

        private void ConsoleText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (InputControlBtn.Enabled && InputControlBtn.Checked)
            {
                if (CommunicationInterface != null)
                {
                    CommunicationInterface.Write(Convert.ToByte(e.KeyChar));
                }
                e.Handled = true;
            }
        }

        private void InputControlBtn_Click(object sender, EventArgs e)
        {
            if (!InputControlBtn.Checked)
            {
                if (BackgroundReadTimer == null)
                {
                    BackgroundReadTimer = new System.Threading.Timer(new TimerCallback(BackgroundReadHandler), null, 0, 100);
                }
                else
                {
                    BackgroundReadTimer.Change(0, 100);
                }
                InputControlBtn.Checked = true;
            }
            else
            {
                if (BackgroundReadTimer != null)
                {
                    BackgroundReadTimer.Change(Timeout.Infinite, 0); // Stop Timer
                }
                InputControlBtn.Checked = false;
            }
        }

        private void BackgroundReadHandler(object obj)
        {
            CommunicationInterface.ReadAll();
        }

        private void ConsoleStatus_Click(object sender, EventArgs e)
        {
            SecretCounter++;
            if (SecretCounter >= 5)
            {
                InputControlBtn.Enabled = !InputControlBtn.Enabled;
                if (!InputControlBtn.Enabled)
                {
                    InputControlBtn.Checked = false;
                    if (BackgroundReadTimer != null)
                    {
                        BackgroundReadTimer.Change(Timeout.Infinite, 0); // Stop timer
                    }
                }
                SecretCounter = 0;
            }
        }    
    }
}
