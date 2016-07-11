using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Communication.Interface.UI
{
    public enum DockType
    {
        None,
        Left,
        Top,
        Right,
        Bottom
    }

    public partial class CommunicationViewer : Form
    {
        public CommunicationViewer()
        {
            InitializeComponent();
        }

        public void AddDisplayFilter(string test, string sss)
        {

        }
    }
}
