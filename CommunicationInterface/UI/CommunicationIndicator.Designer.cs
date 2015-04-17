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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommunicationIndicator));
            this.PanelLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ConsoleText = new System.Windows.Forms.TextBox();
            this.ConsoleStatus = new System.Windows.Forms.StatusStrip();
            this.ConnectionString = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConsoleToolStrip = new System.Windows.Forms.ToolStrip();
            this.CleanBtn = new System.Windows.Forms.ToolStripButton();
            this.CopyBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.InputControlBtn = new System.Windows.Forms.ToolStripButton();
            this.PanelLayout.SuspendLayout();
            this.ConsoleStatus.SuspendLayout();
            this.ConsoleToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelLayout
            // 
            this.PanelLayout.ColumnCount = 1;
            this.PanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PanelLayout.Controls.Add(this.ConsoleText, 0, 1);
            this.PanelLayout.Controls.Add(this.ConsoleStatus, 0, 2);
            this.PanelLayout.Controls.Add(this.ConsoleToolStrip, 0, 0);
            this.PanelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelLayout.Location = new System.Drawing.Point(0, 0);
            this.PanelLayout.Margin = new System.Windows.Forms.Padding(0);
            this.PanelLayout.Name = "PanelLayout";
            this.PanelLayout.RowCount = 3;
            this.PanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.PanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelLayout.Size = new System.Drawing.Size(327, 76);
            this.PanelLayout.TabIndex = 0;
            // 
            // ConsoleText
            // 
            this.ConsoleText.BackColor = System.Drawing.SystemColors.Desktop;
            this.ConsoleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleText.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ConsoleText.HideSelection = false;
            this.ConsoleText.Location = new System.Drawing.Point(0, 23);
            this.ConsoleText.Margin = new System.Windows.Forms.Padding(0);
            this.ConsoleText.Multiline = true;
            this.ConsoleText.Name = "ConsoleText";
            this.ConsoleText.ReadOnly = true;
            this.ConsoleText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleText.Size = new System.Drawing.Size(327, 33);
            this.ConsoleText.TabIndex = 1;
            this.ConsoleText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConsoleText_KeyPress);
            // 
            // ConsoleStatus
            // 
            this.ConsoleStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectionString});
            this.ConsoleStatus.Location = new System.Drawing.Point(0, 56);
            this.ConsoleStatus.Name = "ConsoleStatus";
            this.ConsoleStatus.Size = new System.Drawing.Size(327, 20);
            this.ConsoleStatus.TabIndex = 2;
            this.ConsoleStatus.Text = "statusStrip1";
            this.ConsoleStatus.Click += new System.EventHandler(this.ConsoleStatus_Click);
            // 
            // ConnectionString
            // 
            this.ConnectionString.Name = "ConnectionString";
            this.ConnectionString.Size = new System.Drawing.Size(111, 15);
            this.ConnectionString.Text = "Connection String";
            this.ConnectionString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConsoleToolStrip
            // 
            this.ConsoleToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CleanBtn,
            this.CopyBtn,
            this.toolStripSeparator9,
            this.InputControlBtn});
            this.ConsoleToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ConsoleToolStrip.Name = "ConsoleToolStrip";
            this.ConsoleToolStrip.Size = new System.Drawing.Size(327, 23);
            this.ConsoleToolStrip.TabIndex = 3;
            this.ConsoleToolStrip.Text = "toolStrip1";
            // 
            // CleanBtn
            // 
            this.CleanBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CleanBtn.Enabled = false;
            this.CleanBtn.Image = global::Communication.Interface.Properties.Resources.Clear;
            this.CleanBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CleanBtn.Name = "CleanBtn";
            this.CleanBtn.Size = new System.Drawing.Size(23, 20);
            this.CleanBtn.Text = "Clean(&E)";
            this.CleanBtn.Click += new System.EventHandler(this.CleanBtn_Click);
            // 
            // CopyBtn
            // 
            this.CopyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopyBtn.Image = ((System.Drawing.Image)(resources.GetObject("CopyBtn.Image")));
            this.CopyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyBtn.Name = "CopyBtn";
            this.CopyBtn.Size = new System.Drawing.Size(23, 20);
            this.CopyBtn.Text = "Copy(&C)";
            this.CopyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // InputControlBtn
            // 
            this.InputControlBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InputControlBtn.Enabled = false;
            this.InputControlBtn.Image = global::Communication.Interface.Properties.Resources.InputEnable;
            this.InputControlBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InputControlBtn.Name = "InputControlBtn";
            this.InputControlBtn.Size = new System.Drawing.Size(23, 20);
            this.InputControlBtn.Text = "Enable Input";
            this.InputControlBtn.Click += new System.EventHandler(this.InputControlBtn_Click);
            // 
            // CommIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.PanelLayout);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CommIndicator";
            this.Size = new System.Drawing.Size(327, 76);
            this.PanelLayout.ResumeLayout(false);
            this.PanelLayout.PerformLayout();
            this.ConsoleStatus.ResumeLayout(false);
            this.ConsoleStatus.PerformLayout();
            this.ConsoleToolStrip.ResumeLayout(false);
            this.ConsoleToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PanelLayout;
        private System.Windows.Forms.TextBox ConsoleText;
        private System.Windows.Forms.StatusStrip ConsoleStatus;
        private System.Windows.Forms.ToolStrip ConsoleToolStrip;
        private System.Windows.Forms.ToolStripButton CleanBtn;
        private System.Windows.Forms.ToolStripButton CopyBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton InputControlBtn;
        private System.Windows.Forms.ToolStripStatusLabel ConnectionString;

    }
}
