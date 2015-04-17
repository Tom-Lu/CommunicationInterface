using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Communication.Interface;

namespace Communication.Interface.UI
{
    public partial class CommunicationBuilder : Form
    {
        private TabPage _BufferPage = null;
        private IConfigPanel _CurrentConfigPanel = null;
        private Dictionary<string, InterfaceImplementation> CommInteraceImp = null;

        private string BufferConfig { get; set; }
        private string InterfaceConfig { get; set; }
        public string ConnectionString
        {
            get
            {
                if (!String.IsNullOrEmpty(BufferConfig))
                {
                    return String.Format("{0},{1}", InterfaceConfig, BufferConfig);
                }
                else
                {
                    return InterfaceConfig;
                }
            }
        }

        internal CommunicationBuilder(Dictionary<string, InterfaceImplementation> CommInteraceImp)
        {
            InitializeComponent();

            this.CommInteraceImp = CommInteraceImp;
            InterfaceConfig = string.Empty;
            BufferConfig = string.Empty;

            _BufferPage = new TabPage("Buffer");

            BufferPanel BufferPanel = new BufferPanel();
            BufferPanel.OnConfigChange += new UI.BufferPanel.OnConfigChangeEvent(BufferPanel_OnConfigChange);
            BufferPanel.Dock = DockStyle.Fill;
            _BufferPage.Controls.Add(BufferPanel);

            InterfaceType.Items.Clear();
            ConfigTabs.TabPages.Clear();

            foreach (InterfaceImplementation imp in CommInteraceImp.Values)
            {
                InterfaceType.Items.Add(imp.Name);
            }

            if (InterfaceType.Items.Count > 0)
            {
                InterfaceType.SelectedIndex = 0;
            }
        }

        void BufferPanel_OnConfigChange(string Config)
        {
            BufferConfig = Config;
            ConnectionStringText.Text = ConnectionString;
        }

        private void InterfaceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InterfaceTypeChange(InterfaceType.SelectedIndex);
        }

        private void InterfaceTypeChange(int Index)
        {
            InterfaceImplementation Implementation = CommInteraceImp.Values.ToArray()[Index];

            ConfigTabs.TabPages.Clear();

            _CurrentConfigPanel = Implementation.ConfigPanelInstance();
            _CurrentConfigPanel.OnConfigChange += new OnConfigChangeEvent(ConfigPanel_OnConfigChange);
            ((Control)_CurrentConfigPanel).Dock = DockStyle.Fill;

            TabPage ConfigPage = new TabPage(Implementation.Name);
            ConfigPage.Controls.Add((Control)_CurrentConfigPanel);
            ConfigTabs.TabPages.Add(ConfigPage);
            ConfigTabs.TabPages.Add(_BufferPage);

            ConfigPanel_OnConfigChange(_CurrentConfigPanel);

        }

        void ConfigPanel_OnConfigChange(IConfigPanel ConfigPanel)
        {
            InterfaceConfig = ConfigPanel.GetConnectionString();
            ConnectionStringText.Text = ConnectionString;
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            Thread workerThread = new Thread(new ThreadStart(UpdateClipboard));
            workerThread.SetApartmentState(ApartmentState.STA);
            workerThread.Start();
        }

        public void UpdateClipboard()
        {
            Clipboard.Clear();
            Clipboard.SetText(ConnectionStringText.Text);
        }
    }
}
