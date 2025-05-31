using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using Communication.Interface.Interop;

namespace Communication.Interface.UI
{
    public enum DockType { None, Left, Top, Right, Bottom }

    public partial class CommunicationViewer : Form, ICommunicationViewer
    {
        private enum TransparenceLevel { Low, Mid, High };
        private DockType dock = DockType.Right;
        private IntPtr mainWindowHandle = IntPtr.Zero;
        private Win32Interop.Rect lastPosition;
        private System.Threading.Timer windowUpdateTimer = null;
        private System.Threading.Thread viewerThread = null;
        private Dictionary<string, CommunicationChannel> channels = null;
        private Dictionary<string, string> displayFilters = null;

        public CommunicationViewer():this(DockType.None)
        {
        }

        public CommunicationViewer(DockType dock)
        {
            InitializeComponent();

            Version LibraryVersion = Assembly.GetExecutingAssembly().GetName().Version;
            DateTime BuildDate = new DateTime(2000, 1, 1).AddDays(LibraryVersion.Build).AddSeconds(LibraryVersion.Revision * 2);

            this.Text = string.Format("CommViewer V{0}.{1}.{2} {3}", LibraryVersion.Major, LibraryVersion.Minor, LibraryVersion.Revision, BuildDate.ToString("yyyyMMddHHmmss"));
            this.dock = dock;

            SetDockType(dock);
            SetTransparenceLevel(TransparenceLevel.Low);
            this.VisibleChanged += new EventHandler(Viewer_VisibleChanged);

            channels = new Dictionary<string, CommunicationChannel>();
            displayFilters = new Dictionary<string, string>();
        }

        ~CommunicationViewer()
        {
            Release();
        }

        public ICommunicationViewer AddDisplayFilter(string Source, string Target)
        {
            if (displayFilters != null)
            {
                if (displayFilters.ContainsKey(Source))
                {
                    displayFilters[Source] = Target;
                }
                else
                {
                    displayFilters.Add(Source, Target);
                }
            }
            return this;
        }

        public void ClearDisplayFilter()
        {
            if (displayFilters != null)
            {
                displayFilters.Clear();
            }
        }

        private void ViewerPosUpdateHandler(object obj)
        {
            if (mainWindowHandle != IntPtr.Zero && dock != DockType.None)
            {
                if (Win32Interop.IsWindowVisible(mainWindowHandle))
                {
                    if (!Win32Interop.IsZoomed(mainWindowHandle))
                    {
                        Win32Interop.Rect currentPosition;
                        Win32Interop.GetWindowRect(mainWindowHandle, out currentPosition);
                        if (!currentPosition.IsSame(lastPosition))
                        {
                            this.SafeInvoke(() =>
                            {
                                ViewerPosUpdate(currentPosition);
                            });

                            lastPosition = currentPosition;
                        }
                    }
                }
            }
        }

        private void ViewerPosUpdate(Win32Interop.Rect WindowPosition)
        {
            switch (dock)
            {
                case DockType.None:
                    break;
                case DockType.Left:
                    {
                        Screen screen = Screen.FromPoint(new Point(WindowPosition.Left, WindowPosition.Top));
                        this.Left = screen.WorkingArea.Left;
                        this.Top = WindowPosition.Top;
                        this.Height = WindowPosition.Bottom - WindowPosition.Top;
                        this.Width = (WindowPosition.Left - screen.WorkingArea.Left);
                    }
                    break;
                case DockType.Top:
                    {
                        this.Left = WindowPosition.Left;
                        this.Top = WindowPosition.Top - this.Height;
                        this.Width = WindowPosition.Right - WindowPosition.Left;
                    }
                    break;
                case DockType.Right:
                    {
                        this.Left = WindowPosition.Right;
                        this.Top = WindowPosition.Top;
                        this.Height = WindowPosition.Bottom - WindowPosition.Top;
                        Screen screen = Screen.FromPoint(new Point(WindowPosition.Left, WindowPosition.Top));
                        this.Width = screen.WorkingArea.Width - (WindowPosition.Right - screen.WorkingArea.Left);
                    }
                    break;
                case DockType.Bottom:
                    {
                        this.Left = WindowPosition.Left;
                        this.Top = WindowPosition.Bottom;
                        this.Width = WindowPosition.Right - WindowPosition.Left;
                    }
                    break;
            }
        }

