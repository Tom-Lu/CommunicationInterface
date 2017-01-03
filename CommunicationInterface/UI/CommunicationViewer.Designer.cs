namespace Communication.Interface.UI
{
    partial class CommunicationViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommunicationViewer));
            this.ChannelHost = new System.Windows.Forms.TabControl();
            this.toolStripDock = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDockNone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDockLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDockRight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDockTop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDockBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTopMost = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTransparenceSetup = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripTransparenceLow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTransparenceMid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTransparenceHigh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChannelHost
            // 
            this.ChannelHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChannelHost.Location = new System.Drawing.Point(0, 25);
            this.ChannelHost.Name = "ChannelHost";
            this.ChannelHost.SelectedIndex = 0;
            this.ChannelHost.Size = new System.Drawing.Size(442, 259);
            this.ChannelHost.TabIndex = 2;
            // 
            // toolStripDock
            // 
            this.toolStripDock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDock.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDockNone,
            this.toolStripDockLeft,
            this.toolStripDockRight,
            this.toolStripDockTop,
            this.toolStripDockBottom});
            this.toolStripDock.Image = global::Communication.Interface.Properties.Resources.Dock;
            this.toolStripDock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDock.Name = "toolStripDock";
            this.toolStripDock.Size = new System.Drawing.Size(29, 22);
            this.toolStripDock.Text = "toolStripDropDownButton1";
            this.toolStripDock.ToolTipText = "Dock To Main Window";
            // 
            // toolStripDockNone
            // 
            this.toolStripDockNone.Name = "toolStripDockNone";
            this.toolStripDockNone.Size = new System.Drawing.Size(119, 22);
            this.toolStripDockNone.Text = "None";
            this.toolStripDockNone.Click += new System.EventHandler(this.toolStripDockNone_Click);
            // 
            // toolStripDockLeft
            // 
            this.toolStripDockLeft.Name = "toolStripDockLeft";
            this.toolStripDockLeft.Size = new System.Drawing.Size(119, 22);
            this.toolStripDockLeft.Text = "Left";
            this.toolStripDockLeft.Click += new System.EventHandler(this.toolStripDockLeft_Click);
            // 
            // toolStripDockRight
            // 
            this.toolStripDockRight.Name = "toolStripDockRight";
            this.toolStripDockRight.Size = new System.Drawing.Size(119, 22);
            this.toolStripDockRight.Text = "Right";
            this.toolStripDockRight.Click += new System.EventHandler(this.toolStripDockRight_Click);
            // 
            // toolStripDockTop
            // 
            this.toolStripDockTop.Name = "toolStripDockTop";
            this.toolStripDockTop.Size = new System.Drawing.Size(119, 22);
            this.toolStripDockTop.Text = "Top";
            this.toolStripDockTop.Click += new System.EventHandler(this.toolStripDockTop_Click);
            // 
            // toolStripDockBottom
            // 
            this.toolStripDockBottom.Name = "toolStripDockBottom";
            this.toolStripDockBottom.Size = new System.Drawing.Size(119, 22);
            this.toolStripDockBottom.Text = "Bottom";
            this.toolStripDockBottom.Click += new System.EventHandler(this.toolStripDockBottom_Click);
            // 
            // toolStripTopMost
            // 
            this.toolStripTopMost.CheckOnClick = true;
            this.toolStripTopMost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTopMost.Image = global::Communication.Interface.Properties.Resources.Bring_To_Front;
            this.toolStripTopMost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTopMost.Name = "toolStripTopMost";
            this.toolStripTopMost.Size = new System.Drawing.Size(23, 22);
            this.toolStripTopMost.Text = "toolStripButton2";
            this.toolStripTopMost.ToolTipText = "Display Above Main Window";
            this.toolStripTopMost.CheckedChanged += new System.EventHandler(this.toolStripTopMost_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDock,
            this.toolStripTopMost,
            this.toolStripTransparenceSetup});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(442, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTransparenceSetup
            // 
            this.toolStripTransparenceSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTransparenceSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTransparenceLow,
            this.toolStripTransparenceMid,
            this.toolStripTransparenceHigh});
            this.toolStripTransparenceSetup.Image = global::Communication.Interface.Properties.Resources.Transparent;
            this.toolStripTransparenceSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTransparenceSetup.Name = "toolStripTransparenceSetup";
            this.toolStripTransparenceSetup.Size = new System.Drawing.Size(29, 22);
            this.toolStripTransparenceSetup.Text = "toolStripDropDownButton2";
            this.toolStripTransparenceSetup.ToolTipText = "Transparence Setup";
            // 
            // toolStripTransparenceLow
            // 
            this.toolStripTransparenceLow.Name = "toolStripTransparenceLow";
            this.toolStripTransparenceLow.Size = new System.Drawing.Size(117, 22);
            this.toolStripTransparenceLow.Text = "Low";
            this.toolStripTransparenceLow.Click += new System.EventHandler(this.toolStripTransparenceLow_Click);
            // 
            // toolStripTransparenceMid
            // 
            this.toolStripTransparenceMid.Name = "toolStripTransparenceMid";
            this.toolStripTransparenceMid.Size = new System.Drawing.Size(117, 22);
            this.toolStripTransparenceMid.Text = "Middle";
            this.toolStripTransparenceMid.Click += new System.EventHandler(this.toolStripTransparenceMid_Click);
            // 
            // toolStripTransparenceHigh
            // 
            this.toolStripTransparenceHigh.Name = "toolStripTransparenceHigh";
            this.toolStripTransparenceHigh.Size = new System.Drawing.Size(117, 22);
            this.toolStripTransparenceHigh.Text = "High";
            this.toolStripTransparenceHigh.Click += new System.EventHandler(this.toolStripTransparenceHigh_Click);
            // 
            // CommunicationViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(442, 284);
            this.Controls.Add(this.ChannelHost);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "CommunicationViewer";
            this.Text = "CommunicationViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Viewer_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl ChannelHost;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDock;
        private System.Windows.Forms.ToolStripMenuItem toolStripDockRight;
        private System.Windows.Forms.ToolStripMenuItem toolStripDockLeft;
        private System.Windows.Forms.ToolStripMenuItem toolStripDockTop;
        private System.Windows.Forms.ToolStripMenuItem toolStripDockBottom;
        private System.Windows.Forms.ToolStripButton toolStripTopMost;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripTransparenceSetup;
        private System.Windows.Forms.ToolStripMenuItem toolStripTransparenceLow;
        private System.Windows.Forms.ToolStripMenuItem toolStripTransparenceMid;
        private System.Windows.Forms.ToolStripMenuItem toolStripTransparenceHigh;
        private System.Windows.Forms.ToolStripMenuItem toolStripDockNone;




    }
}