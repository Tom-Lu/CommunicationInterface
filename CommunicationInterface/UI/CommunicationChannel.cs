using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Communication.Interface.UI
{
    public class CommunicationChannel : TabPage
    {
        private CommunicationIndicator indicator = null;
        private string ChannelName = string.Empty;

        private string Name 
        {
            get { return ChannelName; }
            set { ChannelName = value; Text = ChannelName; }      
        }

        public CommunicationChannel() : this("", null)
        {

        }

        public CommunicationChannel(string Name, Dictionary<string, string> Filters)
        {
            this.Name = Name;
            indicator = new CommunicationIndicator(Filters);
            indicator.Dock = DockStyle.Fill;
            this.Controls.Add(indicator);
        }

        public void AttachInterface(ICommunicationInterface CommunicationInterface, bool ClearPrevious = true)
        {
            indicator.AttachInterface(CommunicationInterface, ClearPrevious);
        }

        public void DeattachInterface(ICommunicationInterface CommunicationInterface)
        {
            indicator.DeattachInterface(CommunicationInterface);
        }
    }
}
