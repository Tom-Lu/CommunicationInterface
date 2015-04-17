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
            this.ConsoleHost = new System.Windows.Forms.TabControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDockBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripTopMostBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripTransparenceBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripTransparenceLow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTransparenceMid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTransparenceHigh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsoleHost
            // 
            this.ConsoleHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleHost.Location = new System.Drawing.Point(0, 28);
            this.ConsoleHost.Name = "ConsoleHost";
            this.ConsoleHost.SelectedIndex = 0;
            this.ConsoleHost.Size = new System.Drawing.Size(685, 294);
            this.ConsoleHost.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDockBtn,
            this.toolStripTopMostBtn,
            this.toolStripTransparenceBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(685, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDockBtn
            // 
            this.toolStripDockBtn.Checked = true;
            this.toolStripDockBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripDockBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDockBtn.Image = global::Communication.Interface.Properties.Resources.Dock;
            this.toolStripDockBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDockBtn.Name = "toolStripDockBtn";
            this.toolStripDockBtn.Size = new System.Drawing.Size(23, 22);
            this.toolStripDockBtn.Text = "Dock to main window";
            this.toolStripDockBtn.ToolTipText = "Dock To Main Window";
            this.toolStripDockBtn.Click += new System.EventHandler(this.toolStripDockBtn_Click);
            // 
            // toolStripTopMostBtn
            // 
            this.toolStripTopMostBtn.Checked = true;
            this.toolStripTopMostBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripTopMostBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTopMostBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripTopMostBtn.Image")));
            this.toolStripTopMostBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTopMostBtn.Name = "toolStripTopMostBtn";
            this.toolStripTopMostBtn.Size = new System.Drawing.Size(23, 22);
            this.toolStripTopMostBtn.ToolTipText = "Top On Main Window";
            this.toolStripTopMostBtn.Click += new System.EventHandler(this.toolStripTopMostBtn_Click);
            // 
            // toolStripTransparenceBtn
            // 
            this.toolStripTransparenceBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTransparenceBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTransparenceLow,
            this.toolStripTransparenceMid,
            this.toolStripTransparenceHigh});
            this.toolStripTransparenceBtn.Image = global::Communication.Interface.Properties.Resources.Transparent;
            this.toolStripTransparenceBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTransparenceBtn.Name = "toolStripTransparenceBtn";
            this.toolStripTransparenceBtn.Size = new System.Drawing.Size(29, 22);
            this.toolStripTransparenceBtn.Text = "toolStripDropDownButton1";
            this.toolStripTransparenceBtn.ToolTipText = "Transparence Window";
            // 
            // toolStripTransparenceLow
            // 
            this.toolStripTransparenceLow.Name = "toolStripTransparenceLow";
            this.toolStripTransparenceLow.Size = new System.Drawing.Size(152, 22);
            this.toolStripTransparenceLow.Text = "Low";
            this.toolStripTransparenceLow.Click += new System.EventHandler(this.toolStripTransparenceLow_Click);
            // 
            // toolStripTransparenceMid
            // 
            this.toolStripTransparenceMid.Name = "toolStripTransparenceMid";
            this.toolStripTransparenceMid.Size = new System.Drawing.Size(152, 22);
            this.toolStripTransparenceMid.Text = "Middle";
            this.toolStripTransparenceMid.Click += new System.EventHandler(this.toolStripTransparenceMid_Click);
            // 
            // toolStripTransparenceHigh
            // 
            this.toolStripTransparenceHigh.Name = "toolStripTransparenceHigh";
            this.toolStripTransparenceHigh.Size = new System.Drawing.Size(152, 22);
            this.toolStripTransparenceHigh.Text = "High";
            this.toolStripTransparenceHigh.Click += new System.EventHandler(this.toolStripTransparenceHigh_Click);
            // 
            // CommViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 322);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ConsoleHost);
            this.Name = "CommViewer";
            this.Text = "CommViewer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl ConsoleHost;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripDockBtn;
        private System.Windows.Forms.ToolStripButton toolStripTopMostBtn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripTransparenceBtn;
        private System.Windows.Forms.ToolStripMenuItem toolStripTransparenceLow;
        private System.Windows.Forms.ToolStripMenuItem toolStripTransparenceMid;
        private System.Windows.Forms.ToolStripMenuItem toolStripTransparenceHigh;


    }
}