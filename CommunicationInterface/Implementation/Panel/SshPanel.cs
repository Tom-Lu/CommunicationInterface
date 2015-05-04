using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Communication.Interface;

namespace Communication.Interface.Implementation.Panel
{
    public partial class SshPanel : AbsConfigPanel
    {
        public SshPanel(string Scheme) : base(Scheme)
        {
            InitializeComponent();
        }

        public override string GetConnectionString()
        {
            StringBuilder ConnectionString = new StringBuilder();
            ConnectionString.AppendFormat("Ssh:IP={0},Port={1}", SshIP.Text, SshPort.Text);

            if (!String.IsNullOrEmpty(SshKeyFile.Text))
            {
                ConnectionString.AppendFormat(",Key={0}", SshKeyFile.Text);
            }
            else
            {
                ConnectionString.AppendFormat(",Username={0}, Password={1}", SshUsername.Text, SshPassword.Text);
            }

            return ConnectionString.ToString();
        }

        private void ConfigChange(object sender, EventArgs e)
        {
            RiseConfigChangeEvent();
        }

        private void SshKeyBrowse_Click(object sender, EventArgs e)
        {
            Thread viewer_thread = new Thread(new ThreadStart(delegate()
            {
                OpenFileDialog openDlg = new OpenFileDialog();
                openDlg.CheckFileExists = true;
                if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SetSshKeyFile(openDlg.FileName);
                }
            }));
            viewer_thread.SetApartmentState(ApartmentState.STA);
            viewer_thread.Start();
        }

        private delegate void UpdateSshKeyFile(string value);

        private void SetSshKeyFile(string value)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new UpdateSshKeyFile(SetSshKeyFile), value);
            }
            else
            {
                SshKeyFile.Text = value;
            }
        } 
    }
}
