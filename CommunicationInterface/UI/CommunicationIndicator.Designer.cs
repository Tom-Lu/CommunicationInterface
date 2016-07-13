namespace Communication.Interface.UI
{
    partial class CommunicationIndicator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripCopySelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripInteractiveCtrl = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ConnectionString = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConsoleText = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCopySelect,
            this.toolStripSave,
            this.toolStripSeparator1,
            this.toolStripInteractiveCtrl});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(473, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripCopySelect
            // 
            this.toolStripCopySelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCopySelect.Image = global::Communication.Interface.Properties.Resources.Copy;
            this.toolStripCopySelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCopySelect.Name = "toolStripCopySelect";
            this.toolStripCopySelect.Size = new System.Drawing.Size(23, 22);
            this.toolStripCopySelect.Text = "Copy Select Content";
            this.toolStripCopySelect.Click += new System.EventHandler(this.toolStripCopySelect_Click);
            // 
            // toolStripSave
            // 
            this.toolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSave.Image = global::Communication.Interface.Properties.Resources.Save;
            this.toolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripSave.Text = "Save Content";
            this.toolStripSave.Click += new System.EventHandler(this.toolStripSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripInteractiveCtrl
            // 
            this.toolStripInteractiveCtrl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripInteractiveCtrl.Enabled = false;
            this.toolStripInteractiveCtrl.Image = global::Communication.Interface.Properties.Resources.InputEnable;
            this.toolStripInteractiveCtrl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripInteractiveCtrl.Name = "toolStripInteractiveCtrl";
            this.toolStripInteractiveCtrl.Size = new System.Drawing.Size(23, 22);
            this.toolStripInteractiveCtrl.Text = "Enable Interactive Input";
            this.toolStripInteractiveCtrl.Click += new System.EventHandler(this.toolStripInteractiveCtrl_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectionString});
            this.StatusBar.Location = new System.Drawing.Point(0, 64);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(473, 22);
            this.StatusBar.TabIndex = 1;
            this.StatusBar.Text = "statusStrip1";
            this.StatusBar.DoubleClick += new System.EventHandler(this.StatusBar_DoubleClick);
            // 
            // ConnectionString
            // 
            this.ConnectionString.Name = "ConnectionString";
            this.ConnectionString.Size = new System.Drawing.Size(111, 17);
            this.ConnectionString.Text = "Connection String";
            // 
            // ConsoleText
            // 
            this.ConsoleText.BackColor = System.Drawing.Color.Black;
            this.ConsoleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleText.ForeColor = System.Drawing.Color.White;
            this.ConsoleText.Location = new System.Drawing.Point(0, 25);
            this.ConsoleText.Multiline = true;
            this.ConsoleText.Name = "ConsoleText";
            this.ConsoleText.ReadOnly = true;
            this.ConsoleText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleText.Size = new System.Drawing.Size(473, 39);
            this.ConsoleText.TabIndex = 2;
            // 
            // CommunicationIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConsoleText);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CommunicationIndicator";
            this.Size = new System.Drawing.Size(473, 86);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.TextBox ConsoleText;
        private System.Windows.Forms.ToolStripButton toolStripCopySelect;
        private System.Windows.Forms.ToolStripButton toolStripSave;
        private System.Windows.Forms.ToolStripButton toolStripInteractiveCtrl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel ConnectionString;
    }
}
