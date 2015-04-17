using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Communication.Interface;

namespace Communication.Interface.Implementation.Panel
{
    public partial class SerialPortPanel : AbsConfigPanel
    {
        public SerialPortPanel(string Scheme) : base(Scheme)
        {
            InitializeComponent();
            SerialPortText.Items.Clear();
            SerialPortText.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());

            SerialPortText.SelectedIndex = 0;
            BaudRateText.SelectedIndex = 9;
            DataBitText.SelectedIndex = 1;
            ParityText.SelectedIndex = 0;
            StopBitText.SelectedIndex = 0;
        }

        public override string GetConnectionString()
        {
            return String.Format("{0}:Port={1},BaudRate={2},DataBits={3},Parity={4},StopBits={5}",Scheme, SerialPortText.Text, BaudRateText.Text, DataBitText.Text, ParityText.Text, StopBitText.Text);
        }

        private void ConfigChange(object sender, EventArgs e)
        {
            RiseConfigChangeEvent();
        }
    }
}
