namespace Communication.Interface.Implementation.Panel
{
    partial class SshPanel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SshKeyFile = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SshPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SshIP = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SshUsername = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SshPassword = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.SshKeyBrowse = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.SshKeyFile, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SshPort, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SshIP, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SshUsername, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.SshPassword, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.SshKeyBrowse, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(346, 110);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // SshKeyFile
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.SshKeyFile, 3);
            this.SshKeyFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SshKeyFile.Location = new System.Drawing.Point(86, 84);
            this.SshKeyFile.Name = "SshKeyFile";
            this.SshKeyFile.Size = new System.Drawing.Size(199, 21);
            this.SshKeyFile.TabIndex = 10;
            this.SshKeyFile.TextChanged += new System.EventHandler(this.ConfigChange);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 27);
            this.label10.TabIndex = 3;
            this.label10.Text = "Port:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SshPort
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.SshPort, 4);
            this.SshPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SshPort.Location = new System.Drawing.Point(86, 30);
            this.SshPort.Name = "SshPort";
            this.SshPort.Size = new System.Drawing.Size(257, 21);
            this.SshPort.TabIndex = 23;
            this.SshPort.Text = "22";
            this.SshPort.TextChanged += new System.EventHandler(this.ConfigChange);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 27);
            this.label9.TabIndex = 3;
            this.label9.Text = "IP Address:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SshIP
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.SshIP, 4);
            this.SshIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SshIP.Location = new System.Drawing.Point(86, 3);
            this.SshIP.Name = "SshIP";
            this.SshIP.Size = new System.Drawing.Size(257, 21);
            this.SshIP.TabIndex = 2;
            this.SshIP.Text = "192.168.1.100";
            this.SshIP.TextChanged += new System.EventHandler(this.ConfigChange);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(3, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 27);
            this.label14.TabIndex = 24;
            this.label14.Text = "Username:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SshUsername
            // 
            this.SshUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SshUsername.Location = new System.Drawing.Point(86, 57);
            this.SshUsername.Name = "SshUsername";
            this.SshUsername.Size = new System.Drawing.Size(64, 21);
            this.SshUsername.TabIndex = 25;
            this.SshUsername.TextChanged += new System.EventHandler(this.ConfigChange);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(156, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 27);
            this.label15.TabIndex = 26;
            this.label15.Text = "Password:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SshPassword
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.SshPassword, 2);
            this.SshPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SshPassword.Location = new System.Drawing.Point(221, 57);
            this.SshPassword.Name = "SshPassword";
            this.SshPassword.Size = new System.Drawing.Size(122, 21);
            this.SshPassword.TabIndex = 27;
            this.SshPassword.TextChanged += new System.EventHandler(this.ConfigChange);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 29);
            this.label16.TabIndex = 28;
            this.label16.Text = "Private Key:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SshKeyBrowse
            // 
            this.SshKeyBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SshKeyBrowse.Location = new System.Drawing.Point(291, 84);
            this.SshKeyBrowse.Name = "SshKeyBrowse";
            this.SshKeyBrowse.Size = new System.Drawing.Size(52, 23);
            this.SshKeyBrowse.TabIndex = 11;
            this.SshKeyBrowse.Text = "Browse";
            this.SshKeyBrowse.UseVisualStyleBackColor = true;
            this.SshKeyBrowse.Click += new System.EventHandler(this.SshKeyBrowse_Click);
            // 
            // SshPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SshPanel";
            this.Size = new System.Drawing.Size(346, 146);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox SshIP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SshPort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox SshUsername;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox SshPassword;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox SshKeyFile;
        private System.Windows.Forms.Button SshKeyBrowse;


    }
}
