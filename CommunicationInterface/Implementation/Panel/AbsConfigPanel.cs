using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication.Interface;

namespace Communication.Interface.Implementation.Panel
{
    public class AbsConfigPanel : UserControl, IConfigPanel
    {
        protected string Scheme = string.Empty;
        public event OnConfigChangeEvent OnConfigChange;

        public AbsConfigPanel() { }

        public AbsConfigPanel(string Scheme)
        {
            this.Scheme = Scheme;
        }

        public virtual string GetConnectionString()
        {
            return string.Empty;
        }

        public void RiseConfigChangeEvent()
        {
            if (OnConfigChange != null)
            {
                OnConfigChange(this);
            }
        }
    }
}
