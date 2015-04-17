using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Communication.Interface;
using System.Windows.Forms;

namespace Communication.Interface
{
    internal class InterfaceImplementation
    {
        public string Name { get; set; }
        public string Scheme { get; set; }
        public Type Type { get; set; }
        public Type ConfigPanel { get; set; }

        public InterfaceImplementation(string Name, string Scheme, Type Type, Type ConfigPanel)
        {
            this.Name = Name;
            this.Scheme = Scheme;
            this.Type = Type;
            this.ConfigPanel = ConfigPanel;
        }

        public ICommunicationInterface Instance(string ConfigString, string FriendlyName)
        {
            ICommunicationInterface Instance = null;

            if (Type != null)
            {
                Instance = (ICommunicationInterface)Activator.CreateInstance(Type, ConfigString, FriendlyName);
            }

            return Instance;
        }

        public IConfigPanel ConfigPanelInstance()
        {
            IConfigPanel Instance = null;

            if (ConfigPanel != null)
            {
                Instance = (IConfigPanel)Activator.CreateInstance(ConfigPanel, Scheme);
            }

            return Instance;
        }
    }
}
