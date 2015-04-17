using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;
using Communication.Interface;
using Communication.Interface.Interop;

namespace Communication.Interface.UI
{
    public partial class CommunicationViewer : Form
    {
        private enum TransparenceLevel { Low, Mid, High };
        private IntPtr MainHwnd = IntPtr.Zero;
        private System.Threading.Timer WindowPosUpdateTimer = null;
        private Dictionary<ICommunicationInterface, TabPage> IndicatorDictionary = null;
        private Win32Interop.Rect LastPos;

        public CommunicationViewer() : this(IntPtr.Zero)
        {
            InitializeComponent();
            IndicatorDictionary = new Dictionary<ICommunicationInterface, TabPage>();
        }

        public CommunicationViewer(IntPtr Hwnd)
        {
            InitializeComponent();

            IndicatorDictionary = new Dictionary<ICommunicationInterface, TabPage>();
            toolStripDockBtn.Checked = true;
            toolStripTopMostBtn.Checked = false;
            this.TopMost = false;
            SetTransparenceLevel(TransparenceLevel.Low);

            MainHwnd = Hwnd;

            if (MainHwnd != IntPtr.Zero)
            {
                WindowPosUpdateTimer = new System.Threading.Timer(new TimerCallback(ViewerPosUpdateHandler), null, Timeout.Infinite, 300);
            }

            this.VisibleChanged += new EventHandler(Viewer_VisibleChanged);
        }

        public void Release()
        {
            if (WindowPosUpdateTimer != null)
            {
                WindowPosUpdateTimer.Change(Timeout.Infinite, 0); // Stop timer
                WindowPosUpdateTimer.Dispose();
                WindowPosUpdateTimer = null;
            }
            CloseWindow();
        }