        public void ShowViewer()
        {
            this.SafeInvoke(() =>
            {
                if (!this.Visible)
                {
                    viewerThread = new Thread(new ParameterizedThreadStart(delegate(object obj)
                    {
                        ShowDialog();
                    }));

                    if (Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
                    {
                        viewerThread.SetApartmentState(ApartmentState.STA);
                    }
                    viewerThread.Start();
                    Thread.Sleep(1000);
                }
                else
                {
                    if (WindowState == System.Windows.Forms.FormWindowState.Minimized)
                    {
                        WindowState = System.Windows.Forms.FormWindowState.Normal;
                        BringToFront();
                    }
                }
            });
        }

        public void HideViewer()
        {
            this.SafeInvoke(() =>
            {
                Hide();
            });
        }

        public void Release()
        {
            this.SafeInvoke(() =>
            {
                StopUpdateTimer();
                Close();
                if(viewerThread != null && viewerThread.IsAlive)
                {
                    try
                    {
                        viewerThread.Interrupt();
                    }
                    catch { }
                }
            });
        }

        private void StartUpdateTimer()
        {
            lastPosition = Win32Interop.Rect.Zero();

            mainWindowHandle = Process.GetCurrentProcess().MainWindowHandle; // Win32Window.GetCurrentProcessMainWindowHandle();
            if (mainWindowHandle != IntPtr.Zero)
            {
                windowUpdateTimer = new System.Threading.Timer(new TimerCallback(ViewerPosUpdateHandler), null, Timeout.Infinite, 300);
            }
            else
            {
                toolStripDock.Enabled = false;
            }
        }

        private void StopUpdateTimer()
        {
            if (windowUpdateTimer != null)
            {
                windowUpdateTimer.Change(Timeout.Infinite, 0); // Stop timer
                windowUpdateTimer.Dispose();
                windowUpdateTimer = null;
            }
        }

        public void AttachInterface(ICommunicationInterface CommunicationInterface, bool ClearPrevious = true)
        {
            string ChannelName = CommunicationInterface.FriendlyName;
            if (!channels.ContainsKey(ChannelName))
            {
                this.SafeInvoke(() =>
                {
                    CommunicationChannel channel = new CommunicationChannel(ChannelName, displayFilters);
                    channel.AttachInterface(CommunicationInterface, ClearPrevious);
                    channels.Add(ChannelName, channel);
                    ChannelHost.TabPages.Add(channel);
                    SortChannelDisplay();
                });
            }
            else
            {
                this.SafeInvoke(() =>
                {
                    CommunicationChannel channel = channels[ChannelName];
                    channel.AttachInterface(CommunicationInterface, ClearPrevious);
                });
            }
        }

        public CommunicationChannel GetCommunicationChannel(ICommunicationInterface CommunicationInterface)
        {
            return channels[CommunicationInterface.FriendlyName];
        }

        public void DeattachInterface(ICommunicationInterface CommunicationInterface)
        {
            string ChannelName = CommunicationInterface.FriendlyName;
            if (channels.ContainsKey(ChannelName))
            {
                CommunicationChannel channel = channels[ChannelName];
                channel.DeattachInterface(CommunicationInterface);
            }
        }

        public void Save(string FriendlyName, string FileName, bool Overwrite)
        {
            string ChannelName = FriendlyName;
            if (channels.ContainsKey(ChannelName))
            {
                CommunicationChannel channel = channels[ChannelName];
                channel.Save(FileName, Overwrite);
            }
        }

        private void SortChannelDisplay()
        {
            channels = channels.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            ArrayList TabNameSortedList = new ArrayList();
            CommunicationChannel SelectedChannel = (CommunicationChannel)ChannelHost.SelectedTab;

            ChannelHost.TabPages.Clear();
            ChannelHost.TabPages.AddRange(channels.Values.ToArray());
            ChannelHost.SelectedIndex = ChannelHost.TabPages.IndexOf(SelectedChannel);
        }

        private void SetDockType(DockType Dock)
        {
            switch (Dock)
            {
                case DockType.None:
                    {
                        toolStripDockNone.Checked = true;
                        toolStripDockLeft.Checked = false;
                        toolStripDockTop.Checked = false;
                        toolStripDockRight.Checked = false;
                        toolStripDockBottom.Checked = false;
                    }
                    break;
                case DockType.Left:
                    {
                        toolStripDockNone.Checked = false;
                        toolStripDockLeft.Checked = true;
                        toolStripDockTop.Checked = false;
                        toolStripDockRight.Checked = false;
                        toolStripDockBottom.Checked = false;
                    }
                    break;
                case DockType.Top:
                    {
                        toolStripDockNone.Checked = false;
                        toolStripDockLeft.Checked = false;
                        toolStripDockTop.Checked = true;
                        toolStripDockRight.Checked = false;
                        toolStripDockBottom.Checked = false;
                    }
                    break;
                case DockType.Right:
                    {
                        toolStripDockNone.Checked = false;
                        toolStripDockLeft.Checked = false;
                        toolStripDockTop.Checked = false;
                        toolStripDockRight.Checked = true;
                        toolStripDockBottom.Checked = false;
                    }
                    break;
                case DockType.Bottom:
                    {
                        toolStripDockNone.Checked = false;
                        toolStripDockLeft.Checked = false;
                        toolStripDockTop.Checked = false;
                        toolStripDockRight.Checked = false;
                        toolStripDockBottom.Checked = true;
                    }
                    break;
            }

            this.dock = Dock;
            lastPosition = Win32Interop.Rect.Zero();
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
            if (mainWindowHandle != IntPtr.Zero && dock != DockType.None)
            {
                if (windowUpdateTimer != null)
                {
                    if (this.Visible)
                    {
                        windowUpdateTimer.Change(0, 300);
                    }
                    else
                    {
                        windowUpdateTimer.Change(Timeout.Infinite, 300);
                    }
                }
            }
        }

        private void Viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (CommunicationChannel channel in channels.Values)
            {
                channel.Release();
            }
        }

        private void toolStripDockNone_Click(object sender, EventArgs e)
        {
            if (!toolStripDockNone.Checked)
            {
                SetDockType(DockType.None);
            }
        }

        private void toolStripDockLeft_Click(object sender, EventArgs e)
        {
            if (!toolStripDockLeft.Checked)
            {
                SetDockType(DockType.Left);
            }
        }

        private void toolStripDockTop_Click(object sender, EventArgs e)
        {
            if (!toolStripDockTop.Checked)
            {
                SetDockType(DockType.Top);
            }
        }

        private void toolStripDockRight_Click(object sender, EventArgs e)
        {
            if (!toolStripDockRight.Checked)
            {
                SetDockType(DockType.Right);
            }
        }

        private void toolStripDockBottom_Click(object sender, EventArgs e)
        {
            if (!toolStripDockBottom.Checked)
            {
                SetDockType(DockType.Bottom);
            }
        }

        private void toolStripTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = toolStripTopMost.Checked;
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

        private void CommunicationViewer_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                StartUpdateTimer();
            }
            else
            {
                StopUpdateTimer();
            }
        }

    }
}
