using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Communication.Interface;

namespace Communication.Interface.Implementation.Panel
{
    public partial class IpPortPanel : AbsConfigPanel
    {
        public IpPortPanel(string Scheme) : base(Scheme)
        {
            InitializeComponent();
        }

        public override string GetConnectionString()
        {
            return String.Format("{0}:IP={1},Port={2}",Scheme, TelnetIP.Text, TelnetPort.Text);
        }

        private void ConfigChange(object sender, EventArgs e)
        {
            RiseConfigChangeEvent();
        }
    }
}
