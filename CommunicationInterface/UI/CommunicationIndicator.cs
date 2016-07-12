using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Communication.Interface.UI
{
    public partial class CommunicationIndicator : UserControl
    {
        private Dictionary<string, string> displayFilters = null;
        private ICommunicationInterface LastInterface = null;

        public CommunicationIndicator() : this(null)
        {
        }

        public CommunicationIndicator(Dictionary<string, string> Filters)
        {
            InitializeComponent();
            displayFilters = Filters;
        }

        public void AttachInterface(ICommunicationInterface CommunicationInterface, bool ClearPrevious = true)
        {
            this.LastInterface = CommunicationInterface;
            CommunicationInterface.BufferUpdatedHandler += new OnBufferUpdatedEvent(CommInterface_OnBufferUpdatedHandler);
            CommunicationInterface.WriteEventHandler += new OnWriteEvent(CommInterface_WriteEventHandler);

            UpdateConnString(this.LastInterface.ConfigString);

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

        public void UpdateConnString(string ConnString)
        {
            RunOnUIThread(delegate()
            {
                this.ConnectionString.Text = ConnString;
                return null;
            });
        }

        public void Clear()
        {
            RunOnUIThread(delegate()
            {
                ConsoleText.Clear();
                return null;
            });
        }

        private void CommInterface_OnBufferUpdatedHandler(string Buffer)
        {
            RunOnUIThread(delegate()
            {
                ConsoleText.AppendText(Buffer);
                return null;
            });
        }

        private void CommInterface_WriteEventHandler(string Buffer)
        {
            RunOnUIThread(delegate()
            {
                ConsoleText.AppendText(Buffer);
                return null;
            });
        }

        delegate object RunOnUIThreadDelegate(Func<object> Function);
        public object RunOnUIThread(Func<object> Function)
        {
            if (this.InvokeRequired)
            {
                RunOnUIThreadDelegate UIThreadDelegate = new RunOnUIThreadDelegate(RunOnUIThread);
                try
                {
                    return Invoke(UIThreadDelegate, Function);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }
            }
            else
            {
                try
                {
                    return Function();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }
            }

        }
    }
}
