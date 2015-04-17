using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication.Interface.Implementation;

namespace Communication.Interface.UI
{
    public partial class BufferPanel : UserControl
    {
        public delegate void OnConfigChangeEvent(string Config);
        public event OnConfigChangeEvent OnConfigChange;

        public BufferPanel()
        {
            InitializeComponent();
            DefaultBufferSize();
        }

        private void BufferDefaultBtn_Click(object sender, EventArgs e)
        {
            DefaultBufferSize();
        }

        private void DefaultBufferSize()
        {
            GlobalBufferSize.Text = AbsCommunicationInterface.DefaultGlobalBufferSize.ToString();
            ReadBufferSize.Text = AbsCommunicationInterface.DefaultReadBufferSize.ToString();
        }

        private void BufferConfigCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (BufferConfigCheck.Checked)
            {
                GlobalBufferSize.Enabled = true;
                ReadBufferSize.Enabled = true;
                BufferDefaultBtn.Enabled = true;
            }
            else
            {
                GlobalBufferSize.Enabled = false;
                ReadBufferSize.Enabled = false;
                BufferDefaultBtn.Enabled = false;
            }

            RiseConfigChangeEvent();
        }

        private void BufferSize_TextChanged(object sender, EventArgs e)
        {
            RiseConfigChangeEvent();
        }

        private void RiseConfigChangeEvent()
        {
            if (OnConfigChange != null)
            {
                if (BufferConfigCheck.Checked)
                {
                    OnConfigChange(String.Format("GlobalBuffer={0},ReadBuffer={1}", GlobalBufferSize.Text, ReadBufferSize.Text));
                }
                else
                {
                    OnConfigChange(string.Empty);
                }
            }
        }

    }
}
