using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Communication.Interface.UI
{
    public class CommunicationChannel : TabPage, IComparable
    {
        private CommunicationIndicator indicator = null;
        private string _channelName = string.Empty;

        private string ChannelName 
        {
            get { return _channelName; }
            set { _channelName = value; Text = _channelName; }      
        }

        public CommunicationChannel() : this("", null)
        {

        }

        public CommunicationChannel(string Name, Dictionary<string, string> Filters)
        {
            this.ChannelName = Name;
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

        public void Save(string FileName, bool Overwrite)
        {
            if (indicator != null)
            {
                indicator.Save(FileName, Overwrite);
            }
        }

        public void Release()
        {
            if (indicator != null)
            {
                indicator.Release();
            }
        }

        public int CompareTo(object obj)
        {
            if (obj != null && obj is CommunicationChannel)
            {
                return string.Compare(ChannelName, (obj as CommunicationChannel).ChannelName);
            }
            else
            {
                return 1;
            }
        }
    }
}
