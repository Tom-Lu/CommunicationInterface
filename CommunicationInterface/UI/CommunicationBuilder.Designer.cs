namespace Communication.Interface.UI
{
    partial class CommunicationBuilder
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
            this.InterfaceType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfigTabs = new System.Windows.Forms.TabControl();
            this.ConnectionStringText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.CopyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InterfaceType
            // 
            this.InterfaceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InterfaceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InterfaceType.FormattingEnabled = true;
            this.InterfaceType.Items.AddRange(new object[] {
            "SerialPort",
            "SerialTel(Telnet Through SerialPort)",
            "Telnet",
            "Ssh"});
            this.InterfaceType.Location = new System.Drawing.Point(12, 23);
            this.InterfaceType.Name = "InterfaceType";
            this.InterfaceType.Size = new System.Drawing.Size(300, 20);
            this.InterfaceType.TabIndex = 0;
            this.InterfaceType.SelectedIndexChanged += new System.EventHandler(this.InterfaceType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Interface";
            // 
            // ConfigTabs
            // 
            this.ConfigTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigTabs.Location = new System.Drawing.Point(12, 49);
            this.ConfigTabs.Name = "ConfigTabs";
            this.ConfigTabs.SelectedIndex = 0;
            this.ConfigTabs.Size = new System.Drawing.Size(304, 175);
            this.ConfigTabs.TabIndex = 2;
            // 
            // ConnectionStringText
            // 
            this.ConnectionStringText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionStringText.Location = new System.Drawing.Point(12, 250);
            this.ConnectionStringText.Multiline = true;
            this.ConnectionStringText.Name = "ConnectionStringText";
            this.ConnectionStringText.Size = new System.Drawing.Size(300, 53);
            this.ConnectionStringText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Connection String";
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(156, 312);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 5;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(237, 312);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // CopyBtn
            // 
            this.CopyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CopyBtn.Location = new System.Drawing.Point(12, 311);
            this.CopyBtn.Name = "CopyBtn";
            this.CopyBtn.Size = new System.Drawing.Size(75, 23);
            this.CopyBtn.TabIndex = 5;
            this.CopyBtn.Text = "Copy";
            this.CopyBtn.UseVisualStyleBackColor = true;
            this.CopyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // ConnectionBuilder
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(324, 343);
            this.ControlBox = false;
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.CopyBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConnectionStringText);
            this.Controls.Add(this.ConfigTabs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InterfaceType);
            this.MaximizeBox = false;
            this.Name = "ConnectionBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection Builder";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox InterfaceType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl ConfigTabs;
        private System.Windows.Forms.TextBox ConnectionStringText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button CopyBtn;
    }
}