        delegate void ShowViewerDelegate();
        public void ShowViewer()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ShowViewerDelegate(ShowViewer), null);
            }
            else
            {
                if (!this.Visible)
                {
                    Show();
                }
                else
                {
                    if (WindowState == System.Windows.Forms.FormWindowState.Minimized)
                    {
                        WindowState = System.Windows.Forms.FormWindowState.Normal;
                        BringToFront();
                    }
                }
            }
        }

        delegate void HideViewerDelegate();
        public void HideViewer()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new HideViewerDelegate(HideViewer), null);
            }
            else
            {
                if (Visible)
                {
                    Hide();
                }
            }
        }

        delegate void CloseWindowDelegate();
        public void CloseWindow()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CloseWindowDelegate(CloseWindow), null);
            }
            else
            {
                Close();
            }
        }

        private void SetTransparenceLevel(TransparenceLevel level)
        {
            switch (level)
            {
                case TransparenceLevel.Low:
                    toolStripTransparenceLow.Checked = true;
                    toolStripTransparenceMid.Checked = false;
                    toolStripTransparenceHigh.Checked = false;
                    this.Opacity = 1.0;
                    break;
                case TransparenceLevel.Mid:
                    toolStripTransparenceLow.Checked = false;
                    toolStripTransparenceMid.Checked = true;
                    toolStripTransparenceHigh.Checked = false;
                    this.Opacity = 0.6;
                    break;
                case TransparenceLevel.High:
                    toolStripTransparenceLow.Checked = false;
                    toolStripTransparenceMid.Checked = false;
                    toolStripTransparenceHigh.Checked = true;
                    this.Opacity = 0.3;
                    break;
            }
        }

        private void Viewer_VisibleChanged(object sender, EventArgs e)
        {
            if (MainHwnd != IntPtr.Zero)
            {
                if (this.Visible)
                {
                    WindowPosUpdateTimer.Change(0, 300);
                }
                else
                {
                    WindowPosUpdateTimer.Change(Timeout.Infinite, 300);
                }
            }
        }

        private void ViewerPosUpdateHandler(object obj)
        {
            if (MainHwnd != IntPtr.Zero)
            {
                if (Win32Interop.IsWindowVisible(MainHwnd))
                {
                    if (!Win32Interop.IsZoomed(MainHwnd))
                    {
                        Win32Interop.Rect WinPos;
                        Win32Interop.GetWindowRect(MainHwnd, out WinPos);
                        if (!WinPos.IsSame(LastPos))
                        {
                            ViewerPosUpdate(WinPos);
                        }
                        LastPos = WinPos;
                    }
                }
            }
        }

        public void ViewerBringToFront()
        {
            if (this.TopMost)
            {
                this.BringToFront();
            }
        }

        public bool IsCoveredByOtherWindow()
        {
            IntPtr TopWindowPtr = IntPtr.Zero;
            Win32Interop.Rect MainWindowRect;
            Win32Interop.GetWindowRect(MainHwnd, out MainWindowRect);

            bool isChild = (0x40000000L == (Win32Interop.GetWindowLong(MainHwnd, -16) & 0x40000000L));    // GWL_STYLE    -16, WS_CHILD   0x40000000L

            if (Win32Interop.GetDesktopWindow() == MainHwnd.ToInt32())
                TopWindowPtr = new IntPtr(Win32Interop.GetWindow(new IntPtr(Win32Interop.GetTopWindow(MainHwnd)), 1));     // GW_HWNDLAST         1
            do
            {
                int WindowHwnd = 0;

                while (0 != (WindowHwnd = Win32Interop.GetWindow(MainHwnd, 3))) // GW_HWNDPREV         3
                {
                    IntPtr WindowPtr = new IntPtr(WindowHwnd);
                    if (Win32Interop.IsWindowVisible(WindowPtr))
                    {
                        Win32Interop.Rect WindowRect;
                        Win32Interop.GetWindowRect(WindowPtr, out WindowRect);

                        if (!((WindowRect.Right < MainWindowRect.Left) || (WindowRect.Left > MainWindowRect.Right) ||
                            (WindowRect.Bottom < MainWindowRect.Top) || (WindowRect.Top > MainWindowRect.Bottom)))
                        {
                            return true;
                        }
                    }
                }

                if (isChild)
                {
                    int ParentHwnd = Win32Interop.GetParent(TopWindowPtr);
                    isChild = ParentHwnd != 0 ? (0x40000000L == (Win32Interop.GetWindowLong(new IntPtr(WindowHwnd), -16) & 0x40000000L)) : false;
                }
                else
                {
                    break;
                }

            } while (true);

            return false;
        }

        delegate void ViewerPosUpdateDelegate(Win32Interop.Rect WinPos);
        public void ViewerPosUpdate(Win32Interop.Rect WinPos)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ViewerPosUpdateDelegate(ViewerPosUpdate), new object[] { WinPos });
            }
            else
            {
                if (toolStripDockBtn.Checked)
                {
                    this.Left = WinPos.Right;
                    this.Top = WinPos.Top;
                    this.Height = WinPos.Bottom - WinPos.Top;
                }
            }
        }

        public void AttachInterface(ICommunicationInterface CommunicationInterface, bool ClearPrevious = true)
        {
            if (!IndicatorDictionary.ContainsKey(CommunicationInterface))
            {
                int index = ContainsFriendlyName(CommunicationInterface);
                if (index == -1)
                {
                    TabPage IndicatorPage = new TabPage(CommunicationInterface.FriendlyName);
                    CommunicationIndicator Indicator = new CommunicationIndicator(CommunicationInterface);
                    Indicator.Dock = DockStyle.Fill;
                    IndicatorPage.Controls.Add(Indicator);

                    AddIndicatorPage(IndicatorPage);
                    IndicatorDictionary.Add(CommunicationInterface, IndicatorPage);
                }
                else
                {
                    TabPage IndicatorPage = IndicatorDictionary.Values.ToList<TabPage>()[index];
                    IndicatorDictionary.Remove(IndicatorDictionary.Keys.ToList<ICommunicationInterface>()[index]);
                    CommunicationIndicator Indicator = (CommunicationIndicator)IndicatorPage.Controls[0];
                    Indicator.Redirect(CommunicationInterface, ClearPrevious);
                    IndicatorDictionary.Add(CommunicationInterface, IndicatorPage);
                }

                SortIndicatorPages();
            }
        }

        public void DeattachInterface(ICommunicationInterface CommunicationInterface)
        {
            if (IndicatorDictionary.ContainsKey(CommunicationInterface))
            {
                TabPage IndicatorPage = IndicatorDictionary[CommunicationInterface];
                RemoveIndicatorPage(IndicatorPage );
                IndicatorDictionary.Remove(CommunicationInterface);
            }
        }

        delegate void AddIndicatorPageDelegate(TabPage IndicatorPage);
        public void AddIndicatorPage(TabPage IndicatorPage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AddIndicatorPageDelegate(AddIndicatorPage), new object[] { IndicatorPage });
            }
            else
            {
                ConsoleHost.TabPages.Add(IndicatorPage);
            }
        }

        delegate void RemoveIndicatorPageDelegate(TabPage IndicatorPage);
        public void RemoveIndicatorPage(TabPage IndicatorPage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new RemoveIndicatorPageDelegate(RemoveIndicatorPage), new object[] { IndicatorPage });
            }
            else
            {
                ConsoleHost.TabPages.Remove(IndicatorPage);
            }
        }

        delegate void SortIndicatorPagesDelegate();
        public void SortIndicatorPages()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SortIndicatorPagesDelegate(SortIndicatorPages), null);
            }
            else
            {
                ArrayList TabNameList = new ArrayList();
                ArrayList TabNameSortedList = new ArrayList();
                TabPage[] TabPages = new TabPage[ConsoleHost.TabPages.Count];

                foreach (TabPage Page in ConsoleHost.TabPages)
                {
                    TabNameList.Add(Page.Text);
                }

                TabNameSortedList.AddRange(TabNameList);
                TabNameSortedList.Sort(StringComparer.Ordinal);

                for (int i = 0; i < ConsoleHost.TabPages.Count; i++)
                {
                    TabPages[i] = ConsoleHost.TabPages[TabNameList.IndexOf(TabNameSortedList[i])];
                }

                ConsoleHost.TabPages.Clear();
                ConsoleHost.TabPages.AddRange(TabPages);
            }
        }

        private int ContainsFriendlyName(ICommunicationInterface CommunicationInterface)
        {
            for (int i = 0; i < IndicatorDictionary.Count; i++)
            {
                if (CommunicationInterface.FriendlyName.Equals(IndicatorDictionary.Keys.ToList<ICommunicationInterface>()[i].FriendlyName))
                {
                    return i;
                }
            }
            return -1;
        }

        private void toolStripTransparenceLow_Click(object sender, EventArgs e)
        {
            if (!toolStripTransparenceLow.Checked)
            {
                SetTransparenceLevel(TransparenceLevel.Low);
            }
        }

        private void toolStripTransparenceMid_Click(object sender, EventArgs e)
        {
            if (!toolStripTransparenceMid.Checked)
            {
                SetTransparenceLevel(TransparenceLevel.Mid);
            }
        }

        private void toolStripTransparenceHigh_Click(object sender, EventArgs e)
        {
            if (!toolStripTransparenceHigh.Checked)
            {
                SetTransparenceLevel(TransparenceLevel.High);
            }
        }

        private void toolStripDockBtn_Click(object sender, EventArgs e)
        {
            toolStripDockBtn.Checked = !toolStripDockBtn.Checked;
        }

        private void toolStripTopMostBtn_Click(object sender, EventArgs e)
        {
            toolStripTopMostBtn.Checked = !toolStripTopMostBtn.Checked;
            this.TopMost = toolStripTopMostBtn.Checked;
        }

    }
}
